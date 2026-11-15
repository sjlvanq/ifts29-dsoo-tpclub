using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Club1
{
    public class ViewSwitcherPagos : ViewSwitcher
    {
        public event EventHandler<ProximoVencimientoRequestedEventArgrs>? ProximoVencimientoRequested;

        public ViewSwitcherPagos()
        {
            View1.ControlAdded += View1_ControlAdded;
        }

        public ViewSwitcherPagos(IContainer container) : base(container)
        {
            View1.ControlAdded += View1_ControlAdded;
        }

        private void View1_ControlAdded(object? sender, ControlEventArgs e)
        {
            if (e.Control is ControlPagosListado controlPagosListado)
            {
                controlPagosListado.ProximoVencimientoRequested += ControlPagosListado_ProximoVencimientoRequested;
            }
        }

        private void ControlPagosListado_ProximoVencimientoRequested(
            object? sender,
            ProximoVencimientoRequestedEventArgrs e)
        {
            ProximoVencimientoRequested?.Invoke(this, e);
        }
    }
}
