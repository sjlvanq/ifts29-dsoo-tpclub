using System;
using System.Collections.Generic;
using System.Text;

namespace Club1.Models
{
    public class Pago
    {
        public int IdPago { get; set; }
        public int IdCliente { get; set; }
        public int? IdCuota { get; set; }
        public int? IdActividad { get; set; }
        public int IdUsuario { get; set; }
        public string MedioPago { get; set; }
        public DateTime FechaPago { get; set; }
        public decimal Importe { get; set; }
        public bool Anulado { get; set; }
        public string? NotaAnulacion { get; set; }

        public Pago()
        {
            MedioPago = string.Empty;
            FechaPago = DateTime.Now;
        }

        public Pago(int idCliente, int idUsuario, decimal importe, string medioPago, DateTime fechaPago, int? idCuota = null, int? idActividad = null)
        {
            if (idCliente <= 0)
                throw new ArgumentException("El cliente es obligatorio.", nameof(idCliente));

            if (idUsuario <= 0)
                throw new ArgumentException("El usuario que registra el pago es obligatorio.", nameof(idUsuario));

            if (importe <= 0)
                throw new ArgumentException("El importe debe ser mayor a cero.", nameof(importe));

            if (string.IsNullOrWhiteSpace(medioPago))
                throw new ArgumentException("El medio de pago es obligatorio.", nameof(medioPago));

            if (idCuota.HasValue == idActividad.HasValue)
                throw new ArgumentException("Un pago debe corresponder a una cuota o a una actividad, pero no a ambas ni a ninguna.");

            IdCliente = idCliente;
            IdUsuario = idUsuario;
            Importe = importe;
            MedioPago = medioPago.Trim();
            FechaPago = fechaPago;
            IdCuota = idCuota;
            IdActividad = idActividad;
        }

        public bool EsCuota => IdCuota.HasValue;
        public bool EsActividad => IdActividad.HasValue;
    }
}
