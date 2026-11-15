using System;
using System.Collections.Generic;
using System.Text;

namespace Club1
{
    public class Actividad : IControlListadoRecord
    {
        private String nombre;
        public String Nombre { get { return nombre; } set { nombre = value; } }

        private Decimal precioDiario;
        public Decimal PrecioDiario { get { return precioDiario; } set { precioDiario = value; } }

        private DateTime fechaBaja;
        public DateTime FechaBaja { get { return fechaBaja; } set { fechaBaja = value; } }

        // Implementación de IControlListadoRecord
        public string ClienteNombreCompleto => nombre;
        public bool ClienteHabilitado => FechaBaja > DateTime.Now;
        public string ClienteNroCarnet => string.Empty;
        public string ClienteDni => string.Empty;

        public Actividad(String nombre, Decimal precioDiario, DateTime fechaBaja)
        {
            this.nombre = nombre;
            this.precioDiario = precioDiario;
            this.fechaBaja = fechaBaja;
        }
    }
}