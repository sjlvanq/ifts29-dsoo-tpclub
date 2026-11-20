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
    public record FiltroField(string Valor, string Texto);

    public partial class ControlFiltros : UserControl
    {
        public event EventHandler<FiltroChangedEventArgs>? FiltroChanged;

        public ControlFiltros()
        {
            InitializeComponent();

            txtControlFiltrosSearch.TextChanged += (_, _) => EmitirFiltro();
        }

        private void cmbControlFiltrosField_SelectedIndexChanged(object sender, EventArgs e)
        {
            EmitirFiltro();
            EnableFiltros(cmbControlFiltrosField.SelectedIndex != 0);
        }

        private void EnableFiltros(bool enabled)
        {
            if (!enabled)
            {
                txtControlFiltrosSearch.Text = "";
                cmbControlFiltrosField.SelectedIndex = 0;
            }
            txtControlFiltrosSearch.Enabled = enabled;
            if (enabled)
            {
                txtControlFiltrosSearch.Focus();
            }
            lnkLblControlFiltrosLimpiar.Visible = enabled;
        }

        private void EmitirFiltro()
        {
            var campo = cmbControlFiltrosField.SelectedValue?.ToString() ?? "";

            FiltroChanged?.Invoke(
                this,
                new FiltroChangedEventArgs(campo, txtControlFiltrosSearch.Text));

        }

        public void ConfigurarCampos(IEnumerable<FiltroField> campos)
        {
            cmbControlFiltrosField.DataSource = campos.ToList();
            cmbControlFiltrosField.DisplayMember = nameof(FiltroField.Texto);
            cmbControlFiltrosField.ValueMember = nameof(FiltroField.Valor);

            if (cmbControlFiltrosField.Items.Count > 0)
                cmbControlFiltrosField.SelectedIndex = 0;
        }

        public void SetFiltro(string campo, string texto)
        {
            cmbControlFiltrosField.SelectedValue = campo;
            txtControlFiltrosSearch.Text = texto;
        }

        private void lnkLblControlFiltrosLimpiar_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            EnableFiltros(false);
            EmitirFiltro();
        }
    }
}
