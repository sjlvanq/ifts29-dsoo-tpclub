using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlPagoDetalleInfo : UserControl, IControlDetalleInfo
    {
        private string sinSeleccionMsg = "Seleccione un pago\r\npara habilitar los botones\r\nde acción.\r\n";
        private Color sinSeleccionColorLbl = Color.Gray;
        private Color conSeleccionColorLbl = Color.LightGray;
        private Color conSeleccionColorLblNombre = Color.FromKnownColor(KnownColor.ControlLightLight);
        private Color conSeleccionColorLblHabilitado = Color.LightGreen;
        private Color conSeleccionColorLblInhabilitado = Color.Orange;
        public ControlPagoDetalleInfo()
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
            lblControlPagoDetalleInfoNombre.Text = record.ClienteNombreCompleto;
            lblControlPagoDetalleInfoHabilitado.Text = $"{(record.ClienteHabilitado ? "" : "No")} Habilitado";
            lblControlPagoDetalleInfoHabilitado.BackColor = record.ClienteHabilitado ? this.conSeleccionColorLblHabilitado : this.conSeleccionColorLblInhabilitado;
            lblControlPagoDetalleInfoIds.Text = $"Nro. Carnet: {record.ClienteNroCarnet}\nDNI: {record.ClienteDni}";
            lblControlPagoDetalleInfoIds.BackColor = this.conSeleccionColorLbl;
            lblControlPagoDetalleInfoNombre.Visible = true;
            lblControlPagoDetalleInfoHabilitado.Visible = true;
        }
        public void SetPago(PagoListDTO pago)
        {
            SetRecord(pago);
        }
        public void Clear()
        {
            lblControlPagoDetalleInfoNombre.Visible = false;
            lblControlPagoDetalleInfoHabilitado.Visible = false;
            lblControlPagoDetalleInfoIds.Text = this.sinSeleccionMsg;
            lblControlPagoDetalleInfoIds.BackColor = this.sinSeleccionColorLbl;

        }
    }
}
