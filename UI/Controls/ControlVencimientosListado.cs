using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Controls
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
        }

    }
}
