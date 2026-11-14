using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;


namespace Club1
{
    internal class UsuarioRepo
    {
        Conexion conexion = new Conexion();
        public bool accesoPermitido(string usuario, string contrasena)
        {
            using (MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar())
            {
                string sqlCheck = "SELECT COUNT(*) FROM usuario WHERE nombre_usuario = @usuario AND password_hash = @contrasena AND activo = 1";
                MySql.Data.MySqlClient.MySqlCommand cmdCheck = new MySql.Data.MySqlClient.MySqlCommand(sqlCheck, con);
                cmdCheck.Parameters.AddWithValue("@usuario", usuario);
                cmdCheck.Parameters.AddWithValue("@contrasena", Crypto.createSHA256Hash(contrasena));
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                return existe > 0;
            }
        }

        public int obtenerId(string usuario)
        {
                using MySql.Data.MySqlClient.MySqlConnection con = conexion.conectar();
                const string sql = "SELECT id_usuario FROM usuario WHERE nombre_usuario = @usuario AND activo = 1";
                using MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                object? resultado = cmd.ExecuteScalar();
                if (resultado is null || resultado == DBNull.Value)
                {
                    throw new InvalidOperationException("No se pudo identificar al usuario autenticado.");
                }

                return Convert.ToInt32(resultado);
        }
    }
}
