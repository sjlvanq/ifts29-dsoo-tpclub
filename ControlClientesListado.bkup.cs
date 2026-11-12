using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlClientesListadoBkUp : UserControl
    {
        private readonly List<Socio> todosLosSocios;
        SocioRepo socioRepo;
        public ControlClientesListadoBkUp()
        {
            InitializeComponent();
            this.socioRepo = new SocioRepo();
            todosLosSocios = socioRepo.obtenerTodos();

            MostrarSocios(todosLosSocios);

            //this.dataGridClientesListadoLista.AutoGenerateColumns = true;
            //this.dataGridClientesListadoLista.DataSource = socioRepo.obtenerTodos();
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
        }

        private void dataGridClientesListadoLista_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridClientesListadoLista.SelectedRows.Count == 0)
            {
                this.controlClientesDetalle1.MostrarDetalle(null);
                return;
            }
            this.controlClientesDetalle1.MostrarDetalle(dataGridClientesListadoLista.SelectedRows[0].DataBoundItem as Socio);
        }
    }
}
