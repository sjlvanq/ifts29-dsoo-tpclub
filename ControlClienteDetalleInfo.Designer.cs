namespace Club1
{
    partial class ControlClienteDetalleInfo
    {

        #region Código generado por el Diseñador de componentes
        private void InitializeComponent()
        {
            panelControlClienteDetalleInfo = new TableLayoutPanel();
            lblControlClienteDetalleInfoNombre = new Label();
            lblControlClienteDetalleInfoHabilitado = new Label();
            lblControlClienteDetalleInfoIds = new Label();
            panelControlClienteDetalleInfo.SuspendLayout();
            SuspendLayout();
            // 
            // panelControlClienteDetalleInfo
            // 
            panelControlClienteDetalleInfo.ColumnCount = 1;
            panelControlClienteDetalleInfo.ColumnStyles.Add(new ColumnStyle());
            panelControlClienteDetalleInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            panelControlClienteDetalleInfo.Controls.Add(lblControlClienteDetalleInfoNombre, 0, 0);
            panelControlClienteDetalleInfo.Controls.Add(lblControlClienteDetalleInfoHabilitado, 0, 1);
            panelControlClienteDetalleInfo.Controls.Add(lblControlClienteDetalleInfoIds, 0, 2);
            panelControlClienteDetalleInfo.Dock = DockStyle.Fill;
            panelControlClienteDetalleInfo.Location = new Point(0, 0);
            panelControlClienteDetalleInfo.Name = "panelControlClienteDetalleInfo";
            panelControlClienteDetalleInfo.RowCount = 3;
            panelControlClienteDetalleInfo.RowStyles.Add(new RowStyle());
            panelControlClienteDetalleInfo.RowStyles.Add(new RowStyle());
            panelControlClienteDetalleInfo.RowStyles.Add(new RowStyle());
            panelControlClienteDetalleInfo.Size = new Size(384, 432);
            panelControlClienteDetalleInfo.TabIndex = 0;
            // 
            // lblControlClienteDetalleInfoNombre
            // 
            lblControlClienteDetalleInfoNombre.AutoSize = true;
            lblControlClienteDetalleInfoNombre.BackColor = SystemColors.ControlLightLight;
            lblControlClienteDetalleInfoNombre.Dock = DockStyle.Fill;
            //lblControlClienteDetalleInfoNombre.Image = Properties.Resources.es_socio;
            lblControlClienteDetalleInfoNombre.ImageAlign = ContentAlignment.TopRight;
            lblControlClienteDetalleInfoNombre.Location = new Point(3, 0);
            lblControlClienteDetalleInfoNombre.Name = "lblControlClienteDetalleInfoNombre";
            lblControlClienteDetalleInfoNombre.Padding = new Padding(0, 5, 0, 5);
            lblControlClienteDetalleInfoNombre.Size = new Size(378, 35);
            lblControlClienteDetalleInfoNombre.TabIndex = 0;
            lblControlClienteDetalleInfoNombre.Text = "lblControlClienteDetalleInfoNombre";
            lblControlClienteDetalleInfoNombre.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlClienteDetalleInfoHabilitado
            // 
            lblControlClienteDetalleInfoHabilitado.AutoSize = true;
            lblControlClienteDetalleInfoHabilitado.Dock = DockStyle.Fill;
            lblControlClienteDetalleInfoHabilitado.Location = new Point(3, 35);
            lblControlClienteDetalleInfoHabilitado.Name = "lblControlClienteDetalleInfoHabilitado";
            lblControlClienteDetalleInfoHabilitado.Padding = new Padding(0, 5, 0, 5);
            lblControlClienteDetalleInfoHabilitado.Size = new Size(378, 35);
            lblControlClienteDetalleInfoHabilitado.TabIndex = 1;
            lblControlClienteDetalleInfoHabilitado.Text = "lblControlClienteDetalleInfoHabilitado";
            lblControlClienteDetalleInfoHabilitado.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblControlClienteDetalleInfoIds
            // 
            lblControlClienteDetalleInfoIds.AutoSize = true;
            lblControlClienteDetalleInfoIds.Dock = DockStyle.Fill;
            lblControlClienteDetalleInfoIds.Location = new Point(3, 70);
            lblControlClienteDetalleInfoIds.Name = "lblControlClienteDetalleInfoIds";
            lblControlClienteDetalleInfoIds.Padding = new Padding(0, 2, 0, 0);
            lblControlClienteDetalleInfoIds.Size = new Size(378, 362);
            lblControlClienteDetalleInfoIds.TabIndex = 2;
            lblControlClienteDetalleInfoIds.Text = "lblControlClienteDetalleInfoIds";
            // 
            // ControlClienteDetalleInfo
            // 
            Controls.Add(panelControlClienteDetalleInfo);
            Name = "ControlClienteDetalleInfo";
            Size = new Size(384, 432);
            panelControlClienteDetalleInfo.ResumeLayout(false);
            panelControlClienteDetalleInfo.PerformLayout();
            ResumeLayout(false);
        }
        #endregion
        private Label lblControlClienteDetalleInfoNombre;
        private Label lblControlClienteDetalleInfoHabilitado;
        private Label lblControlClienteDetalleInfoIds;
        private TableLayoutPanel panelControlClienteDetalleInfo;
    }
}
