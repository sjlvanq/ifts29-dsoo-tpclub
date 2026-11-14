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

        public void MostrarDetalle(Actividad? actividad)
        {
            if (actividad == null)
            {
                this.Enabled = false;
                return;
            }
            this.Enabled = true;
        }

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
