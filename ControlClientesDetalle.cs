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

        public event EventHandler<PagosHistorialRequestedEventArgs>? PagosHistorialRequested;

        private Socio? socioActual;

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

        public void MostrarDetalle(Socio? socio)
        {
            if (socio == null)
            {
                socioActual = null;
                this.Enabled = false;
                return;
            }
            socioActual = socio;
            this.Enabled = true;
            this.ControlClienteDetalleLabel1.SetSocio(socio);
        }

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
