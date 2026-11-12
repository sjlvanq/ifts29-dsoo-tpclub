using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Club1
{
    public class ViewSwitcherClientes : ViewSwitcher
    {
        public event EventHandler<PagosHistorialRequestedEventArgs>? PagosHistorialRequested;

        public ViewSwitcherClientes()
        {
            View1.ControlAdded += View1_ControlAdded;
        }

        public ViewSwitcherClientes(IContainer container) : base(container)
        {
            View1.ControlAdded += View1_ControlAdded;
        }

        private void View1_ControlAdded(object? sender, ControlEventArgs e)
        {
            if (e.Control is ControlClientesListado controlClientesListado)
            {
                controlClientesListado.PagosHistorialRequested += ControlClientesListado_PagosHistorialRequested;
            }
        }

        private void ControlClientesListado_PagosHistorialRequested(object? sender, PagosHistorialRequestedEventArgs e)
        {
            PagosHistorialRequested?.Invoke(this, e);
        }
    }
}
