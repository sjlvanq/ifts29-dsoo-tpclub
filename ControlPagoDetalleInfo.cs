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
        private static readonly Image? imgCarnet = Properties.Resources.es_socio;

        public ControlPagoDetalleInfo()
        {
            InitializeComponent();

            ComponentResourceManager resources = new ComponentResourceManager(typeof(ControlPagoDetalleInfo));
            lblControlPagoDetalleInfoNombre.ImageAlign = ContentAlignment.TopRight;
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
            lblControlPagoDetalleInfoHabilitado.Text = 
                record.ClienteEsSocio ? 
                    record.ClienteHabilitado ? "Socio sin deuda" : "Socio con deuda" : "No es socio";
            lblControlPagoDetalleInfoHabilitado.BackColor = 
                record.ClienteEsSocio ? 
                    record.ClienteHabilitado ? conSeleccionColorLblHabilitado : conSeleccionColorLblInhabilitado : sinSeleccionColorLbl;
            lblControlPagoDetalleInfoIds.Text = $"Nro. Carnet: {record.ClienteNroCarnet}\nDNI: {record.ClienteDni}";
            lblControlPagoDetalleInfoIds.BackColor = this.conSeleccionColorLbl;
            lblControlPagoDetalleInfoNombre.Visible = true;
            lblControlPagoDetalleInfoHabilitado.Visible = true;

            if (record is PagoListDTO pago)
            {
                var clienteEsSocio = pago.ClienteEsSocio;
                lblControlPagoDetalleInfoNombre.Image = clienteEsSocio ? imgCarnet : null;
                lblControlPagoDetalleInfoIds.Text += pago.Anulado
                    ? $"\n\nEstado del pago: Anulado\nCausa: {pago.NotaAnulacion ?? "Sin causa registrada"}"
                    : "\n\nEstado del pago: Vigente";
            }
            else
            {
                // Defensivo por si se pasa un registro que no es Socio, aunque debería serlo
                lblControlPagoDetalleInfoNombre.Image = null;
            }
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
