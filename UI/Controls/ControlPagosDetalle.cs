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
using Club1.UI.Forms;

namespace Club1.UI.Controls
{
    public partial class ControlPagosDetalle : UserControl
    {
        public event EventHandler<ProximoVencimientoRequestedEventArgrs>? ProximoVencimientoRequested;
        public event EventHandler<PagoAnulacionRequestedEventArgs>? AnularPagoRequested;

        private PagoListDTO? pagoActual;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Enabled
        {
            get;
            set
            {
                if (field == value)
                    return;

                field = value;
                this.btnPagePagosListadoDetalleGenerarComprobante.Enabled = value;
                this.btnPagePagosListadoDetalleAnular.Enabled = value;
                this.btnPagePagosListadoDetalleConsultarProximoVencimiento.Enabled = value;

                if (!value)
                    this.controlPagoDetalleInfo1.Clear();
            }
        }

        public void MostrarDetalle(PagoListDTO? pago)
        {
            if (pago == null)
            {
                pagoActual = null;
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            pagoActual = pago;
            this.btnPagePagosListadoDetalleGenerarComprobante.Enabled = !pago.Anulado;
            this.btnPagePagosListadoDetalleAnular.Enabled = !pago.Anulado;
            this.btnPagePagosListadoDetalleConsultarProximoVencimiento.Enabled = pago.ClienteEsSocio;
            this.controlPagoDetalleInfo1.SetPago(pago);
        }

        public ControlPagosDetalle()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        private void btnPagePagosListadoDetalleGenerarComprobante_Click(object sender, EventArgs e)
        {
            if (pagoActual == null)
                return;

            FormComprobantePago formComprobantePago = new FormComprobantePago(pagoActual);
            formComprobantePago.ShowDialog();
        }

        private void btnPagePagosListadoDetalleConsultarProximoVencimiento_Click(object sender, EventArgs e)
        {
            if (pagoActual == null)
                return;

            ProximoVencimientoRequested?.Invoke(
                this,
                new ProximoVencimientoRequestedEventArgrs(pagoActual.ClienteDni));
        }

        private void btnPagePagosListadoDetalleAnular_Click(object sender, EventArgs e)
        {
            if (pagoActual == null || pagoActual.Anulado)
                return;

            string? notaAnulacion = SolicitarNotaAnulacion();
            if (notaAnulacion == null)
                return;

            DialogResult confirmacion = MessageBox.Show(
                this,
                $"¿Confirma la anulación del pago {pagoActual.IdPago}?\n\nCausa: {notaAnulacion}",
                "Confirmar anulación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirmacion == DialogResult.Yes)
            {
                AnularPagoRequested?.Invoke(
                    this,
                    new PagoAnulacionRequestedEventArgs(pagoActual.IdPago, notaAnulacion));
            }
        }

        private string? SolicitarNotaAnulacion()
        {
            using Form dialogo = new()
            {
                Text = "Causa de anulación",
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false,
                ShowInTaskbar = false,
                ClientSize = new Size(420, 180)
            };

            Label etiqueta = new()
            {
                AutoSize = true,
                Location = new Point(12, 12),
                Text = "Describa la causa (obligatoria, máximo 200 caracteres):"
            };
            TextBox texto = new()
            {
                Location = new Point(12, 38),
                Size = new Size(396, 82),
                Multiline = true,
                MaxLength = 200,
                ScrollBars = ScrollBars.Vertical
            };
            Button aceptar = new()
            {
                Text = "Anular",
                Location = new Point(228, 134),
                Size = new Size(85, 32)
            };
            Button cancelar = new()
            {
                Text = "Cancelar",
                Location = new Point(323, 134),
                Size = new Size(85, 32),
                DialogResult = DialogResult.Cancel
            };

            aceptar.Click += (_, _) =>
            {
                if (string.IsNullOrWhiteSpace(texto.Text))
                {
                    MessageBox.Show(
                        dialogo,
                        "Debe indicar la causa de anulación.",
                        "Dato obligatorio",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    texto.Focus();
                    return;
                }

                dialogo.DialogResult = DialogResult.OK;
                dialogo.Close();
            };

            dialogo.Controls.Add(etiqueta);
            dialogo.Controls.Add(texto);
            dialogo.Controls.Add(aceptar);
            dialogo.Controls.Add(cancelar);
            dialogo.AcceptButton = aceptar;
            dialogo.CancelButton = cancelar;

            return dialogo.ShowDialog(this) == DialogResult.OK
                ? texto.Text.Trim()
                : null;
        }
    }
}
