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

            using (MySqlConnection con = conexion.conectar())
            {
                string sqlInsert = @"INSERT INTO pago (id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, importe)
                                     VALUES (@idCliente, @idCuota, @idActividad, @idUsuario, @medioPago, @importe)";

                MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@idCliente", pago.IdCliente);
                cmdInsert.Parameters.AddWithValue("@idCuota", pago.IdCuota ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@idActividad", pago.IdActividad ?? (object)DBNull.Value);
                cmdInsert.Parameters.AddWithValue("@idUsuario", pago.IdUsuario);
                cmdInsert.Parameters.AddWithValue("@medioPago", pago.MedioPago);
                cmdInsert.Parameters.AddWithValue("@importe", pago.Importe);

                return cmdInsert.ExecuteNonQuery() > 0;
            }
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
                        a.nombre AS actividad_nombre,
                        p.medio_pago AS  medio_pago,
                        p.fecha_pago AS fecha_pago,
                        p.importe AS importe
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
                            ActividadNombre = reader["actividad_nombre"]?.ToString() ?? string.Empty
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
                string sqlSelect = @"SELECT id_pago, id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe
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

        public Pago obtenerPorId(int idPago)
        {
            using (MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = @"SELECT id_pago, id_cliente, id_cuota, id_actividad, id_usuario, medio_pago, fecha_pago, importe
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
