using System;
using System.Collections.Generic;
using System.Text;

namespace Club1
{
    public class Actividad
    {
        private String nombre;
        public String Nombre { get { return nombre; } set { nombre = value; } }

        private Decimal precioDiario;
        public Decimal PrecioDiario { get { return precioDiario; } set { precioDiario = value; } }

        private DateTime fechaBaja;
        public DateTime FechaBaja { get { return fechaBaja; } set { fechaBaja = value; } }

        public Actividad(String nombre, Decimal precioDiario, DateTime fechaBaja)
        {
            this.nombre = nombre;
            this.precioDiario = precioDiario;
            this.fechaBaja = fechaBaja;
        }
    }
}