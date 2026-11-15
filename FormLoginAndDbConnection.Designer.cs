namespace Club1
{
    partial class FormLoginAndDbConnection
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLoginAndDbConnection));
            tableLayoutPanel1 = new TableLayoutPanel();
            tabControl1 = new TabControl();
            tabPageLogin = new TabPage();
            tableLayoutPanel2 = new TableLayoutPanel();
            txtLoginUser = new TextBox();
            txtLoginPass = new TextBox();
            lblLoginUser = new Label();
            lblLoginPass = new Label();
            tabPageDB = new TabPage();
            panelConexion = new TableLayoutPanel();
            lblDbServer = new Label();
            txtDbServer = new TextBox();
            lblDbPort = new Label();
            txtDbPort = new TextBox();
            lblDbDb = new Label();
            txtDbDb = new TextBox();
            lblDbUser = new Label();
            txtDbUser = new TextBox();
            txtDbPass = new TextBox();
            lblDbPass = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            btnCancelar = new Button();
            btnConectar = new Button();
            lblHeader = new Label();
            lblErrorMessage = new Label();
            extenderTextBoxesForValidation1 = new ExtenderTextBoxesForValidation(components);
            tableLayoutPanel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPageLogin.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabPageDB.SuspendLayout();
            panelConexion.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.AutoSize = true;
            tableLayoutPanel1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(tabControl1, 0, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 0, 3);
            tableLayoutPanel1.Controls.Add(lblHeader, 0, 0);
            tableLayoutPanel1.Controls.Add(lblErrorMessage, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 45F));
            tableLayoutPanel1.Size = new Size(701, 471);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageLogin);
            tabControl1.Controls.Add(tabPageDB);
            tabControl1.Location = new Point(3, 98);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(695, 297);
            tabControl1.TabIndex = 0;
            // 
            // tabPageLogin
            // 
            tabPageLogin.Controls.Add(tableLayoutPanel2);
            tabPageLogin.Location = new Point(4, 34);
            tabPageLogin.Name = "tabPageLogin";
            tabPageLogin.Padding = new Padding(3);
            tabPageLogin.Size = new Size(687, 259);
            tabPageLogin.TabIndex = 0;
            tabPageLogin.Text = "Credenciales de Usuario";
            tabPageLogin.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel2.Controls.Add(txtLoginUser, 1, 1);
            tableLayoutPanel2.Controls.Add(txtLoginPass, 1, 2);
            tableLayoutPanel2.Controls.Add(lblLoginUser, 0, 1);
            tableLayoutPanel2.Controls.Add(lblLoginPass, 0, 2);
            tableLayoutPanel2.Location = new Point(2, 37);
            tableLayoutPanel2.Margin = new Padding(4, 5, 4, 5);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.Padding = new Padding(14, 17, 14, 17);
            tableLayoutPanel2.RowCount = 3;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel2.Size = new Size(681, 126);
            tableLayoutPanel2.TabIndex = 13;
            // 
            // txtLoginUser
            // 
            txtLoginUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtLoginUser, lblLoginUser);
            extenderTextBoxesForValidation1.SetContainerTab(txtLoginUser, tabPageLogin);
            extenderTextBoxesForValidation1.SetIsRequired(txtLoginUser, true);
            txtLoginUser.Location = new Point(245, 20);
            txtLoginUser.Name = "txtLoginUser";
            txtLoginUser.Size = new Size(419, 31);
            txtLoginUser.TabIndex = 16;
            txtLoginUser.Tag = "";
            // 
            // txtLoginPass
            // 
            txtLoginPass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtLoginPass, lblLoginPass);
            extenderTextBoxesForValidation1.SetContainerTab(txtLoginPass, tabPageLogin);
            extenderTextBoxesForValidation1.SetIsRequired(txtLoginPass, true);
            txtLoginPass.Location = new Point(245, 61);
            txtLoginPass.Name = "txtLoginPass";
            txtLoginPass.PasswordChar = '*';
            txtLoginPass.Size = new Size(419, 31);
            txtLoginPass.TabIndex = 18;
            txtLoginPass.Tag = "";
            // 
            // lblLoginUser
            // 
            lblLoginUser.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLoginUser.AutoSize = true;
            lblLoginUser.Location = new Point(17, 17);
            lblLoginUser.Name = "lblLoginUser";
            lblLoginUser.Size = new Size(222, 25);
            lblLoginUser.TabIndex = 15;
            lblLoginUser.Text = "Usuario";
            lblLoginUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblLoginPass
            // 
            lblLoginPass.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblLoginPass.AutoSize = true;
            lblLoginPass.Location = new Point(17, 58);
            lblLoginPass.Name = "lblLoginPass";
            lblLoginPass.Size = new Size(222, 25);
            lblLoginPass.TabIndex = 17;
            lblLoginPass.Text = "Contraseña";
            lblLoginPass.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tabPageDB
            // 
            tabPageDB.Controls.Add(panelConexion);
            tabPageDB.Location = new Point(4, 34);
            tabPageDB.Name = "tabPageDB";
            tabPageDB.Padding = new Padding(3);
            tabPageDB.Size = new Size(687, 259);
            tabPageDB.TabIndex = 1;
            tabPageDB.Text = "Conexión MySQL/MariaDB";
            tabPageDB.UseVisualStyleBackColor = true;
            // 
            // panelConexion
            // 
            panelConexion.AutoSize = true;
            panelConexion.ColumnCount = 2;
            panelConexion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            panelConexion.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            panelConexion.Controls.Add(lblDbServer, 0, 0);
            panelConexion.Controls.Add(txtDbServer, 1, 0);
            panelConexion.Controls.Add(lblDbPort, 0, 1);
            panelConexion.Controls.Add(txtDbPort, 1, 1);
            panelConexion.Controls.Add(lblDbDb, 0, 2);
            panelConexion.Controls.Add(txtDbDb, 1, 2);
            panelConexion.Controls.Add(lblDbUser, 0, 3);
            panelConexion.Controls.Add(txtDbUser, 1, 3);
            panelConexion.Controls.Add(txtDbPass, 1, 4);
            panelConexion.Controls.Add(lblDbPass, 0, 4);
            panelConexion.Dock = DockStyle.Top;
            panelConexion.Location = new Point(3, 3);
            panelConexion.Margin = new Padding(4, 5, 4, 5);
            panelConexion.Name = "panelConexion";
            panelConexion.Padding = new Padding(14, 17, 14, 17);
            panelConexion.RowCount = 5;
            panelConexion.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            panelConexion.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            panelConexion.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            panelConexion.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            panelConexion.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            panelConexion.Size = new Size(681, 239);
            panelConexion.TabIndex = 2;
            // 
            // lblDbServer
            // 
            lblDbServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDbServer.AutoSize = true;
            lblDbServer.Location = new Point(18, 17);
            lblDbServer.Margin = new Padding(4, 0, 4, 0);
            lblDbServer.Name = "lblDbServer";
            lblDbServer.Size = new Size(220, 41);
            lblDbServer.TabIndex = 0;
            lblDbServer.Text = "Servidor";
            lblDbServer.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbServer
            // 
            txtDbServer.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtDbServer, lblDbServer);
            extenderTextBoxesForValidation1.SetContainerTab(txtDbServer, tabPageDB);
            extenderTextBoxesForValidation1.SetIsRequired(txtDbServer, true);
            txtDbServer.Location = new Point(246, 22);
            txtDbServer.Margin = new Padding(4, 5, 4, 5);
            txtDbServer.Name = "txtDbServer";
            txtDbServer.Size = new Size(417, 31);
            txtDbServer.TabIndex = 1;
            txtDbServer.Tag = "";
            txtDbServer.Text = "localhost";
            // 
            // lblDbPort
            // 
            lblDbPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDbPort.AutoSize = true;
            lblDbPort.Location = new Point(18, 58);
            lblDbPort.Margin = new Padding(4, 0, 4, 0);
            lblDbPort.Name = "lblDbPort";
            lblDbPort.Size = new Size(220, 41);
            lblDbPort.TabIndex = 2;
            lblDbPort.Text = "Puerto";
            lblDbPort.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbPort
            // 
            txtDbPort.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtDbPort, lblDbPort);
            extenderTextBoxesForValidation1.SetContainerTab(txtDbPort, tabPageDB);
            extenderTextBoxesForValidation1.SetIsRequired(txtDbPort, true);
            txtDbPort.Location = new Point(246, 63);
            txtDbPort.Margin = new Padding(4, 5, 4, 5);
            txtDbPort.Name = "txtDbPort";
            txtDbPort.Size = new Size(417, 31);
            txtDbPort.TabIndex = 3;
            txtDbPort.Tag = "";
            txtDbPort.Text = "3306";
            // 
            // lblDbDb
            // 
            lblDbDb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDbDb.AutoSize = true;
            lblDbDb.Location = new Point(18, 99);
            lblDbDb.Margin = new Padding(4, 0, 4, 0);
            lblDbDb.Name = "lblDbDb";
            lblDbDb.Size = new Size(220, 41);
            lblDbDb.TabIndex = 4;
            lblDbDb.Text = "Base de datos";
            lblDbDb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbDb
            // 
            txtDbDb.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtDbDb, lblDbDb);
            extenderTextBoxesForValidation1.SetContainerTab(txtDbDb, tabPageDB);
            extenderTextBoxesForValidation1.SetIsRequired(txtDbDb, true);
            txtDbDb.Location = new Point(246, 104);
            txtDbDb.Margin = new Padding(4, 5, 4, 5);
            txtDbDb.Name = "txtDbDb";
            txtDbDb.Size = new Size(417, 31);
            txtDbDb.TabIndex = 5;
            txtDbDb.Tag = "";
            txtDbDb.Text = "club_deportivo";
            // 
            // lblDbUser
            // 
            lblDbUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDbUser.AutoSize = true;
            lblDbUser.Location = new Point(18, 140);
            lblDbUser.Margin = new Padding(4, 0, 4, 0);
            lblDbUser.Name = "lblDbUser";
            lblDbUser.Size = new Size(220, 41);
            lblDbUser.TabIndex = 6;
            lblDbUser.Text = "Usuario";
            lblDbUser.TextAlign = ContentAlignment.MiddleRight;
            // 
            // txtDbUser
            // 
            txtDbUser.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtDbUser, lblDbUser);
            extenderTextBoxesForValidation1.SetContainerTab(txtDbUser, tabPageDB);
            extenderTextBoxesForValidation1.SetIsRequired(txtDbUser, true);
            txtDbUser.Location = new Point(246, 145);
            txtDbUser.Margin = new Padding(4, 5, 4, 5);
            txtDbUser.Name = "txtDbUser";
            txtDbUser.Size = new Size(417, 31);
            txtDbUser.TabIndex = 7;
            txtDbUser.Tag = "";
            txtDbUser.Text = "root";
            // 
            // txtDbPass
            // 
            txtDbPass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            extenderTextBoxesForValidation1.SetAssociatedLabel(txtDbPass, lblDbPass);
            extenderTextBoxesForValidation1.SetContainerTab(txtDbPass, tabPageDB);
            extenderTextBoxesForValidation1.SetIsRequired(txtDbPass, true);
            txtDbPass.Location = new Point(246, 186);
            txtDbPass.Margin = new Padding(4, 5, 4, 5);
            txtDbPass.Name = "txtDbPass";
            txtDbPass.Size = new Size(417, 31);
            txtDbPass.TabIndex = 9;
            txtDbPass.Tag = "";
            txtDbPass.Text = "1234";
            txtDbPass.UseSystemPasswordChar = true;
            // 
            // lblDbPass
            // 
            lblDbPass.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblDbPass.AutoSize = true;
            lblDbPass.Location = new Point(18, 181);
            lblDbPass.Margin = new Padding(4, 0, 4, 0);
            lblDbPass.Name = "lblDbPass";
            lblDbPass.Size = new Size(220, 41);
            lblDbPass.TabIndex = 8;
            lblDbPass.Text = "Contraseña";
            lblDbPass.TextAlign = ContentAlignment.MiddleRight;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel3.Controls.Add(btnCancelar, 0, 0);
            tableLayoutPanel3.Controls.Add(btnConectar, 1, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 401);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(695, 67);
            tableLayoutPanel3.TabIndex = 12;
            // 
            // btnCancelar
            // 
            btnCancelar.DialogResult = DialogResult.Cancel;
            btnCancelar.Dock = DockStyle.Fill;
            btnCancelar.Location = new Point(3, 3);
            btnCancelar.MinimumSize = new Size(0, 60);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(341, 61);
            btnCancelar.TabIndex = 0;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnConectar
            // 
            btnConectar.DialogResult = DialogResult.OK;
            btnConectar.Dock = DockStyle.Fill;
            btnConectar.Location = new Point(350, 3);
            btnConectar.MinimumSize = new Size(0, 60);
            btnConectar.Name = "btnConectar";
            btnConectar.Size = new Size(342, 61);
            btnConectar.TabIndex = 1;
            btnConectar.Text = "Conectar";
            btnConectar.UseVisualStyleBackColor = true;
            btnConectar.Click += btnConectar_Click;
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Dock = DockStyle.Fill;
            lblHeader.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.Location = new Point(3, 0);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(695, 70);
            lblHeader.TabIndex = 13;
            lblHeader.Text = "Sistema de Gestión del Club - Conexión y Acceso";
            lblHeader.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblErrorMessage
            // 
            lblErrorMessage.AutoSize = true;
            lblErrorMessage.BackColor = Color.PeachPuff;
            lblErrorMessage.Dock = DockStyle.Fill;
            lblErrorMessage.Location = new Point(3, 70);
            lblErrorMessage.MaximumSize = new Size(706, 0);
            lblErrorMessage.Name = "lblErrorMessage";
            lblErrorMessage.Size = new Size(695, 25);
            lblErrorMessage.TabIndex = 14;
            lblErrorMessage.Text = "lblErrorMessage";
            lblErrorMessage.TextAlign = ContentAlignment.MiddleCenter;
            lblErrorMessage.Visible = false;
            lblErrorMessage.TextChanged += lblErrorMessage_TextChanged;
            lblErrorMessage.Resize += lblErrorMessage_Resize;
            // 
            // extenderTextBoxesForValidation1
            // 
            extenderTextBoxesForValidation1.BorderStyle = BorderStyle.None;
            extenderTextBoxesForValidation1.Location = new Point(-6, 440);
            extenderTextBoxesForValidation1.Name = "extenderTextBoxesForValidation1";
            extenderTextBoxesForValidation1.Size = new Size(150, 24);
            extenderTextBoxesForValidation1.TabIndex = 1;
            // 
            // FormLoginAndDbConnection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(701, 471);
            Controls.Add(extenderTextBoxesForValidation1);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormLoginAndDbConnection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Configuración de conexión";
            Load += FormLoginAndDbConection_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPageLogin.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tabPageDB.ResumeLayout(false);
            tabPageDB.PerformLayout();
            panelConexion.ResumeLayout(false);
            panelConexion.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TabControl tabControl1;
        private TabPage tabPageLogin;
        private TabPage tabPageDB;
        private TableLayoutPanel tableLayoutPanel2;
        private TextBox txtLoginUser;
        private TextBox txtLoginPass;
        private Label lblLoginUser;
        private Label lblLoginPass;
        private TableLayoutPanel panelConexion;
        private Label lblDbServer;
        private TextBox txtDbServer;
        private Label lblDbPort;
        private TextBox txtDbPort;
        private Label lblDbDb;
        private TextBox txtDbDb;
        private Label lblDbUser;
        private TextBox txtDbUser;
        private TextBox txtDbPass;
        private Label lblDbPass;
        private TableLayoutPanel tableLayoutPanel3;
        private Button btnCancelar;
        private Button btnConectar;
        private Label lblHeader;
        private ExtenderTextBoxesForValidation extenderTextBoxesForValidation1;
        private Label lblErrorMessage;
    }
}
