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

        
        public void MostrarDetalle(PagoListDTO pago)
        {
            //MessageBox.Show("MostrarDetalle: " + (pago == null ? "null" : pago.Dni));
            if (pago == null)
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            //this.lblPagePagosListadoDetalleDetalle.Text = $"DNI: {pago.Dni}\nNombre: {pago.Nombre}\nApellido: {pago.Apellido}\nTeléfono: {pago.Telefono}\nNro Carnet: {pago.NroCarnet}\nApto Físico: {(pago.TieneAptoFisico ? "Sí" : "No")}";
            this.controlPagoDetalleInfo.SetPago(pago);
        }
        

        /*
        public void mostrarDetalle(Socio socio)
        {
            this.btnPageClientesListadoDetalleCobrar.Enabled = true;
            this.btnPageClientesListadoDetalleEliminar.Enabled = true;
            this.btnPageClientesListadoDetalleGenerarCarnet.Enabled = true;
            this.lblPageClientesListadoDetalleSinSeleccion.Visible = false;
            this.lblPageClientesListadoDetalleDetalle.Visible = true;
            this.lblPageClientesListadoDetalleDni.Text = socio.Dni;
            this.lblPageClientesListadoDetalleNombre.Text = socio.Nombre;
            this.lblPageClientesListadoDetalleApellido.Text = socio.Apellido;
            this.lblPageClientesListadoDetalleTelefono.Text = socio.Telefono;
            this.lblPageClientesListadoDetalleNroCarnet.Text = socio.NroCarnet.ToString();
            this.lblPageClientesListadoDetalleAptoFisico.Text = socio.TieneAptoFisico ? "Sí" : "No";
        }
        */

        public ControlPagosDetalle()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        private void lblPagePagosListadoDetalleSinSeleccion_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnPagePagosListadoDetalleGenerarCarnet_Click(object sender, EventArgs e)
        {

        }
    }
}
