using System;

namespace Club1
{
    public class Vencimiento : IControlListadoRecord
    {

        private String clienteNroCarnet;
        public String ClienteNroCarnet { get { return clienteNroCarnet; } set { clienteNroCarnet = value; } }
        private String clienteDni;
        public String ClienteDni { get { return clienteDni; } set { clienteDni = value; } }
        private String clienteNombreCompleto;
        public String ClienteNombreCompleto { get { return clienteNombreCompleto; } set { clienteNombreCompleto = value; } }
        private String clienteTelefono;
        public String ClienteTelefono { get { return clienteTelefono; } set { clienteTelefono = value; } }
        private String planNombre;
        public String PlanNombre { get { return planNombre; } set { planNombre = value; } }
        private int cuotaNroCuota;
        public int CuotaNroCuota { get { return cuotaNroCuota; } set { cuotaNroCuota = value; } }
        private int cuotaTotalCuotas;
        public int CuotaTotalCuotas { get { return cuotaTotalCuotas; } set { cuotaTotalCuotas = value; } }
        private DateTime cuotaFechaVencimiento;
        public DateTime CuotaFechaVencimiento { get { return cuotaFechaVencimiento; } set { cuotaFechaVencimiento = value; } }
        private bool tieneCuotaSiguiente;
        public bool TieneCuotaSiguiente { get { return tieneCuotaSiguiente; } set { tieneCuotaSiguiente = value; } }
        private decimal? cuotaImporteSiguiente;
        public decimal? CuotaImporteSiguiente { get { return cuotaImporteSiguiente; } set { cuotaImporteSiguiente = value; } }

        // Implementación de IControlListadoRecord

        public bool ClienteEsSocio => true;
        public bool ClienteHabilitado => true;
        
        public Vencimiento(
            String clienteNroCarnet,
            String clienteNombreCompleto,
            String clienteTelefono,
            String planNombre,
            int cuotaNroCuota,
            int cuotaTotalCuotas,
            DateTime cuotaFechaVencimiento,
            bool tieneCuotaSiguiente,
            decimal? cuotaImporteSiguiente,
            String clienteDni = "")
        {
            this.clienteNroCarnet = clienteNroCarnet;
            this.clienteDni = clienteDni;
            this.clienteNombreCompleto = clienteNombreCompleto;
            this.clienteTelefono = clienteTelefono;
            this.planNombre = planNombre;
            this.cuotaNroCuota = cuotaNroCuota;
            this.cuotaTotalCuotas = cuotaTotalCuotas;
            this.cuotaFechaVencimiento = cuotaFechaVencimiento;
            this.tieneCuotaSiguiente = tieneCuotaSiguiente;
            this.cuotaImporteSiguiente = cuotaImporteSiguiente;
        }
    }
}
