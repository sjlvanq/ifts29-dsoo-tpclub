using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlClienteDetalleInfo : UserControl, IControlDetalleInfo
    {
        private string sinSeleccionMsg = "Seleccione un registro\r\npara habilitar los botones\r\nde acción.\r\n";
        private Color sinSeleccionColorLbl = Color.Gray;
        private Color conSeleccionColorLbl = Color.LightGray;
        private Color conSeleccionColorLblNombre = Color.FromKnownColor(KnownColor.ControlLightLight);
        private Color conSeleccionColorLblHabilitado = Color.LightGreen;
        private Color conSeleccionColorLblInhabilitado = Color.Orange;
        public ControlClienteDetalleInfo()
        {
            InitializeComponent();
            Clear();

        }
        public void SetRecord(IControlListadoRecord record)
        {
            if (record == null)
            {
                this.Clear();
                return;
            }
            lblControlClienteDetalleInfoNombre.Text = record.ClienteNombreCompleto;
            lblControlClienteDetalleInfoHabilitado.Text = $"{(record.ClienteHabilitado ? "" : "Sin")} Apto físico";
            lblControlClienteDetalleInfoHabilitado.BackColor = record.ClienteHabilitado ? this.conSeleccionColorLblHabilitado : this.conSeleccionColorLblInhabilitado;
            if (record is Socio socio)
                lblControlClienteDetalleInfoIds.Text = $"DNI: {record.ClienteDni}\nTeléfono: {socio.Telefono}" + (socio.EsSocio ? $"\nNro Carnet: {record.ClienteNroCarnet}" : "");
            else
                // Defensivo por si se pasa un registro que no es Socio, aunque debería serlo
                lblControlClienteDetalleInfoIds.Text = $"DNI: {record.ClienteDni}\nNro Carnet: {record.ClienteNroCarnet}";
            lblControlClienteDetalleInfoIds.BackColor = this.conSeleccionColorLbl;
            lblControlClienteDetalleInfoNombre.Visible = true;
            lblControlClienteDetalleInfoHabilitado.Visible = true;
        }
        public void SetSocio(Socio socio)
        {
            SetRecord(socio);
        }
        public void Clear()
        {
            lblControlClienteDetalleInfoNombre.Visible = false;
            lblControlClienteDetalleInfoHabilitado.Visible = false;
            lblControlClienteDetalleInfoIds.Text = this.sinSeleccionMsg;
            lblControlClienteDetalleInfoIds.BackColor = this.sinSeleccionColorLbl;

        }
    }
}
