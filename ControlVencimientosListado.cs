using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Club1
{
    public partial class ControlVencimientosListado : UserControl
    {
        private List<Vencimiento> vencimientos = new();
        private readonly VencimientoRepo vencimientoRepo;
        private readonly String encabezadoMsg = $"Vencimientos Hoy ({DateTime.Today:dd/MM/yyyy})";
        public ControlVencimientosListado()
        {
            InitializeComponent();
            this.lblControlVencimientoListadoHeader.Text = encabezadoMsg;
            this.vencimientoRepo = new VencimientoRepo();
            this.vencimientos = vencimientoRepo.obtenerVencimientos();

            MostrarVencimientos(this.vencimientos);

            this.dataGridVencimientosListadoLista.AutoGenerateColumns = true;
        }

        public void Recargar()
        {
            vencimientos.Clear();
            vencimientos.AddRange(vencimientoRepo.obtenerVencimientos());
            MostrarVencimientos(vencimientos);
        }

        private void MostrarVencimientos(IEnumerable<Vencimiento> vencimientos)
        {
            vencimientoBindingSource.DataSource = vencimientos.ToList();
            if (vencimientoBindingSource.Count == 0)
            {
                //this.controlVencimientosDetalle.MostrarDetalle(null);
            }
        }

        private void dataGridVencimientosListadoLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridVencimientosListadoLista.SelectedRows.Count == 0)
            {
                //this.controlVencimientoDetalle.MostrarDetalle(null);
                return;
            }
            //this.controlVencimientoDetalle.MostrarDetalle(dataGridVencimientosListadoLista.SelectedRows[0].DataBoundItem as PagoListDTO);
        }

    }
}
