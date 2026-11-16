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
    public partial class ControlActividadesListado : UserControl
    {
        private List<Actividad> todasLasActividades = new();

        private ActividadRepo actividadRepo;

        public ControlActividadesListado()
        {
            this.actividadRepo = new ActividadRepo();

            InitializeComponent();


            dataGridActividadesListadoLista.AutoGenerateColumns = true;
            todasLasActividades = actividadRepo.obtenerTodas();
            MostrarActividades(todasLasActividades);
        }

        public void Recargar()
        {
            todasLasActividades.Clear();
            todasLasActividades.AddRange(actividadRepo.obtenerTodas());
            MostrarActividades(todasLasActividades);
        }

        public void AplicarFiltro(object? sender, FiltroChangedEventArgs e)
        {
            string texto = e.Text.Trim();

            if (string.IsNullOrWhiteSpace(texto) || string.IsNullOrEmpty(e.Field))
            {
                MostrarActividades(todasLasActividades);
                return;
            }

            IEnumerable<Actividad> resultado = e.Field switch
            {
                nameof(Actividad.Nombre) => todasLasActividades.Where(s =>
                    s.Nombre.Contains(texto, StringComparison.OrdinalIgnoreCase)),

                nameof(Actividad.PrecioDiario) => todasLasActividades.Where(s =>
                    s.PrecioDiario.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                nameof(Actividad.FechaBaja) => todasLasActividades.Where(s =>
                    s.FechaBaja.ToString().Contains(texto, StringComparison.OrdinalIgnoreCase)),

                _ => todasLasActividades
            };

            MostrarActividades(resultado);
        }

        private void MostrarActividades(IEnumerable<Actividad> actividades)
        {
            dataGridActividadesListadoLista.DataSource = actividades.ToList();
        }

        private void dataGridClientesListadoLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridClientesListadoLista_SelectionChanged(object sender, EventArgs e)
        {
            if(dataGridActividadesListadoLista.SelectedRows.Count == 0)
            {
                //this.controlActividadesDetalle1.MostrarDetalle(null);
                return;
            }
            //this.controlActividadesDetalle1.MostrarDetalle(dataGridActividadesListadoLista.SelectedRows[0].DataBoundItem as Actividad);
        }
    }
}
