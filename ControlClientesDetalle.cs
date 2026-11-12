using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlClientesDetalle : UserControl
    {
        //public event EventHandler? GenerarCarnetClicked;
        public event EventHandler<PagosHistorialRequestedEventArgs>? PagosHistorialRequested;

        //public event EventHandler<PagosHistorialRequestedEventArgs>? PagosHistorialRequested;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Enabled
        {
            get;
            set
            {
                if (field == value)
                    return;

                field = value;
                this.btnPageClientesListadoDetalleGenerarCarnet.Enabled = value;
                this.btnPageClientesListadoDetalleEliminar.Enabled = value;
                this.btnPageClientesListadoDetalleConsultarPagos.Enabled = value;

                if (!value)
                    this.ControlClienteDetalleLabel1.Clear();
            }
        }

        public void MostrarDetalle(Socio socio)
        {
            //MessageBox.Show("MostrarDetalle: " + (socio == null ? "null" : socio.Dni));
            if (socio == null)
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            //this.lblPageClientesListadoDetalleDetalle.Text = $"DNI: {socio.Dni}\nNombre: {socio.Nombre}\nApellido: {socio.Apellido}\nTeléfono: {socio.Telefono}\nNro Carnet: {socio.NroCarnet}\nApto Físico: {(socio.TieneAptoFisico ? "Sí" : "No")}";
            this.ControlClienteDetalleLabel1.SetSocio(socio);
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

        public ControlClientesDetalle()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        private void btnPageClientesListadoDetalleConsultarPagos_Click(object sender, PagosHistorialRequestedEventArgs e)
        {
            PagosHistorialRequested?.Invoke(this, new PagosHistorialRequestedEventArgs(""));

        }

        private void btnPageClientesListadoDetalleGenerarCarnet_Click(object sender, GenerarCarnetClickedEventArgs e)
        {
            //GenerarCarnetClicked?.Invoke(this, GenerarCarnetClickedEventArgs.Empty);
        }

        private void btnPageClientesListadoDetalleConsultarPagos_Click(object sender, EventArgs e)
        {
            PagosHistorialRequested?.Invoke(this, new PagosHistorialRequestedEventArgs(""));
        }
    }
}
