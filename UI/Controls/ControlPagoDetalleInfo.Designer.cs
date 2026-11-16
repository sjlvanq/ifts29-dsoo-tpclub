namespace Club1.UI.Controls
{
    partial class ControlPagoDetalleInfo
    {

        #region Código generado por el Diseñador de componentes
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
            panelControlPagoDetalleInfo.Size = new Size(313, 427);
            panelControlPagoDetalleInfo.TabIndex = 0;
            // 
            // lblControlPagoDetalleInfoNombre
            // 
            lblControlPagoDetalleInfoNombre.AutoSize = true;
            lblControlPagoDetalleInfoNombre.BackColor = SystemColors.ControlLightLight;
            lblControlPagoDetalleInfoNombre.Dock = DockStyle.Fill;
            lblControlPagoDetalleInfoNombre.Location = new Point(3, 0);
            lblControlPagoDetalleInfoNombre.Name = "lblControlPagoDetalleInfoNombre";
            lblControlPagoDetalleInfoNombre.Padding = new Padding(0, 5, 0, 5);
            lblControlPagoDetalleInfoNombre.Size = new Size(307, 35);
            lblControlPagoDetalleInfoNombre.TabIndex = 0;
            lblControlPagoDetalleInfoNombre.Text = "lblControlPagoDetalleInfoNombre";
            lblControlPagoDetalleInfoNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlPagoDetalleInfoHabilitado
            // 
            lblControlPagoDetalleInfoHabilitado.AutoSize = true;
            lblControlPagoDetalleInfoHabilitado.Dock = DockStyle.Fill;
            lblControlPagoDetalleInfoHabilitado.Location = new Point(3, 35);
            lblControlPagoDetalleInfoHabilitado.Name = "lblControlPagoDetalleInfoHabilitado";
            lblControlPagoDetalleInfoHabilitado.Padding = new Padding(0, 5, 0, 5);
            lblControlPagoDetalleInfoHabilitado.Size = new Size(307, 35);
            lblControlPagoDetalleInfoHabilitado.TabIndex = 1;
            lblControlPagoDetalleInfoHabilitado.Text = "lblControlPagoDetalleInfoHabilitado";
            lblControlPagoDetalleInfoHabilitado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlPagoDetalleInfoIds
            // 
            lblControlPagoDetalleInfoIds.AutoSize = true;
            lblControlPagoDetalleInfoIds.Dock = DockStyle.Fill;
            lblControlPagoDetalleInfoIds.Location = new Point(3, 70);
            lblControlPagoDetalleInfoIds.Name = "lblControlPagoDetalleInfoIds";
            lblControlPagoDetalleInfoIds.Padding = new Padding(0, 2, 0, 0);
            lblControlPagoDetalleInfoIds.Size = new Size(307, 357);
            lblControlPagoDetalleInfoIds.TabIndex = 2;
            lblControlPagoDetalleInfoIds.Text = "lblControlPagoDetalleInfoIds";
            // 
            // ControlPagoDetalleInfo
            // 
            Controls.Add(panelControlPagoDetalleInfo);
            Name = "ControlPagoDetalleInfo";
            Size = new Size(313, 427);
            panelControlPagoDetalleInfo.ResumeLayout(false);
            panelControlPagoDetalleInfo.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private Label lblControlPagoDetalleInfoNombre;
        private Label lblControlPagoDetalleInfoHabilitado;
        private Label lblControlPagoDetalleInfoIds;
        private TableLayoutPanel panelControlPagoDetalleInfo;
    }
}
