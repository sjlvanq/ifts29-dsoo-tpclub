using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Club1.Data;
using Club1.Models;

namespace Club1.Data.Repositories
{
    internal class CuotaRepo
    {
        private readonly Conexion conexion = new();

        public List<CuotaInfo> obtenerCuotasPorCliente(int idCliente)
        {
            List<CuotaInfo> cuotas = new();

            using MySqlConnection con = conexion.conectar();
            const string sql = @"
                SELECT cu.id_cuota,
                       c.id_cliente,
                       cu.nro_cuota,
                       cu.fecha_desde,
                       cu.fecha_vencimiento,
                       cu.importe,
                       p.nombre AS plan_nombre,
                       c.n_cuotas AS total_cuotas,
                       pg.id_pago IS NOT NULL AS pagada,
                       pg.anulado AS pago_anulado
                FROM cuota cu
                JOIN contrato c ON c.id_contrato = cu.id_contrato
                JOIN plan p ON p.id_plan = c.id_plan
                LEFT JOIN pago pg ON pg.id_cuota = cu.id_cuota
                WHERE c.id_cliente = @id_cliente
                ORDER BY cu.fecha_vencimiento ASC";

            using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@id_cliente", idCliente);

            using MySqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cuotas.Add(new CuotaInfo
                {
                    IdCuota = reader.GetInt32(reader.GetOrdinal("id_cuota")),
                    IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                    NroCuota = reader.GetInt32(reader.GetOrdinal("nro_cuota")),
                    FechaDesde = reader.GetDateTime(reader.GetOrdinal("fecha_desde")),
                    FechaVencimiento = reader.GetDateTime(reader.GetOrdinal("fecha_vencimiento")),
                    Importe = reader.GetDecimal(reader.GetOrdinal("importe")),
                    PlanNombre = reader["plan_nombre"]?.ToString() ?? string.Empty,
                    TotalCuotas = reader.GetInt32(reader.GetOrdinal("total_cuotas")),
                    Pagada = !reader.IsDBNull(reader.GetOrdinal("pagada")) &&
                              !Convert.ToBoolean(reader["pago_anulado"])
                });
            }

            return cuotas;
        }

        public CuotaInfo? obtenerPorId(int idCuota)
        {
            using MySqlConnection con = conexion.conectar();
            const string sql = @"
                SELECT cu.id_cuota,
                       c.id_cliente,
                       cu.nro_cuota,
                       cu.fecha_desde,
                       cu.fecha_vencimiento,
                       cu.importe,
                       p.nombre AS plan_nombre,
                       c.n_cuotas AS total_cuotas,
                       pg.id_pago IS NOT NULL AS pagada,
                       pg.anulado AS pago_anulado
                FROM cuota cu
                JOIN contrato c ON c.id_contrato = cu.id_contrato
                JOIN plan p ON p.id_plan = c.id_plan
                LEFT JOIN pago pg ON pg.id_cuota = cu.id_cuota
                WHERE cu.id_cuota = @id_cuota";

            using MySqlCommand cmd = new(sql, con);
            cmd.Parameters.AddWithValue("@id_cuota", idCuota);

            using MySqlDataReader reader = cmd.ExecuteReader();
            if (!reader.Read())
                return null;

            return new CuotaInfo
            {
                IdCuota = reader.GetInt32(reader.GetOrdinal("id_cuota")),
                IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                NroCuota = reader.GetInt32(reader.GetOrdinal("nro_cuota")),
                FechaDesde = reader.GetDateTime(reader.GetOrdinal("fecha_desde")),
                FechaVencimiento = reader.GetDateTime(reader.GetOrdinal("fecha_vencimiento")),
                Importe = reader.GetDecimal(reader.GetOrdinal("importe")),
                PlanNombre = reader["plan_nombre"]?.ToString() ?? string.Empty,
                TotalCuotas = reader.GetInt32(reader.GetOrdinal("total_cuotas")),
                Pagada = !reader.IsDBNull(reader.GetOrdinal("pagada")) &&
                          !Convert.ToBoolean(reader["pago_anulado"])
            };
        }
    }

    public class CuotaInfo
    {
        public int IdCuota { get; set; }
        public int IdCliente { get; set; }
        public int NroCuota { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public decimal Importe { get; set; }
        public string PlanNombre { get; set; } = string.Empty;
        public int TotalCuotas { get; set; }
        public bool Pagada { get; set; }
    }
}
