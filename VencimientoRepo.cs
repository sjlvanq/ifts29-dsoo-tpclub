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
    }
}
