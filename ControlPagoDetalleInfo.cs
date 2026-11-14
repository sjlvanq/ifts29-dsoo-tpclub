using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlPagoDetalleInfo : UserControl
    {
        private string sinSeleccionMsg = "Seleccione un pago\r\npara habilitar los botones\r\nde acción.\r\n";
        private Color sinSeleccionColorLbl = Color.Gray;
        private Color conSeleccionColorLbl = Color.LightGray;
        private Color conSeleccionColorLblNombre = Color.FromKnownColor(KnownColor.ControlLightLight);
        private Color conSeleccionColorLblHabilitado = Color.LightGreen;
        private Color conSeleccionColorLblInhabilitado = Color.Orange;
        public ControlPagoDetalleInfo()
        {
            InitializeComponent();
            Clear();

        }
        public void SetPago(PagoListDTO pago)
        {
            if (pago == null)
            {
                this.Clear();
                return;
            }
            lblControlPagoDetalleInfoNombre.Text = pago.ClienteNombreCompleto;
            lblControlPagoDetalleInfoHabilitado.Text = $"{(pago.ClienteHabilitado ? "" : "No")} Habilitado";
            lblControlPagoDetalleInfoHabilitado.BackColor = pago.ClienteHabilitado ? this.conSeleccionColorLblHabilitado : this.conSeleccionColorLblInhabilitado;
            lblControlPagoDetalleInfoIds.Text = $"Nro. Carnet: {pago.ClienteNroCarnet}\nDNI: {pago.ClienteDni}";
            lblControlPagoDetalleInfoIds.BackColor = this.conSeleccionColorLbl;
            lblControlPagoDetalleInfoNombre.Visible = true;
            lblControlPagoDetalleInfoHabilitado.Visible = true;
        }
        public void Clear()
        {
            lblControlPagoDetalleInfoNombre.Visible = false;
            lblControlPagoDetalleInfoHabilitado.Visible = false;
            lblControlPagoDetalleInfoIds.Text = this.sinSeleccionMsg;
            lblControlPagoDetalleInfoIds.BackColor = this.sinSeleccionColorLbl;

        }

        private TableLayoutPanel panelControlPagoDetalleInfo = null!;
        private Label lblControlPagoDetalleInfoNombre = null!;

        private void InitializeComponent()
        {
            panelControlPagoDetalleInfo = new TableLayoutPanel();
            lblControlPagoDetalleInfoNombre = new Label();
            lblControlPagoDetalleInfoHabilitado = new Label();
            lblControlPagoDetalleInfoIds = new Label();
            panelControlPagoDetalleInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelControlPagoDetalleInfo
            // 
            panelControlPagoDetalleInfo.ColumnCount = 1;
            panelControlPagoDetalleInfo.ColumnStyles.Add(new ColumnStyle());
            panelControlPagoDetalleInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panelControlPagoDetalleInfo.Controls.Add(lblControlPagoDetalleInfoNombre, 0, 0);
            panelControlPagoDetalleInfo.Controls.Add(lblControlPagoDetalleInfoHabilitado, 0, 1);
            panelControlPagoDetalleInfo.Controls.Add(lblControlPagoDetalleInfoIds, 0, 2);
            panelControlPagoDetalleInfo.Dock = DockStyle.Fill;
            panelControlPagoDetalleInfo.Location = new Point(0, 0);
            panelControlPagoDetalleInfo.Name = "panelControlPagoDetalleInfo";
            panelControlPagoDetalleInfo.RowCount = 3;
            panelControlPagoDetalleInfo.RowStyles.Add(new RowStyle());
            panelControlPagoDetalleInfo.RowStyles.Add(new RowStyle());
            panelControlPagoDetalleInfo.RowStyles.Add(new RowStyle());
            panelControlPagoDetalleInfo.Size = new Size(384, 432);
            panelControlPagoDetalleInfo.TabIndex = 0;
            // 
            // lblControlPagoDetalleInfoNombre
            // 
            lblControlPagoDetalleInfoNombre.AutoSize = true;
            lblControlPagoDetalleInfoNombre.BackColor = SystemColors.ControlLightLight;
            lblControlPagoDetalleInfoNombre.Dock = DockStyle.Fill;
            lblControlPagoDetalleInfoNombre.Location = new Point(3, 0);
            lblControlPagoDetalleInfoNombre.Name = "lblControlPagoDetalleInfoNombre";
            lblControlPagoDetalleInfoNombre.Padding = new Padding(0, 10, 0, 10);
            lblControlPagoDetalleInfoNombre.Size = new Size(378, 45);
            lblControlPagoDetalleInfoNombre.TabIndex = 0;
            lblControlPagoDetalleInfoNombre.Text = "lblControlPagoDetalleInfoNombre";
            lblControlPagoDetalleInfoNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlPagoDetalleInfoHabilitado
            // 
            lblControlPagoDetalleInfoHabilitado.AutoSize = true;
            lblControlPagoDetalleInfoHabilitado.Dock = DockStyle.Fill;
            lblControlPagoDetalleInfoHabilitado.Location = new Point(3, 45);
            lblControlPagoDetalleInfoHabilitado.Name = "lblControlPagoDetalleInfoHabilitado";
            lblControlPagoDetalleInfoHabilitado.Padding = new Padding(0, 10, 0, 10);
            lblControlPagoDetalleInfoHabilitado.Size = new Size(378, 45);
            lblControlPagoDetalleInfoHabilitado.TabIndex = 1;
            lblControlPagoDetalleInfoHabilitado.Text = "lblControlPagoDetalleInfoHabilitado";
            lblControlPagoDetalleInfoHabilitado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlPagoDetalleInfoIds
            // 
            lblControlPagoDetalleInfoIds.AutoSize = true;
            lblControlPagoDetalleInfoIds.Dock = DockStyle.Fill;
            lblControlPagoDetalleInfoIds.Location = new Point(3, 90);
            lblControlPagoDetalleInfoIds.Name = "lblControlPagoDetalleInfoIds";
            lblControlPagoDetalleInfoIds.Padding = new Padding(0, 2, 0, 0);
            lblControlPagoDetalleInfoIds.Size = new Size(378, 342);
            lblControlPagoDetalleInfoIds.TabIndex = 2;
            lblControlPagoDetalleInfoIds.Text = "lblControlPagoDetalleInfoIds";
            // 
            // ControlPagoDetalleInfo
            // 
            Controls.Add(panelControlPagoDetalleInfo);
            Name = "ControlPagoDetalleInfo";
            Size = new Size(384, 432);
            panelControlPagoDetalleInfo.ResumeLayout(false);
            panelControlPagoDetalleInfo.PerformLayout();
            ResumeLayout(false);

        }

        private Label lblControlPagoDetalleInfoHabilitado = null!;
        private Label lblControlPagoDetalleInfoIds = null!;
    }
}
