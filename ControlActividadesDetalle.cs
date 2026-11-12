using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlActividadesDetalle : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Enabled
        {
            get;
            set
            {
                field = value;
                this.btnPageClientesListadoDetalleEliminar.Enabled = value;
            }
        }

        public void MostrarDetalle(Actividad actividad)
        {
            //MessageBox.Show("MostrarDetalle: " + (actividad == null ? "null" : actividad.Nombre));
            if (actividad == null)
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
            //this.lblPageClientesListadoDetalleDetalle.Text = $"DNI: {socio.Dni}\nNombre: {socio.Nombre}\nApellido: {socio.Apellido}\nTeléfono: {socio.Telefono}\nNro Carnet: {socio.NroCarnet}\nApto Físico: {(socio.TieneAptoFisico ? "Sí" : "No")}";
            //this.ControlClienteDetalleLabel1.SetActividad(actividad);
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

        public ControlActividadesDetalle()
        {
            InitializeComponent();
            this.Enabled = false;
        }

        private void lblPageClientesListadoDetalleSinSeleccion_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ControlClienteDetalleLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
