using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlPagosDetalle : UserControl
    {
        public event EventHandler<ProximoVencimientoRequestedEventArgrs>? ProximoVencimientoRequested;

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
                this.btnPagePagosListadoDetalleEliminar.Enabled = value;
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
            //this.lblPagePagosListadoDetalleDetalle.Text = $"DNI: {pago.Dni}\nNombre: {pago.Nombre}\nApellido: {pago.Apellido}\nTeléfono: {pago.Telefono}\nNro Carnet: {pago.NroCarnet}\nApto Físico: {(pago.TieneAptoFisico ? "Sí" : "No")}";
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
    }
}
