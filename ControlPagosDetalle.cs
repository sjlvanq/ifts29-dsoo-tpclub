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
                    this.controlPagoDetalleInfo.Clear();
            }
        }

        public void MostrarDetalle(PagoListDTO? pago)
        {
            //MessageBox.Show("MostrarDetalle: " + (pago == null ? "null" : pago.Dni));
            if (pago == null)
            {
                pagoActual = null;
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            pagoActual = pago;
            //this.lblPagePagosListadoDetalleDetalle.Text = $"DNI: {pago.Dni}\nNombre: {pago.Nombre}\nApellido: {pago.Apellido}\nTeléfono: {pago.Telefono}\nNro Carnet: {pago.NroCarnet}\nApto Físico: {(pago.TieneAptoFisico ? "Sí" : "No")}";
            this.controlPagoDetalleInfo.SetPago(pago);
        }

        public ControlPagosDetalle()
        {
            InitializeComponent();
            this.Enabled = false;
        }
    }
}
