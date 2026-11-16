using System;
using System.Collections.Generic;
using System.Text;

using MySql.Data.MySqlClient;

namespace Club1
{
    internal class PagoRepo
    {
        private readonly Conexion conexion = new();

        public bool registrar(Pago pago)
        {
            if (pago == null)
                throw new ArgumentNullException(nameof(pago));

            using MySqlConnection con = conexion.conectar();
            string procedure = pago.EsCuota
                ? "sp_registrar_pago_cuota"
                : "sp_registrar_pago_actividad";
            using MySqlCommand command = new(procedure, con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };

            if (pago.EsCuota)
            {
                command.Parameters.Add("@p_id_cuota", MySqlDbType.Int32).Value = pago.IdCuota!.Value;
                command.Parameters.Add("@p_id_usuario", MySqlDbType.Int32).Value = pago.IdUsuario;
                command.Parameters.Add("@p_medio_pago", MySqlDbType.VarChar, 10).Value = pago.MedioPago;
            }
            else
            {
                command.Parameters.Add("@p_id_cliente", MySqlDbType.Int32).Value = pago.IdCliente;
                command.Parameters.Add("@p_id_actividad", MySqlDbType.Int32).Value = pago.IdActividad!.Value;
                command.Parameters.Add("@p_id_usuario", MySqlDbType.Int32).Value = pago.IdUsuario;
                command.Parameters.Add("@p_medio_pago", MySqlDbType.VarChar, 10).Value = pago.MedioPago;
            }

            using MySqlDataReader reader = command.ExecuteReader();
            return reader.Read();
        }

        public void anular(int idPago, string notaAnulacion)
        {
            if (idPago <= 0)
                throw new ArgumentOutOfRangeException(nameof(idPago), "El identificador del pago debe ser mayor a cero.");

            if (string.IsNullOrWhiteSpace(notaAnulacion))
                throw new ArgumentException("La causa de anulación es obligatoria.", nameof(notaAnulacion));

            if (notaAnulacion.Trim().Length > 200)
                throw new ArgumentException("La causa de anulación no puede superar 200 caracteres.", nameof(notaAnulacion));

            using MySqlConnection con = conexion.conectar();
            using MySqlCommand command = new("sp_anular_pago", con)
            {
                CommandType = System.Data.CommandType.StoredProcedure
            };
            command.Parameters.Add("@p_id_pago", MySqlDbType.Int32).Value = idPago;
            command.Parameters.Add("@p_nota_anulacion", MySqlDbType.VarChar, 200).Value = notaAnulacion.Trim();
            command.ExecuteNonQuery();
        }

