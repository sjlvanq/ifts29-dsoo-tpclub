using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlClienteDetalleLabel : Label
    {
        private string sinSeleccionMsg = "Seleccione un cliente\r\npara habilitar los botones\r\nde acción.\r\n";
        private Color sinSeleccionColor = Color.Gray;
        private Color conSeleccionColor = Color.LightGray;
        public ControlClienteDetalleLabel()
        {
            InitializeComponent();
            this.Text = this.sinSeleccionMsg;
            this.BackColor = this.sinSeleccionColor;
            
        }
        public void SetSocio(Socio socio)
        {
            if (socio == null)
            {
                this.Clear();
                return;
            }
            this.Text = $"DNI: {socio.Dni}\nNombre: {socio.Nombre}\nApellido: {socio.Apellido}\nTeléfono: {socio.Telefono}\nNro Carnet: {socio.NroCarnet}\nApto Físico: {(socio.TieneAptoFisico ? "Sí" : "No")}";
            this.BackColor = this.conSeleccionColor;
        }
        public void Clear()
        {
            this.Text = this.sinSeleccionMsg;
            this.BackColor = this.sinSeleccionColor;
        }
    }
}
