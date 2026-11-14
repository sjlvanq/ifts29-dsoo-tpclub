using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;

namespace Club1
{
    internal class SocioRepo
    {
        Conexion conexion = new Conexion();

        public bool existeSocio(string dni)
        {
            using MySqlConnection con = conexion.conectar();
            string sqlCheck = "SELECT COUNT(*) FROM cliente WHERE dni = @dni";
            using MySqlCommand cmdCheck = new MySqlCommand(sqlCheck, con);
            cmdCheck.Parameters.AddWithValue("@dni", dni);
            int existe = Convert.ToInt32(cmdCheck.ExecuteScalar());
            return existe > 0;
        }

        public bool registrar(Socio socio)
        {
            using MySqlConnection con = conexion.conectar();
            string sqlInsert = "INSERT INTO cliente (dni, nombre, apellido, telefono, apto_fisico, es_socio) VALUES (@dni, @nom, @ape, @tel, @apto, 0)";
            using MySqlCommand cmdInsert = new MySqlCommand(sqlInsert, con);
            cmdInsert.Parameters.AddWithValue("@dni", socio.getDni());
            cmdInsert.Parameters.AddWithValue("@nom", socio.getNombre());
            cmdInsert.Parameters.AddWithValue("@ape", socio.getApellido());
            cmdInsert.Parameters.AddWithValue("@tel", socio.getTelefono());
            cmdInsert.Parameters.AddWithValue("@apto", socio.getTieneAptoFisico() ? 1 : 0);
            int filas = cmdInsert.ExecuteNonQuery();
            return filas > 0;
        }

        public List<Socio> obtenerTodos()
        {
            List<Socio> socios = new List<Socio>();
            using MySqlConnection con = conexion.conectar();
            string sqlSelect = "SELECT id_cliente, dni, nombre, apellido, telefono, nro_carnet, apto_fisico, es_socio FROM cliente";
            using MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, con);
            using MySqlDataReader reader = cmdSelect.ExecuteReader();
            while (reader.Read())
            {
                Socio socio = new Socio(
                    reader["dni"].ToString() ?? string.Empty,
                    reader["nombre"].ToString() ?? string.Empty,
                    reader["apellido"].ToString() ?? string.Empty,
                    reader["telefono"]?.ToString() ?? string.Empty
                );
                socio.IdCliente = reader.IsDBNull(reader.GetOrdinal("id_cliente")) ? 0 : reader.GetInt32(reader.GetOrdinal("id_cliente"));
                int ordinalCarnet = reader.GetOrdinal("nro_carnet");
                socio.NroCarnet = reader.IsDBNull(ordinalCarnet) ? 0 : reader.GetInt32(ordinalCarnet);
                int ordinalApto = reader.GetOrdinal("apto_fisico");
                socio.TieneAptoFisico = !reader.IsDBNull(ordinalApto) && Convert.ToInt32(reader.GetValue(ordinalApto)) == 1;
                int ordinalEsSocio = reader.GetOrdinal("es_socio");
                socio.EsSocio = !reader.IsDBNull(ordinalEsSocio) && Convert.ToInt32(reader.GetValue(ordinalEsSocio)) == 1;
                socios.Add(socio);
            }
            return socios;
        }

        public Socio? obtenerPorId(int idCliente)
        {
            using MySqlConnection con = conexion.conectar();
            const string sqlSelect = """
                SELECT id_cliente, dni, nombre, apellido, telefono, nro_carnet, apto_fisico, es_socio
                FROM cliente
                WHERE id_cliente = @id_cliente
                """;
            using MySqlCommand cmdSelect = new MySqlCommand(sqlSelect, con);
            cmdSelect.Parameters.AddWithValue("@id_cliente", idCliente);
            using MySqlDataReader reader = cmdSelect.ExecuteReader();
            if (!reader.Read())
            {
                return null;
            }
            Socio socio = new Socio(
                reader["dni"].ToString() ?? string.Empty,
                reader["nombre"].ToString() ?? string.Empty,
                reader["apellido"].ToString() ?? string.Empty,
                reader["telefono"]?.ToString() ?? string.Empty
            );
            socio.IdCliente = idCliente;
            int ordinalCarnet = reader.GetOrdinal("nro_carnet");
            socio.NroCarnet = reader.IsDBNull(ordinalCarnet) ? 0 : reader.GetInt32(ordinalCarnet);
            int ordinalApto = reader.GetOrdinal("apto_fisico");
            socio.TieneAptoFisico = !reader.IsDBNull(ordinalApto) && Convert.ToInt32(reader.GetValue(ordinalApto)) == 1;
            int ordinalEsSocio = reader.GetOrdinal("es_socio");
            socio.EsSocio = !reader.IsDBNull(ordinalEsSocio) && Convert.ToInt32(reader.GetValue(ordinalEsSocio)) == 1;
            return socio;
        }

        public ContratacionResultado contratarPlan(int idCliente, int idPlan, int idPromocion, DateTime? fechaInicio = null)
        {
            using MySqlConnection con = conexion.conectar();
            using MySqlCommand command = new("sp_contratar_plan", con)
            {
                CommandType = CommandType.StoredProcedure
            };
            command.Parameters.Add("@p_id_cliente", MySqlDbType.Int32).Value = idCliente;
            command.Parameters.Add("@p_id_plan", MySqlDbType.Int32).Value = idPlan;
            command.Parameters.Add("@p_id_promocion", MySqlDbType.Int32).Value = idPromocion;
            command.Parameters.Add("@p_fecha_inicio", MySqlDbType.Date).Value =
                fechaInicio.HasValue ? fechaInicio.Value.Date : DBNull.Value;

            using MySqlDataReader reader = command.ExecuteReader();
            if (!reader.Read())
            {
                throw new InvalidOperationException("La contratación no devolvió resultados.");
            }

            return new ContratacionResultado(
                reader.GetInt32(reader.GetOrdinal("id_contrato")),
                reader.GetInt32(reader.GetOrdinal("nro_carnet")),
                reader.GetInt32(reader.GetOrdinal("cuotas")),
                reader.GetDecimal(reader.GetOrdinal("importe_cuota")));
        }
    }
}
