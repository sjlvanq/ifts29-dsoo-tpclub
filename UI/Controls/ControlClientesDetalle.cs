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

namespace Club1.UI.Controls
{
    public partial class ControlClientesDetalle : UserControl
    {

        public event EventHandler<PagosHistorialRequestedEventArgs>? PagosHistorialRequested;

        private Socio? socioActual;

        private String carnetTemplate;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public new bool Enabled
        {
            get;
            set
            {
                if (field == value)
                    return;

                field = value;
                btnPageClientesListadoDetalleGenerarCarnet.Enabled = value;
                btnPageClientesListadoDetalleEliminar.Enabled = value;
                btnPageClientesListadoDetalleConsultarPagos.Enabled = value;

                if (!value)
                    controlClienteDetalleInfo1.Clear();
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
            this.btnPageClientesListadoDetalleGenerarCarnet.Enabled = socio.ClienteEsSocio;
            controlClienteDetalleInfo1.SetSocio(socio);
        }

        public ControlClientesDetalle()
        {
            InitializeComponent();
            this.Enabled = false;
            this.carnetTemplate = Properties.Resources.carnet_svg.ToString();
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

        private void btnPageClientesListadoDetalleGenerarCarnet_Click(object sender, EventArgs e)
        {
            if (socioActual == null) { return; } // ¿Lanzar excepción? ¿Mostrar mensaje de error? ¿Ignorar?
            if (!socioActual.ClienteEsSocio) { return; }
            
            using FormCarnet carnetForm = new FormCarnet(socioActual);
            carnetForm.ShowDialog();
        }
    }
}
