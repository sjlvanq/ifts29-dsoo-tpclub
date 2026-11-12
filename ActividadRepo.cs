using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Club1
{
    internal class ActividadRepo
    {
        Conexion conexion = new Conexion();

        public List<Actividad> obtenerTodas()
        {
            List<Actividad> actividades = new List<Actividad>();
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = "SELECT nombre, precio_diario, fecha_baja FROM actividad";
                MySql.Data.MySqlClient.MySqlCommand cmdSelect = new MySql.Data.MySqlClient.MySqlCommand(sqlSelect, con);
                MySql.Data.MySqlClient.MySqlDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    var nombre = reader["nombre"] as string;
                    var precioDiario = reader.GetDecimal(reader.GetOrdinal("precio_diario"));
                    var fechaBajaText = reader["fecha_baja"]?.ToString();

                    DateTime fechaBaja;
                    if (string.IsNullOrWhiteSpace(fechaBajaText) || !DateTime.TryParse(fechaBajaText, out fechaBaja))
                    {
                        fechaBaja = DateTime.MinValue;
                    }

                    Actividad actividad = new Actividad(
                        nombre ?? string.Empty,
                        precioDiario,
                        fechaBaja
                    );
                    actividades.Add(actividad);
                }
            }
            return actividades;
        }
    }
}
