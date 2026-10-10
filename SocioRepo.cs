using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Club1
{
    internal class SocioRepo
    {
        Conexion conexion = new Conexion();
        public bool existeSocio(string dni)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                string sqlCheck = "SELECT COUNT(*) FROM socio WHERE dni = @dni";
                MySql.Data.MySqlClient.MySqlCommand cmdCheck = new MySql.Data.MySqlClient.MySqlCommand(sqlCheck, con);
                cmdCheck.Parameters.AddWithValue("@dni", dni);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                return existe > 0;
            }
        }
        public bool registrar(Socio socio)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                string sqlInsert = "INSERT INTO socio (dni, nombre, apellido, telefono, estado) VALUES (@dni, @nom, @ape, @tel, 1)";
                MySql.Data.MySqlClient.MySqlCommand cmdInsert = new MySql.Data.MySqlClient.MySqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@dni", socio.getDni());
                cmdInsert.Parameters.AddWithValue("@nom", socio.getNombre());
                cmdInsert.Parameters.AddWithValue("@ape", socio.getApellido());
                cmdInsert.Parameters.AddWithValue("@tel", socio.getTelefono());
                int filas = cmdInsert.ExecuteNonQuery();
                return filas > 0;
            }
        }
    }
}
