using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Common;

namespace Club1.UI.Controls
{
    public partial class ControlClientesListado : UserControl
    {
        public event EventHandler<GenerarCarnetClickedEventArgs>? GenerarCarnetClicked;
        public event EventHandler<PagosHistorialRequestedEventArgs>? PagosHistorialRequested;
        private List<Socio> todosLosSocios = new();
        SocioRepo socioRepo;
        public ControlClientesListado()
        {
            InitializeComponent();
            this.socioRepo = new SocioRepo();
            todosLosSocios = socioRepo.obtenerTodos();

            MostrarSocios(todosLosSocios);

            this.dataGridClientesListadoLista.AutoGenerateColumns = true;
        }

        public void Recargar()
        {
            todosLosSocios = socioRepo.obtenerTodos();
            MostrarSocios(todosLosSocios);
        }

        public void AplicarFiltro(object? sender, FiltroChangedEventArgs e)
        {
            string texto = e.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrEmpty(e.Field))
            {
                MostrarSocios(todosLosSocios);
                return;
            }

            IEnumerable<Socio> resultado = e.Field switch
            {
                nameof(Socio.Dni) => todosLosSocios.Where(s =>
                    s.Dni.Contains(texto, StringComparison.OrdinalIgnoreCase)),

                nameof(Socio.Nombre) => todosLosSocios.Where(s =>
                    s.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)),

                nameof(Socio.Apellido) => todosLosSocios.Where(s =>
                    s.Apellido.Contains(texto, StringComparison.OrdinalIgnoreCase)),

                _ => todosLosSocios
            };

            MostrarSocios(resultado);
        }

        private void MostrarSocios(IEnumerable<Socio> socios)
        {
            socioBindingSource.DataSource = socios.ToList();
            if (socioBindingSource.Count == 0)
            {
                this.controlClientesDetalle1.MostrarDetalle(null);
            }
        }

        private void dataGridClientesListadoLista_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridClientesListadoLista.SelectedRows.Count == 0)
            {
                this.controlClientesDetalle1.MostrarDetalle(null);
                return;
            }
            this.controlClientesDetalle1.MostrarDetalle(dataGridClientesListadoLista.SelectedRows[0].DataBoundItem as Socio);
        }

        private void controlClientesDetalle1_PagosHistorialRequested(object sender, EventArgs e)
        {
            var clienteDni = this.dataGridClientesListadoLista.SelectedRows[0].DataBoundItem is Socio socio ? socio.Dni : "";

            PagosHistorialRequested?.Invoke(
                this,
                new PagosHistorialRequestedEventArgs(clienteDni));
        }
    }
}
