using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;

namespace Club1
{
    public partial class ControlPagosListado : UserControl
    {
        private List<PagoListDTO> todosLosPagos = new();
        private PagoRepo pagoRepo;

        public ControlPagosListado()
        {
            InitializeComponent();
            this.pagoRepo = new PagoRepo();
            todosLosPagos = pagoRepo.obtenerTodos();

            MostrarPagos(todosLosPagos);

            this.dataGridPagosListadoLista.AutoGenerateColumns = true;
        }

        public ControlPagosListado(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public void Recargar()
        {
            todosLosPagos.Clear();
            todosLosPagos.AddRange(pagoRepo.obtenerTodos());
            MostrarPagos(todosLosPagos);
        }

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
                /*
                nameof(PagoListDTO.IdCuota) => todosLosPagos.Where(p =>
                    p.IdCuota.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),
                */

                nameof(PagoListDTO.ClienteDni) => todosLosPagos.Where(p =>
                    p.ClienteDni.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),
                
                nameof(PagoListDTO.ClienteNroCarnet) => todosLosPagos.Where(p =>
                    (p.ClienteNroCarnet ?? string.Empty).Contains(texto, StringComparison.OrdinalIgnoreCase)),
                
                    /*
                                nameof(Pago.Cliente.Nombre) => todosLosPagos.Where(p =>
                                    p.CienteNombre.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                                nameof(Pago.Cliente.Apellido) => todosLosPagos.Where(p =>
                                    p.CienteNombre.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),
                    */

                nameof(Pago.FechaPago) => todosLosPagos.Where(p =>
                    p.FechaPago.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                _ => todosLosPagos
            };

            MostrarPagos(resultado);
        }

        private void MostrarPagos(IEnumerable<PagoListDTO> pagos)
        {
            pagoBindingSource.DataSource = pagos.ToList();
            if (pagoBindingSource.Count == 0)
            {
                this.controlPagoDetalle.MostrarDetalle(null);
            }
        }

        private void dataGridPagosListadoLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridPagosListadoLista.SelectedRows.Count == 0)
            {
                this.controlPagoDetalle.MostrarDetalle(null);
                return;
            }
            this.controlPagoDetalle.MostrarDetalle(dataGridPagosListadoLista.SelectedRows[0].DataBoundItem as PagoListDTO);
        }

    }
}
