using System;
using System.Collections.Generic;
using System.Text;

namespace Club1
{
    public class PagoListDTO : IControlListadoRecord
    {
        public int IdPago { get; set; }
        public string ClienteNombreCompleto { get; set; } = string.Empty;
        public string ClienteDni { get; set; } = string.Empty;
        public string ClienteNroCarnet { get; set; } = string.Empty;
        public bool ClienteHabilitado { get; set; }
        public string? ActividadNombre { get; set; }
        public string MedioPago { get; set; } = string.Empty;
        public DateTime FechaPago { get; set; }
        public decimal Importe { get; set; }

        public PagoListDTO(Pago pago, string? clienteNombreCompleto = null, string? clienteDni = null, string? clienteNroCarnet = null, string? actividadNombre = null)
        {
            IdPago = pago.IdPago;
            ClienteNombreCompleto = clienteNombreCompleto ?? string.Empty;
            ClienteDni = clienteDni ?? string.Empty;
            ClienteNroCarnet = clienteNroCarnet;
            ActividadNombre = actividadNombre;
            MedioPago = pago.MedioPago;
            FechaPago = pago.FechaPago;
            Importe = pago.Importe;
        }
    }
}
