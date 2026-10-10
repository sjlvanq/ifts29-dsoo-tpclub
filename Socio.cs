using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Club1
{
    public class Socio
    {
        private String dni;
        private String nombre;
        private String apellido;
        private String telefono;
        private int nroCarnet;
        private bool esActivo;
        private bool tieneAptoFisico;

        // Constructor para registro
        public Socio(String dni, String nombre, String apellido, String telefono)
        {
            if (string.IsNullOrEmpty(dni) || string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                throw new ArgumentException("DNI, Nombre y Apellido son obligatorios.");
            }

            this.dni = dni;
            this.nombre = nombre;
            this.apellido = apellido;
            this.telefono = telefono;
        }

        public String getDni() { return dni; }
        public String getNombre() { return nombre; }
        public String getApellido() { return apellido; }
        public String getTelefono() { return telefono; }
        public int getNroCarnet() { return nroCarnet; }
        public bool getEsActivo() { return esActivo; }
        public bool getTieneAptoFisico() { return tieneAptoFisico; }
    }
}
