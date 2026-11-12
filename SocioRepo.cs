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
                string sqlCheck = "SELECT COUNT(*) FROM cliente WHERE dni = @dni";
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
                string sqlInsert = "INSERT INTO cliente (dni, nombre, apellido, telefono, estado) VALUES (@dni, @nom, @ape, @tel, 1)";
                MySql.Data.MySqlClient.MySqlCommand cmdInsert = new MySql.Data.MySqlClient.MySqlCommand(sqlInsert, con);
                cmdInsert.Parameters.AddWithValue("@dni", socio.getDni());
                cmdInsert.Parameters.AddWithValue("@nom", socio.getNombre());
                cmdInsert.Parameters.AddWithValue("@ape", socio.getApellido());
                cmdInsert.Parameters.AddWithValue("@tel", socio.getTelefono());
                int filas = cmdInsert.ExecuteNonQuery();
                return filas > 0;
            }
        }

        public List<Socio> obtenerTodos()
        {
            List<Socio> socios = new List<Socio>();
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                string sqlSelect = "SELECT dni, nombre, apellido, telefono, nro_carnet FROM cliente";
                MySql.Data.MySqlClient.MySqlCommand cmdSelect = new MySql.Data.MySqlClient.MySqlCommand(sqlSelect, con);
                MySql.Data.MySqlClient.MySqlDataReader reader = cmdSelect.ExecuteReader();
                while (reader.Read())
                {
                    Socio socio = new Socio(
                        reader["dni"].ToString(),
                        reader["nombre"].ToString(),
                        reader["apellido"].ToString(),
                        reader["telefono"].ToString()
                        //reader["nro_carnet"] != DBNull.Value ? Convert.ToInt32(reader["nro_carnet"]) : 0
                    );
                    socios.Add(socio);
                }
            }
            return socios;
        }

        public Socio obtenerPorId(int idCliente)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                const string sqlSelect = """
                    SELECT dni, nombre, apellido, telefono, nro_carnet
                    FROM cliente
                    WHERE id_cliente = @id_cliente
                    """;

                using MySql.Data.MySqlClient.MySqlCommand cmdSelect =
                    new(sqlSelect, con);

                cmdSelect.Parameters.AddWithValue("@id_cliente", idCliente);

                using MySql.Data.MySqlClient.MySqlDataReader reader =
                    cmdSelect.ExecuteReader();

                if (!reader.Read())
                {
                    return null;
                }

                return new Socio(
                    reader["dni"].ToString(),
                    reader["nombre"].ToString(),
                    reader["apellido"].ToString(),
                    reader["telefono"].ToString()
                );
            }
        }

    }
}
