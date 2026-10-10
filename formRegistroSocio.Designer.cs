namespace Club1
{
    partial class formRegistroSocio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            lblNumeroDocumento = new Label();
            lblNombre = new Label();
            lblApellido = new Label();
            lblDireccion = new Label();
            lblEmail = new Label();
            lblTelefono = new Label();
            lblFechaNacimiento = new Label();
            lblTipoSocio = new Label();
            txtNumeroDocumento = new TextBox();
            txtNombre = new TextBox();
            txtApellido = new TextBox();
            txtDireccion = new TextBox();
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            dtpFechaNacimiento = new DateTimePicker();
            cmbTipoDocumento = new ComboBox();
            cmbTipoSocio = new ComboBox();
            lblTipoDocumento = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnRegistrar = new Button();
            btnLimpiar = new Button();
            btnVolver = new Button();
            tableLayoutPanel3 = new TableLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.None;
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66.6666641F));
            tableLayoutPanel1.Controls.Add(lblNumeroDocumento, 0, 2);
            tableLayoutPanel1.Controls.Add(lblNombre, 0, 3);
            tableLayoutPanel1.Controls.Add(lblApellido, 0, 4);
            tableLayoutPanel1.Controls.Add(lblDireccion, 0, 5);
            tableLayoutPanel1.Controls.Add(lblEmail, 0, 6);
            tableLayoutPanel1.Controls.Add(lblTelefono, 0, 7);
            tableLayoutPanel1.Controls.Add(lblFechaNacimiento, 0, 8);
            tableLayoutPanel1.Controls.Add(lblTipoSocio, 0, 9);
            tableLayoutPanel1.Controls.Add(txtNumeroDocumento, 1, 2);
            tableLayoutPanel1.Controls.Add(txtNombre, 1, 3);
            tableLayoutPanel1.Controls.Add(txtApellido, 1, 4);
            tableLayoutPanel1.Controls.Add(txtDireccion, 1, 5);
            tableLayoutPanel1.Controls.Add(txtEmail, 1, 6);
            tableLayoutPanel1.Controls.Add(txtTelefono, 1, 7);
            tableLayoutPanel1.Controls.Add(dtpFechaNacimiento, 1, 8);
            tableLayoutPanel1.Controls.Add(cmbTipoDocumento, 1, 1);
            tableLayoutPanel1.Controls.Add(cmbTipoSocio, 1, 9);
            tableLayoutPanel1.Controls.Add(lblTipoDocumento, 0, 1);
            tableLayoutPanel1.Location = new Point(4, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 10;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(549, 337);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // lblNumeroDocumento
            // 
            lblNumeroDocumento.AutoSize = true;
            lblNumeroDocumento.Location = new Point(3, 39);
            lblNumeroDocumento.Name = "lblNumeroDocumento";
            lblNumeroDocumento.Size = new Size(37, 25);
            lblNumeroDocumento.TabIndex = 1;
            lblNumeroDocumento.Text = "N.º";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(3, 76);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(78, 25);
            lblNombre.TabIndex = 2;
            lblNombre.Text = "Nombre";
            // 
            // lblApellido
            // 
            lblApellido.AutoSize = true;
            lblApellido.Location = new Point(3, 113);
            lblApellido.Name = "lblApellido";
            lblApellido.Size = new Size(78, 25);
            lblApellido.TabIndex = 3;
            lblApellido.Text = "Apellido";
            // 
            // lblDireccion
            // 
            lblDireccion.AutoSize = true;
            lblDireccion.Location = new Point(3, 150);
            lblDireccion.Name = "lblDireccion";
            lblDireccion.Size = new Size(85, 25);
            lblDireccion.TabIndex = 4;
            lblDireccion.Text = "Dirección";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(3, 187);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(157, 25);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Correo Electrónico";
            // 
            // lblTelefono
            // 
            lblTelefono.AutoSize = true;
            lblTelefono.Location = new Point(3, 224);
            lblTelefono.Name = "lblTelefono";
            lblTelefono.Size = new Size(79, 25);
            lblTelefono.TabIndex = 6;
            lblTelefono.Text = "Teléfono";
            // 
            // lblFechaNacimiento
            // 
            lblFechaNacimiento.AutoSize = true;
            lblFechaNacimiento.Location = new Point(3, 261);
            lblFechaNacimiento.Name = "lblFechaNacimiento";
            lblFechaNacimiento.Size = new Size(177, 25);
            lblFechaNacimiento.TabIndex = 7;
            lblFechaNacimiento.Text = "Fecha de Nacimiento";
            // 
            // lblTipoSocio
            // 
            lblTipoSocio.AutoSize = true;
            lblTipoSocio.Location = new Point(3, 298);
            lblTipoSocio.Name = "lblTipoSocio";
            lblTipoSocio.Size = new Size(119, 25);
            lblTipoSocio.TabIndex = 8;
            lblTipoSocio.Text = "Tipo de socio";
            // 
            // txtNumeroDocumento
            // 
            txtNumeroDocumento.Location = new Point(186, 42);
            txtNumeroDocumento.Name = "txtNumeroDocumento";
            txtNumeroDocumento.Size = new Size(351, 31);
            txtNumeroDocumento.TabIndex = 10;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(186, 79);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(351, 31);
            txtNombre.TabIndex = 11;
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(186, 116);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(351, 31);
            txtApellido.TabIndex = 12;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(186, 153);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(351, 31);
            txtDireccion.TabIndex = 13;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(186, 190);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(351, 31);
            txtEmail.TabIndex = 14;
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(186, 227);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(351, 31);
            txtTelefono.TabIndex = 15;
            // 
            // dtpFechaNacimiento
            // 
            dtpFechaNacimiento.Location = new Point(186, 264);
            dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            dtpFechaNacimiento.Size = new Size(351, 31);
            dtpFechaNacimiento.TabIndex = 16;
            // 
            // cmbTipoDocumento
            // 
            cmbTipoDocumento.FormattingEnabled = true;
            cmbTipoDocumento.Location = new Point(186, 3);
            cmbTipoDocumento.Name = "cmbTipoDocumento";
            cmbTipoDocumento.Size = new Size(351, 33);
            cmbTipoDocumento.TabIndex = 18;
            // 
            // cmbTipoSocio
            // 
            cmbTipoSocio.FormattingEnabled = true;
            cmbTipoSocio.Location = new Point(186, 301);
            cmbTipoSocio.Name = "cmbTipoSocio";
            cmbTipoSocio.Size = new Size(351, 33);
            cmbTipoSocio.TabIndex = 19;
            // 
            // lblTipoDocumento
            // 
            lblTipoDocumento.AutoSize = true;
            lblTipoDocumento.Location = new Point(3, 0);
            lblTipoDocumento.Name = "lblTipoDocumento";
            lblTipoDocumento.Size = new Size(171, 25);
            lblTipoDocumento.TabIndex = 17;
            lblTipoDocumento.Text = "Tipo de Documento";
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Controls.Add(btnRegistrar, 0, 0);
            tableLayoutPanel2.Controls.Add(btnLimpiar, 1, 0);
            tableLayoutPanel2.Controls.Add(btnVolver, 2, 0);
            tableLayoutPanel2.Location = new Point(3, 346);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(551, 54);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnRegistrar.AutoSize = true;
            btnRegistrar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnRegistrar.Location = new Point(3, 3);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(177, 48);
            btnRegistrar.TabIndex = 0;
            btnRegistrar.Text = "Registrar";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // btnLimpiar
            // 
            btnLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnLimpiar.AutoSize = true;
            btnLimpiar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnLimpiar.Location = new Point(186, 3);
            btnLimpiar.Name = "btnLimpiar";
            btnLimpiar.Size = new Size(177, 48);
            btnLimpiar.TabIndex = 1;
            btnLimpiar.Text = "Limpiar";
            btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // btnVolver
            // 
            btnVolver.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnVolver.AutoSize = true;
            btnVolver.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btnVolver.Location = new Point(369, 3);
            btnVolver.Name = "btnVolver";
            btnVolver.Size = new Size(179, 48);
            btnVolver.TabIndex = 2;
            btnVolver.Text = "Volver";
            btnVolver.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.AutoSize = true;
            tableLayoutPanel3.ColumnCount = 1;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel3.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel3.Location = new Point(12, 30);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 2;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle());
            tableLayoutPanel3.Size = new Size(557, 403);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // formRegistroSocio
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(578, 474);
            Controls.Add(tableLayoutPanel3);
            Name = "formRegistroSocio";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Club - Registro de Nuevo Socio";
            Load += formRegistroSocio_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label lblNumeroDocumento;
        private Label lblNombre;
        private Label lblApellido;
        private Label lblDireccion;
        private Label lblEmail;
        private Label lblTelefono;
        private Label lblFechaNacimiento;
        private Label lblTipoSocio;
        private TextBox txtNumeroDocumento;
        private TextBox txtNombre;
        private TextBox txtApellido;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private DateTimePicker dtpFechaNacimiento;
        private Label lblTipoDocumento;
        private ComboBox cmbTipoDocumento;
        private ComboBox cmbTipoSocio;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnRegistrar;
        private Button btnLimpiar;
        private Button btnVolver;
        private TableLayoutPanel tableLayoutPanel3;
    }
}
