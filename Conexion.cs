using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Club1
{
    public class Conexion
    {
        private string cadena = "Server=localhost;Port=3306;Database=club_deportivo;Uid=root;Pwd=1234;";
        public MySqlConnection conectar()
        {
            MySqlConnection conexion = new MySqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
    }
}
