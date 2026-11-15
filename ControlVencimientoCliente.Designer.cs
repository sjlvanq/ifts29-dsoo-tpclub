namespace Club1
{
    partial class ControlVencimientoCliente
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        private void InitializeComponent()
        {
            layoutMain = new TableLayoutPanel();
            lblTitle = new Label();
            grpBusqueda = new GroupBox();
            layoutBusqueda = new TableLayoutPanel();
            lblCriterioBusqueda = new Label();
            cmbCriterioBusqueda = new ComboBox();
            lblValorBusqueda = new Label();
            txtValorBusqueda = new TextBox();
            btnBuscarCliente = new Button();
            grpVencimiento = new GroupBox();
            layoutVencimiento = new TableLayoutPanel();
            lblNombreCompleto = new Label();
            txtNombreCompleto = new TextBox();
            lblDni = new Label();
            txtDni = new TextBox();
            lblNroCarnet = new Label();
            txtNroCarnet = new TextBox();
            lblTelefono = new Label();
            txtTelefono = new TextBox();
            lblPlan = new Label();
            txtPlan = new TextBox();
            lblNroCuota = new Label();
            txtNroCuota = new TextBox();
            lblTotalCuotas = new Label();
            txtTotalCuotas = new TextBox();
            lblFechaVencimiento = new Label();
            txtFechaVencimiento = new TextBox();
            lblTieneCuotaSiguiente = new Label();
            txtTieneCuotaSiguiente = new TextBox();
            lblImporteCuotaSiguiente = new Label();
            txtImporteCuotaSiguiente = new TextBox();
            layoutMain.SuspendLayout();
            grpBusqueda.SuspendLayout();
            layoutBusqueda.SuspendLayout();
            grpVencimiento.SuspendLayout();
            layoutVencimiento.SuspendLayout();
            SuspendLayout();
            // 
            // layoutMain
            // 
            layoutMain.ColumnCount = 1;
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutMain.Controls.Add(lblTitle, 0, 0);
            layoutMain.Controls.Add(grpBusqueda, 0, 1);
            layoutMain.Controls.Add(grpVencimiento, 0, 2);
            layoutMain.Dock = DockStyle.Fill;
            layoutMain.Padding = new Padding(12);
            layoutMain.RowCount = 3;
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 48F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutMain.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Fill;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(15, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(704, 48);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Consultar vencimiento de un cliente";
            lblTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // grpBusqueda
            // 
            grpBusqueda.Controls.Add(layoutBusqueda);
            grpBusqueda.Dock = DockStyle.Fill;
            grpBusqueda.Location = new Point(15, 63);
            grpBusqueda.Name = "grpBusqueda";
            grpBusqueda.Padding = new Padding(10);
            grpBusqueda.Size = new Size(704, 106);
            grpBusqueda.TabIndex = 1;
            grpBusqueda.TabStop = false;
            grpBusqueda.Text = "Buscar cliente";
            // 
            // layoutBusqueda
            // 
            layoutBusqueda.ColumnCount = 5;
            layoutBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layoutBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 170F));
            layoutBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layoutBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutBusqueda.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 110F));
            layoutBusqueda.Controls.Add(lblCriterioBusqueda, 0, 0);
            layoutBusqueda.Controls.Add(cmbCriterioBusqueda, 1, 0);
            layoutBusqueda.Controls.Add(lblValorBusqueda, 2, 0);
            layoutBusqueda.Controls.Add(txtValorBusqueda, 3, 0);
            layoutBusqueda.Controls.Add(btnBuscarCliente, 4, 0);
            layoutBusqueda.Dock = DockStyle.Fill;
            layoutBusqueda.Location = new Point(13, 33);
            layoutBusqueda.Name = "layoutBusqueda";
            layoutBusqueda.RowCount = 1;
            layoutBusqueda.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutBusqueda.Size = new Size(678, 60);
            layoutBusqueda.TabIndex = 0;
            // 
            // lblCriterioBusqueda
            // 
            lblCriterioBusqueda.Anchor = AnchorStyles.Left;
            lblCriterioBusqueda.AutoSize = true;
            lblCriterioBusqueda.Location = new Point(3, 20);
            lblCriterioBusqueda.Name = "lblCriterioBusqueda";
            lblCriterioBusqueda.Size = new Size(51, 20);
            lblCriterioBusqueda.TabIndex = 0;
            lblCriterioBusqueda.Text = "Buscar por";
            // 
            // cmbCriterioBusqueda
            // 
            cmbCriterioBusqueda.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            cmbCriterioBusqueda.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCriterioBusqueda.FormattingEnabled = true;
            cmbCriterioBusqueda.Items.AddRange(new object[] { "Nro. de carnet", "DNI" });
            cmbCriterioBusqueda.Location = new Point(60, 16);
            cmbCriterioBusqueda.Name = "cmbCriterioBusqueda";
            cmbCriterioBusqueda.SelectedIndex = 0;
            cmbCriterioBusqueda.Size = new Size(164, 28);
            cmbCriterioBusqueda.TabIndex = 0;
            // 
            // lblValorBusqueda
            // 
            lblValorBusqueda.Anchor = AnchorStyles.Left;
            lblValorBusqueda.AutoSize = true;
            lblValorBusqueda.Location = new Point(230, 20);
            lblValorBusqueda.Name = "lblValorBusqueda";
            lblValorBusqueda.Size = new Size(53, 20);
            lblValorBusqueda.TabIndex = 1;
            lblValorBusqueda.Text = "Número";
            // 
            // txtValorBusqueda
            // 
            txtValorBusqueda.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtValorBusqueda.Location = new Point(289, 16);
            txtValorBusqueda.Name = "txtValorBusqueda";
            txtValorBusqueda.PlaceholderText = "Ingrese carnet o DNI";
            txtValorBusqueda.Size = new Size(276, 27);
            txtValorBusqueda.TabIndex = 1;
            // 
            // btnBuscarCliente
            // 
            btnBuscarCliente.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnBuscarCliente.Location = new Point(571, 14);
            btnBuscarCliente.Name = "btnBuscarCliente";
            btnBuscarCliente.Size = new Size(104, 32);
            btnBuscarCliente.TabIndex = 2;
            btnBuscarCliente.Text = "Buscar";
            btnBuscarCliente.UseVisualStyleBackColor = true;
            // 
            // grpVencimiento
            // 
            grpVencimiento.Controls.Add(layoutVencimiento);
            grpVencimiento.Dock = DockStyle.Fill;
            grpVencimiento.Location = new Point(15, 175);
            grpVencimiento.Name = "grpVencimiento";
            grpVencimiento.Padding = new Padding(10);
            grpVencimiento.Size = new Size(704, 420);
            grpVencimiento.TabIndex = 2;
            grpVencimiento.TabStop = false;
            grpVencimiento.Text = "Datos del cliente y de la cuota";
            // 
            // layoutVencimiento
            // 
            layoutVencimiento.ColumnCount = 4;
            layoutVencimiento.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layoutVencimiento.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutVencimiento.ColumnStyles.Add(new ColumnStyle(SizeType.AutoSize));
            layoutVencimiento.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            layoutVencimiento.Controls.Add(lblNombreCompleto, 0, 0);
            layoutVencimiento.Controls.Add(txtNombreCompleto, 1, 0);
            layoutVencimiento.Controls.Add(lblDni, 2, 0);
            layoutVencimiento.Controls.Add(txtDni, 3, 0);
            layoutVencimiento.Controls.Add(lblNroCarnet, 0, 1);
            layoutVencimiento.Controls.Add(txtNroCarnet, 1, 1);
            layoutVencimiento.Controls.Add(lblTelefono, 2, 1);
            layoutVencimiento.Controls.Add(txtTelefono, 3, 1);
            layoutVencimiento.Controls.Add(lblPlan, 0, 2);
            layoutVencimiento.Controls.Add(txtPlan, 1, 2);
            layoutVencimiento.Controls.Add(lblNroCuota, 2, 2);
            layoutVencimiento.Controls.Add(txtNroCuota, 3, 2);
            layoutVencimiento.Controls.Add(lblTotalCuotas, 0, 3);
            layoutVencimiento.Controls.Add(txtTotalCuotas, 1, 3);
            layoutVencimiento.Controls.Add(lblFechaVencimiento, 2, 3);
            layoutVencimiento.Controls.Add(txtFechaVencimiento, 3, 3);
            layoutVencimiento.Controls.Add(lblTieneCuotaSiguiente, 0, 4);
            layoutVencimiento.Controls.Add(txtTieneCuotaSiguiente, 1, 4);
            layoutVencimiento.Controls.Add(lblImporteCuotaSiguiente, 2, 4);
            layoutVencimiento.Controls.Add(txtImporteCuotaSiguiente, 3, 4);
            layoutVencimiento.Dock = DockStyle.Fill;
            layoutVencimiento.Location = new Point(13, 33);
            layoutVencimiento.Name = "layoutVencimiento";
            layoutVencimiento.Padding = new Padding(0, 6, 0, 0);
            layoutVencimiento.RowCount = 5;
            layoutVencimiento.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutVencimiento.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutVencimiento.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutVencimiento.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutVencimiento.RowStyles.Add(new RowStyle(SizeType.Percent, 20F));
            layoutVencimiento.Size = new Size(678, 374);
            layoutVencimiento.TabIndex = 0;
            // 
            // Labels and value fields
            // 
            ConfigurarEtiqueta(lblNombreCompleto, "Nombre completo", 0);
            ConfigurarCampo(txtNombreCompleto, 0);
            ConfigurarEtiqueta(lblDni, "DNI", 1);
            ConfigurarCampo(txtDni, 1);
            ConfigurarEtiqueta(lblNroCarnet, "Nro. de carnet", 2);
            ConfigurarCampo(txtNroCarnet, 2);
            ConfigurarEtiqueta(lblTelefono, "Teléfono", 3);
            ConfigurarCampo(txtTelefono, 3);
            ConfigurarEtiqueta(lblPlan, "Plan", 4);
            ConfigurarCampo(txtPlan, 4);
            ConfigurarEtiqueta(lblNroCuota, "Cuota actual", 5);
            ConfigurarCampo(txtNroCuota, 5);
            ConfigurarEtiqueta(lblTotalCuotas, "Total de cuotas", 6);
            ConfigurarCampo(txtTotalCuotas, 6);
            ConfigurarEtiqueta(lblFechaVencimiento, "Fecha de vencimiento", 7);
            ConfigurarCampo(txtFechaVencimiento, 7);
            ConfigurarEtiqueta(lblTieneCuotaSiguiente, "Tiene cuota siguiente", 8);
            ConfigurarCampo(txtTieneCuotaSiguiente, 8);
            ConfigurarEtiqueta(lblImporteCuotaSiguiente, "Importe cuota siguiente", 9);
            ConfigurarCampo(txtImporteCuotaSiguiente, 9);
            // 
            // ControlVencimientoCliente
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(layoutMain);
            Name = "ControlVencimientoCliente";
            Size = new Size(734, 608);
            layoutMain.ResumeLayout(false);
            grpBusqueda.ResumeLayout(false);
            layoutBusqueda.ResumeLayout(false);
            layoutBusqueda.PerformLayout();
            grpVencimiento.ResumeLayout(false);
            layoutVencimiento.ResumeLayout(false);
            layoutVencimiento.PerformLayout();
            ResumeLayout(false);
        }

        private void ConfigurarEtiqueta(Label label, string texto, int indice)
        {
            label.Anchor = AnchorStyles.Left;
            label.AutoSize = true;
            label.Padding = new Padding(0, 0, 8, 0);
            label.TabIndex = indice;
            label.Text = texto;
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private void ConfigurarCampo(TextBox textBox, int indice)
        {
            textBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            textBox.ReadOnly = true;
            textBox.Size = new Size(190, 27);
            textBox.TabIndex = indice + 10;
        }

        #endregion

        private TableLayoutPanel layoutMain;
        private Label lblTitle;
        private GroupBox grpBusqueda;
        private TableLayoutPanel layoutBusqueda;
        private Label lblCriterioBusqueda;
        private ComboBox cmbCriterioBusqueda;
        private Label lblValorBusqueda;
        private TextBox txtValorBusqueda;
        private Button btnBuscarCliente;
        private GroupBox grpVencimiento;
        private TableLayoutPanel layoutVencimiento;
        private Label lblNombreCompleto;
        private TextBox txtNombreCompleto;
        private Label lblDni;
        private TextBox txtDni;
        private Label lblNroCarnet;
        private TextBox txtNroCarnet;
        private Label lblTelefono;
        private TextBox txtTelefono;
        private Label lblPlan;
        private TextBox txtPlan;
        private Label lblNroCuota;
        private TextBox txtNroCuota;
        private Label lblTotalCuotas;
        private TextBox txtTotalCuotas;
        private Label lblFechaVencimiento;
        private TextBox txtFechaVencimiento;
        private Label lblTieneCuotaSiguiente;
        private TextBox txtTieneCuotaSiguiente;
        private Label lblImporteCuotaSiguiente;
        private TextBox txtImporteCuotaSiguiente;
    }
}
