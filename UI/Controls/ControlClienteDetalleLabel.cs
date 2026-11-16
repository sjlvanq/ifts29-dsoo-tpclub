using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Controls
{
    public partial class ControlClienteDetalleLabel : Label, IControlDetalleInfo
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
        public void SetRecord(IControlListadoRecord record)
        {
            if (record == null)
            {
                this.Clear();
                return;
            }
            var socio = record as Socio;
            if (socio != null)
            {
                this.Text = $"DNI: {socio.Dni}\nNombre: {socio.Nombre}\nApellido: {socio.Apellido}\nTeléfono: {socio.Telefono}\nNro Carnet: {socio.NroCarnet}\nApto Físico: {(socio.TieneAptoFisico ? "Sí" : "No")}";
            }
            else
            {
                this.Text = $"Nombre: {record.ClienteNombreCompleto}\nNro Carnet: {record.ClienteNroCarnet}\nDNI: {record.ClienteDni}";
            }
            this.BackColor = this.conSeleccionColor;
        }
        public void SetSocio(Socio socio)
        {
            SetRecord(socio);
        }
        public void Clear()
        {
            this.Text = this.sinSeleccionMsg;
            this.BackColor = this.sinSeleccionColor;
        }
    }
}
