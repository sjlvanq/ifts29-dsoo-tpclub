using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Club1.Data;
using Club1.Models;

namespace Club1.Data.Repositories
{
    internal class ActividadRepo
    {
        Conexion conexion = new Conexion();

        public List<Actividad> obtenerTodas()
        {
            List<Actividad> actividades = new List<Actividad>();
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = "SELECT id_actividad, nombre, precio_diario, fecha_baja FROM actividad";
                MySql.Data.MySqlClient.MySqlCommand cmdSelect = new MySql.Data.MySqlClient.MySqlCommand(sqlSelect, con);
                MySql.Data.MySqlClient.MySqlDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    var idActividad = reader.GetInt32(reader.GetOrdinal("id_actividad"));
                    var nombre = reader["nombre"] as string;
                    var precioDiario = reader.GetDecimal(reader.GetOrdinal("precio_diario"));
                    var fechaBajaText = reader["fecha_baja"]?.ToString();

                    DateTime fechaBaja;
                    if (string.IsNullOrWhiteSpace(fechaBajaText) || !DateTime.TryParse(fechaBajaText, out fechaBaja))
                    {
                        fechaBaja = DateTime.MinValue;
                    }

                    Actividad actividad = new Actividad(
                        idActividad,
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
