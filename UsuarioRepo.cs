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
                string sqlCheck = "SELECT COUNT(*) FROM usuario WHERE usuario = @usuario AND contrasena = @contrasena";
                MySql.Data.MySqlClient.MySqlCommand cmdCheck = new MySql.Data.MySqlClient.MySqlCommand(sqlCheck, con);
                cmdCheck.Parameters.AddWithValue("@usuario", usuario);
                byte[] bytesEntrada = Encoding.UTF8.GetBytes(contrasena);
                byte[] bytesHash = SHA256.HashData(bytesEntrada);
                string hash = Convert.ToHexString(bytesHash).ToLower();
                cmdCheck.Parameters.AddWithValue("@contrasena", hash);
                int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
                return existe > 0;
            }
        }
    }
}
