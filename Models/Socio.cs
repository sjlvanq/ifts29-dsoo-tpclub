using System;

namespace Club1.Models
{
    public class Socio : IControlListadoRecord
    {
        private int idCliente;
        public int IdCliente { get { return idCliente; } set { idCliente = value; } }
        private String dni;
        public String Dni { get { return dni; } set { dni = value;  } }
        private String nombre;
        public String Nombre { get { return nombre; } set { nombre = value; } }
        private String apellido;
        public String Apellido { get { return apellido; } set { apellido = value;  } }
        private String telefono;
        public String Telefono { get { return telefono; } set { telefono = value;  } }
        private int nroCarnet;
        public int NroCarnet { get { return nroCarnet; } set { nroCarnet = value;  } }
        private bool tieneAptoFisico;
        public bool TieneAptoFisico { get { return tieneAptoFisico; } set { tieneAptoFisico = value; } }
        private bool esSocio;
        public bool ClienteEsSocio { get { return esSocio; } set { esSocio = value; } }

        // Implementación de IControlListadoRecord
        public string ClienteNombreCompleto => $"{nombre} {apellido}";
        public bool ClienteHabilitado => TieneAptoFisico;
        public string ClienteNroCarnet => nroCarnet.ToString();
        public string ClienteDni => dni;

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
        public bool getTieneAptoFisico() { return tieneAptoFisico; }
    }
}
