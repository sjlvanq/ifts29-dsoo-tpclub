using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Club1
{
    public class Conexion
    {

        private static string _cadena = "Server=localhost;Port=3306;Database=club_deportivo;Uid=root;Password=;";

        public static string CadenaConexion
        {
            get => _cadena;
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    _cadena = value;
                }
            }
        }

        public Conexion(string cadena)
        {
            if (!string.IsNullOrWhiteSpace(cadena))
            {
                _cadena = cadena;
            }
        }

        public Conexion()
        {
        }

        public MySqlConnection conectar()
        {
            MySqlConnection conexion = new MySqlConnection(_cadena);
            conexion.Open();
            return conexion;
        }

        public static bool ConfigurarInteractivo()
        {
            using FormLoginAndDbConnection form = new FormLoginAndDbConnection();

            if (form.ShowDialog() != DialogResult.OK)
            {
                return false;
            }

            try
            {
                using MySqlConnection test = new MySqlConnection(form.CadenaConexion);
                test.Open();
                CadenaConexion = form.CadenaConexion;
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    $"No se pudo conectar a la base de datos.\n{ex.Message}",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return ConfigurarInteractivo();
            }
        }
    }
}