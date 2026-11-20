using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using MySql.Data.MySqlClient;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Controls
{
    public partial class ControlPagosListado : UserControl
    {
        public event EventHandler<ProximoVencimientoRequestedEventArgrs>? ProximoVencimientoRequested;
        private List<PagoListDTO> todosLosPagos = new();
        private readonly PagoRepo pagoRepo = new();

        public ControlPagosListado()
        {
            InitializeComponent();
            this.controlPagoDetalle.AnularPagoRequested += controlPagoDetalle_AnularPagoRequested;
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
            todosLosPagos = pagoRepo.obtenerTodos();
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
                nameof(PagoListDTO.ClienteDni) => todosLosPagos.Where(p =>
                    p.ClienteDni.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),
                nameof(PagoListDTO.ClienteNroCarnet) => todosLosPagos.Where(p =>
                    (p.ClienteNroCarnet ?? string.Empty).Contains(texto, StringComparison.OrdinalIgnoreCase)),

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

        private void controlPagoDetalle_ProximoVencimientoRequested(
            object? sender,
            ProximoVencimientoRequestedEventArgrs e)
        {
            ProximoVencimientoRequested?.Invoke(this, e);
        }

        private void controlPagoDetalle_AnularPagoRequested(
            object? sender,
            PagoAnulacionRequestedEventArgs e)
        {
            try
            {
                pagoRepo.anular(e.IdPago, e.NotaAnulacion);
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    this,
                    $"No se pudo anular el pago.\n{ex.Message}",
                    "Error al anular pago",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            try
            {
                Recargar();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(
                    this,
                    $"El pago se anuló, pero no se pudo actualizar el listado.\n{ex.Message}",
                    "Error al actualizar pagos",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

    }
}
