using MySql.Data.MySqlClient;

namespace Club1.Data
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

    }
}