using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Club1
{
    public partial class ViewSwitcher : UserControl
    {
        private bool _showFiltersOnDefaultView = true;

        public void ConfigureFiltersOnDefaultView(bool visible)
        {
            _showFiltersOnDefaultView = visible;
            ResetView();
        }
        public event EventHandler<FiltroChangedEventArgs>? FiltroChanged;

        public ViewSwitcher()
        {
            InitializeComponent();
            controlFiltros.FiltroChanged += ControlFiltros_FiltroChanged;
        }

        public ViewSwitcher(IContainer container) : this()
        {
            container.Add(this);
        }

        public Panel View1 => panelView1;
        public Panel View2 => panelView2;
        public Button View2Button => btnShowView2;
        public LinkLabel View1Link => lnkLblBack;
        public ControlFiltros Filtros => controlFiltros;

        public void ResetView()
        {
            panelView1.Visible = true;
            panelView2.Visible = false;
            btnShowView2.Visible = true;
            lnkLblBack.Visible = false;
            controlFiltros.Visible = _showFiltersOnDefaultView;
        }

        private void btnShowView2_Click(object? sender, EventArgs e)
        {
            panelView1.Visible = false;
            panelView2.Visible = true;
            btnShowView2.Visible = false;
            lnkLblBack.Visible = true;
            controlFiltros.Visible = false;
        }

        private void lnkLblBack_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
        {
            ResetView();
        }

        private void ControlFiltros_FiltroChanged(object? sender, FiltroChangedEventArgs e)
        {
            FiltroChanged?.Invoke(this, e);
        }
    }
}
