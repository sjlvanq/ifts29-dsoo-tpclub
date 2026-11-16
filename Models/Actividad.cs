using System;
using System.Collections.Generic;
using System.Text;

namespace Club1.Models
{
    public class Actividad
    {
        private int idActividad;
        public int IdActividad { get { return idActividad; } set { idActividad = value; } }

        private String nombre;
        public String Nombre { get { return nombre; } set { nombre = value; } }

        private Decimal precioDiario;
        public Decimal PrecioDiario { get { return precioDiario; } set { precioDiario = value; } }

        private DateTime fechaBaja;
        public DateTime FechaBaja { get { return fechaBaja; } set { fechaBaja = value; } }

        public Actividad(int idActividad, String nombre, Decimal precioDiario, DateTime fechaBaja)
        {
            this.idActividad = idActividad;
            this.nombre = nombre;
            this.precioDiario = precioDiario;
            this.fechaBaja = fechaBaja;
        }
    }
}