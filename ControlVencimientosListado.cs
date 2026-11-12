using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Club1
{
    public partial class ControlVencimientosListado : UserControl
    {
        private readonly List<Vencimiento> vencimientos;
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

        public ControlVencimientosListado(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        /*
        public void AplicarFiltro(object? sender, FiltroChangedEventArgs e)
        {
            string texto = e.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrEmpty(e.Field))
            {
                MostrarPagos(todosLosPagos);
                return;
            }

            IEnumerable<PagoListDTO> resultado = e.Field switch
            {
                nameof(PagoListDTO.ClienteDni) => todosLosPagos.Where(p =>
                    p.ClienteDni.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                nameof(PagoListDTO.ClienteNroCarnet) => todosLosPagos.Where(p =>
                    p.ClienteNroCarnet.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                nameof(Pago.FechaPago) => todosLosPagos.Where(p =>
                    p.FechaPago.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                _ => todosLosPagos
            };

            MostrarPagos(resultado);
        }
        */

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