        public List<PagoListDTO> obtenerTodos()
        {
            List<PagoListDTO> pagos = new List<PagoListDTO>();

            using (MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = @"SELECT
                        p.id_pago,
                        p.id_cliente,
                        p.id_usuario,
                        p.id_cuota,
                        p.id_actividad,
                        CONCAT(c.nombre, ' ', c.apellido) AS cliente_nombre,
                        c.dni AS cliente_dni,
                        c.nro_carnet AS cliente_nro_carnet,
                        (SELECT 1 FROM vw_socio_habilitado WHERE id_cliente = p.id_cliente) as cliente_habilitado,
                        c.es_socio AS cliente_es_socio,
                        a.nombre AS actividad_nombre,
                        p.medio_pago AS  medio_pago,
                        p.fecha_pago AS fecha_pago,
                        p.importe AS importe,
                        p.anulado AS anulado,
                        p.nota_anulacion AS nota_anulacion
                    FROM pago p
                    INNER JOIN cliente c ON c.id_cliente = p.id_cliente
                    LEFT JOIN actividad a ON a.id_actividad = p.id_actividad";

                MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, con);
                using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pago pago = new Pago();

                        int ordinalIdPago = reader.GetOrdinal("id_pago");
                        int ordinalIdCliente = reader.GetOrdinal("id_cliente");
                        int ordinalIdUsuario = reader.GetOrdinal("id_usuario");
                        int ordinalMedioPago = reader.GetOrdinal("medio_pago");
                        int ordinalFechaPago = reader.GetOrdinal("fecha_pago");
                        int ordinalImporte = reader.GetOrdinal("importe");
                        int ordinalCuota = reader.GetOrdinal("id_cuota");
                        int ordinalActividad = reader.GetOrdinal("id_actividad");

                        pago.IdPago = reader.GetInt32(ordinalIdPago);
                        pago.IdCliente = reader.GetInt32(ordinalIdCliente);
                        if (!reader.IsDBNull(ordinalIdUsuario))
                            pago.IdUsuario = reader.GetInt32(ordinalIdUsuario);

                        pago.MedioPago = reader.IsDBNull(ordinalMedioPago)
                            ? string.Empty
                            : reader.GetString(ordinalMedioPago);
                        pago.FechaPago = reader.GetDateTime(ordinalFechaPago);
                        pago.Importe = reader.GetDecimal(ordinalImporte);

                        if (!reader.IsDBNull(ordinalCuota))
                            pago.IdCuota = reader.GetInt32(ordinalCuota);

                        if (!reader.IsDBNull(ordinalActividad))
                            pago.IdActividad = reader.GetInt32(ordinalActividad);

                        PagoListDTO pagoDTO = new PagoListDTO(pago)
                        {
                            ClienteNombreCompleto = reader["cliente_nombre"]?.ToString() ?? string.Empty,
                            ClienteDni = reader["cliente_dni"]?.ToString() ?? string.Empty,
                            ClienteNroCarnet = reader["cliente_nro_carnet"]?.ToString() ?? string.Empty,
                            ClienteHabilitado = reader["cliente_habilitado"] != DBNull.Value && Convert.ToInt32(reader["cliente_habilitado"]) == 1,
                            ClienteEsSocio = reader["cliente_es_socio"] != DBNull.Value && Convert.ToInt32(reader["cliente_es_socio"]) == 1,
                            ActividadNombre = reader["actividad_nombre"]?.ToString() ?? string.Empty,
                            Anulado = Convert.ToBoolean(reader["anulado"]),
                            NotaAnulacion = reader["nota_anulacion"] == DBNull.Value ? null : reader["nota_anulacion"].ToString()
                        };
                        pagos.Add(pagoDTO);
                    }
                }
            }

            return pagos;
        }

        //public List

        public List<Pago> obtenerPorCliente(int idCliente)
        {
            List<Pago> pagos = new List<Pago>();

            using (MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = @"SELECT id_pago, id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion
                                     FROM pago
                                     WHERE id_cliente = @idCliente";

                MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@idCliente", idCliente);

                using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Pago pago = new Pago();
                        pago.IdPago = reader.GetInt32(reader.GetOrdinal("id_pago"));
                        pago.IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente"));
                        pago.IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                        pago.MedioPago = reader["medio_pago"]?.ToString() ?? string.Empty;
                        pago.FechaPago = reader.GetDateTime(reader.GetOrdinal("fecha_pago"));
                        pago.Importe = reader.GetDecimal(reader.GetOrdinal("importe"));
                        pago.Anulado = Convert.ToBoolean(reader["anulado"]);
                        pago.NotaAnulacion = reader.IsDBNull(reader.GetOrdinal("nota_anulacion"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("nota_anulacion"));

                        int ordinalCuota = reader.GetOrdinal("id_cuota");
                        int ordinalActividad = reader.GetOrdinal("id_actividad");

                        if (!reader.IsDBNull(ordinalCuota))
                            pago.IdCuota = reader.GetInt32(ordinalCuota);

                        if (!reader.IsDBNull(ordinalActividad))
                            pago.IdActividad = reader.GetInt32(ordinalActividad);

                        pagos.Add(pago);
                    }
                }
            }

            return pagos;
        }

        public Pago? obtenerPorId(int idPago)
        {
            using (MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = @"SELECT id_pago, id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe, anulado, nota_anulacion
                                     FROM pago
                                     WHERE id_pago = @idPago";

                MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, con);
                cmdSelect.Parameters.AddWithValue("@idPago", idPago);

                using (MySqlDataReader reader = cmdSelect.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Pago pago = new Pago();
                        pago.IdPago = reader.GetInt32(reader.GetOrdinal("id_pago"));
                        pago.IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente"));
                        pago.IdUsuario = reader.GetInt32(reader.GetOrdinal("id_usuario"));
                        pago.MedioPago = reader["medio_pago"]?.ToString() ?? string.Empty;
                        pago.FechaPago = reader.GetDateTime(reader.GetOrdinal("fecha_pago"));
                        pago.Importe = reader.GetDecimal(reader.GetOrdinal("importe"));
                        pago.Anulado = Convert.ToBoolean(reader["anulado"]);
                        pago.NotaAnulacion = reader.IsDBNull(reader.GetOrdinal("nota_anulacion"))
                            ? null
                            : reader.GetString(reader.GetOrdinal("nota_anulacion"));

                        int ordinalCuota = reader.GetOrdinal("id_cuota");
                        int ordinalActividad = reader.GetOrdinal("id_actividad");

                        if (!reader.IsDBNull(ordinalCuota))
                            pago.IdCuota = reader.GetInt32(ordinalCuota);

                        if (!reader.IsDBNull(ordinalActividad))
                            pago.IdActividad = reader.GetInt32(ordinalActividad);

                        return pago;
                    }
                }
            }

            return null;
        }
    }
}
