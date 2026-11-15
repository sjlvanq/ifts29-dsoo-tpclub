using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Club1
{
    internal class VencimientoRepo
    {
        private readonly Conexion conexion = new();

        public List<Vencimiento> obtenerVencimientos(DateTime? fecha = null)
        {
            List<Vencimiento> vencimientos = new();

            using MySqlConnection con = conexion.conectar();
            using MySqlCommand cmd = new("sp_listado_vencimientos_diario", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            cmd.Parameters.Add("@p_fecha", MySqlDbType.Date).Value =
                fecha.HasValue ? fecha.Value.Date : DBNull.Value;

            using MySqlDataReader reader = cmd.ExecuteReader();

            int ordinalCarnet = reader.GetOrdinal("nro_carnet");
            int ordinalApellido = reader.GetOrdinal("apellido");
            int ordinalNombre = reader.GetOrdinal("nombre");
            int ordinalTelefono = reader.GetOrdinal("telefono");
            int ordinalPlan = reader.GetOrdinal("plan");
            int ordinalNroCuota = reader.GetOrdinal("nro_cuota");
            int ordinalTotalCuotas = reader.GetOrdinal("n_cuotas");
            int ordinalFechaVencimiento = reader.GetOrdinal("fecha_vencimiento");
            int ordinalTieneCuotaSiguiente = reader.GetOrdinal("tiene_cuota_siguiente");
            int ordinalImporteSiguiente = reader.GetOrdinal("importe_cuota_siguiente");

            while (reader.Read())
            {
                string carnet = reader.IsDBNull(ordinalCarnet)
                    ? string.Empty
                    : reader.GetValue(ordinalCarnet).ToString() ?? string.Empty;
                string apellido = reader.IsDBNull(ordinalApellido)
                    ? string.Empty
                    : reader.GetString(ordinalApellido);
                string nombre = reader.IsDBNull(ordinalNombre)
                    ? string.Empty
                    : reader.GetString(ordinalNombre);
                string telefono = reader.IsDBNull(ordinalTelefono)
                    ? string.Empty
                    : reader.GetString(ordinalTelefono);
                string plan = reader.IsDBNull(ordinalPlan)
                    ? string.Empty
                    : reader.GetString(ordinalPlan);
                bool tieneCuotaSiguiente = !reader.IsDBNull(ordinalTieneCuotaSiguiente)
                    && Convert.ToBoolean(reader.GetValue(ordinalTieneCuotaSiguiente));
                decimal? importeSiguiente = reader.IsDBNull(ordinalImporteSiguiente)
                    ? null
                    : reader.GetDecimal(ordinalImporteSiguiente);

                vencimientos.Add(new Vencimiento(
                    carnet,
                    $"{nombre} {apellido}".Trim(),
                    telefono,
                    plan,
                    reader.GetInt32(ordinalNroCuota),
                    reader.GetInt32(ordinalTotalCuotas),
                    reader.GetDateTime(ordinalFechaVencimiento),
                    tieneCuotaSiguiente,
                    importeSiguiente));
            }

            return vencimientos;
        }

        public Vencimiento? obtenerProximoVencimientoPorDni(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new ArgumentException("El DNI es obligatorio.", nameof(dni));
            }

            return obtenerProximoVencimiento(dni.Trim(), null);
        }

        public Vencimiento? obtenerProximoVencimientoPorCarnet(int nroCarnet)
        {
            if (nroCarnet <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(nroCarnet), "El número de carnet debe ser mayor a cero.");
            }

            return obtenerProximoVencimiento(null, nroCarnet);
        }

        private Vencimiento? obtenerProximoVencimiento(string? dni, int? nroCarnet)
        {
            const string sql = """
                SELECT cl.dni,
                       cl.nro_carnet,
                       cl.nombre,
                       cl.apellido,
                       cl.telefono,
                       p.nombre AS plan,
                       cu.nro_cuota,
                       c.n_cuotas,
                       cu.fecha_vencimiento,
                       sig.id_cuota IS NOT NULL AS tiene_cuota_siguiente,
                       sig.importe AS importe_cuota_siguiente
                FROM cliente cl
                JOIN contrato c ON c.id_cliente = cl.id_cliente
                JOIN plan p ON p.id_plan = c.id_plan
                JOIN cuota cu ON cu.id_contrato = c.id_contrato
                JOIN pago pg ON pg.id_cuota = cu.id_cuota
                LEFT JOIN cuota sig
                       ON sig.id_contrato = c.id_contrato
                      AND sig.nro_cuota = cu.nro_cuota + 1
                WHERE ((@p_dni IS NOT NULL AND cl.dni = @p_dni)
                    OR (@p_nro_carnet IS NOT NULL AND cl.nro_carnet = @p_nro_carnet))
                  AND cu.fecha_vencimiento >= CURDATE()
                  AND NOT EXISTS (
                      SELECT 1
                      FROM cuota cu2
                      JOIN pago pg2 ON pg2.id_cuota = cu2.id_cuota
                      JOIN contrato c2 ON c2.id_contrato = cu2.id_contrato
                      WHERE c2.id_cliente = cl.id_cliente
                        AND cu2.fecha_vencimiento > cu.fecha_vencimiento
                  )
                ORDER BY cu.fecha_vencimiento DESC, cu.nro_cuota DESC
                LIMIT 1
                """;

            using MySqlConnection con = conexion.conectar();
            using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.Add("@p_dni", MySqlDbType.VarChar, 10).Value =
                dni is null ? DBNull.Value : dni;
            cmd.Parameters.Add("@p_nro_carnet", MySqlDbType.Int32).Value =
                nroCarnet.HasValue ? nroCarnet.Value : DBNull.Value;

            using MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }

            int ordinalCarnet = reader.GetOrdinal("nro_carnet");
            int ordinalApellido = reader.GetOrdinal("apellido");
            int ordinalNombre = reader.GetOrdinal("nombre");
            int ordinalTelefono = reader.GetOrdinal("telefono");
            int ordinalPlan = reader.GetOrdinal("plan");
            int ordinalNroCuota = reader.GetOrdinal("nro_cuota");
            int ordinalTotalCuotas = reader.GetOrdinal("n_cuotas");
            int ordinalFechaVencimiento = reader.GetOrdinal("fecha_vencimiento");
            int ordinalTieneCuotaSiguiente = reader.GetOrdinal("tiene_cuota_siguiente");
            int ordinalImporteSiguiente = reader.GetOrdinal("importe_cuota_siguiente");

            string carnet = reader.IsDBNull(ordinalCarnet)
                ? string.Empty
                : reader.GetValue(ordinalCarnet).ToString() ?? string.Empty;
            string dniCliente = reader.GetString(reader.GetOrdinal("dni"));
            string apellido = reader.IsDBNull(ordinalApellido)
                ? string.Empty
                : reader.GetString(ordinalApellido);
            string nombre = reader.IsDBNull(ordinalNombre)
                ? string.Empty
                : reader.GetString(ordinalNombre);
            string telefono = reader.IsDBNull(ordinalTelefono)
                ? string.Empty
                : reader.GetString(ordinalTelefono);
            string plan = reader.IsDBNull(ordinalPlan)
                ? string.Empty
                : reader.GetString(ordinalPlan);
            bool tieneCuotaSiguiente = !reader.IsDBNull(ordinalTieneCuotaSiguiente)
                && Convert.ToBoolean(reader.GetValue(ordinalTieneCuotaSiguiente));
            decimal? importeSiguiente = reader.IsDBNull(ordinalImporteSiguiente)
                ? null
                : reader.GetDecimal(ordinalImporteSiguiente);

            return new Vencimiento(
                carnet,
                $"{nombre} {apellido}".Trim(),
                telefono,
                plan,
                reader.GetInt32(ordinalNroCuota),
                reader.GetInt32(ordinalTotalCuotas),
                reader.GetDateTime(ordinalFechaVencimiento),
                tieneCuotaSiguiente,
                importeSiguiente,
                dniCliente);
        }
    }
}
