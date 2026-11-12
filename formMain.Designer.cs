namespace Club1
{
    partial class formMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelMain = new TableLayoutPanel();
            panelModuleHeader = new TableLayoutPanel();
            lblModuleTitle = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            lblUserName = new Label();
            statusStripMain = new StatusStrip();
            toolStripStatusLabelMain = new ToolStripStatusLabel();
            tabControlMain = new CustomTabControl();
            tabPageHome = new TabPage();
            panelPageHome = new TableLayoutPanel();
            lblPanelPageHomeTitle = new Label();
            picPanelPageHomeLogo = new PictureBox();
            lblMainNotes = new TextBox();
            tabPageClientes = new TabPage();
            panelPageClientes = new TableLayoutPanel();
            viewSwitcherClientes = new ViewSwitcherClientes(components);
            tabPagePagos = new TabPage();
            panelPagePagos = new TableLayoutPanel();
            viewSwitcherPagos = new ViewSwitcher(components);
            tabPageVencimientos = new TabPage();
            panelPageVencimientos = new TableLayoutPanel();
            tabPageActividades = new TabPage();
            viewSwitcherActividades = new ViewSwitcher(components);
            panelPageActividades = new TableLayoutPanel();
            panelMain.SuspendLayout();
            panelModuleHeader.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            statusStripMain.SuspendLayout();
            tabControlMain.SuspendLayout();
            tabPageHome.SuspendLayout();
            panelPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPanelPageHomeLogo).BeginInit();
            tabPageClientes.SuspendLayout();
            panelPageClientes.SuspendLayout();
            tabPagePagos.SuspendLayout();
            panelPagePagos.SuspendLayout();
            tabPageVencimientos.SuspendLayout();
            tabPageActividades.SuspendLayout();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.AutoSize = true;
            panelMain.ColumnCount = 1;
            panelMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelMain.Controls.Add(panelModuleHeader, 0, 0);
            panelMain.Controls.Add(statusStripMain, 0, 2);
            panelMain.Controls.Add(tabControlMain, 0, 1);
            panelMain.Dock = DockStyle.Fill;
            panelMain.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            panelMain.Location = new Point(0, 0);
            panelMain.Name = "panelMain";
            panelMain.RowCount = 3;
            panelMain.RowStyles.Add(new RowStyle());
            panelMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelMain.RowStyles.Add(new RowStyle());
            panelMain.Size = new Size(956, 631);
            panelMain.TabIndex = 2;
            // 
            // panelModuleHeader
            // 
            panelModuleHeader.AutoSize = true;
            panelModuleHeader.BackColor = SystemColors.Control;
            panelModuleHeader.ColumnCount = 2;
            panelModuleHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 81.8181839F));
            panelModuleHeader.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18.181818F));
            panelModuleHeader.Controls.Add(lblModuleTitle, 0, 0);
            panelModuleHeader.Controls.Add(tableLayoutPanel2, 1, 0);
            panelModuleHeader.Dock = DockStyle.Fill;
            panelModuleHeader.Location = new Point(3, 3);
            panelModuleHeader.Name = "panelModuleHeader";
            panelModuleHeader.RowCount = 1;
            panelModuleHeader.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelModuleHeader.Size = new Size(950, 38);
            panelModuleHeader.TabIndex = 3;
            // 
            // lblModuleTitle
            // 
            lblModuleTitle.AutoSize = true;
            lblModuleTitle.BackColor = SystemColors.Control;
            lblModuleTitle.Dock = DockStyle.Fill;
            lblModuleTitle.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblModuleTitle.ForeColor = Color.SteelBlue;
            lblModuleTitle.ImageAlign = ContentAlignment.MiddleLeft;
            lblModuleTitle.Location = new Point(3, 0);
            lblModuleTitle.Name = "lblModuleTitle";
            lblModuleTitle.Padding = new Padding(40, 0, 0, 0);
            lblModuleTitle.Size = new Size(771, 38);
            lblModuleTitle.TabIndex = 0;
            lblModuleTitle.Text = "lblModuleTitle";
            lblModuleTitle.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.AutoSize = true;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel2.Controls.Add(lblUserName, 0, 0);
            tableLayoutPanel2.Location = new Point(780, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle());
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(167, 32);
            tableLayoutPanel2.TabIndex = 1;
            // 
            // lblUserName
            // 
            lblUserName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblUserName.AutoSize = true;
            lblUserName.Location = new Point(3, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(161, 32);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "lblUserName";
            lblUserName.TextAlign = ContentAlignment.MiddleLeft;
            lblUserName.Visible = false;
            // 
            // statusStripMain
            // 
            statusStripMain.ImageScalingSize = new Size(24, 24);
            statusStripMain.Items.AddRange(new ToolStripItem[] { toolStripStatusLabelMain });
            statusStripMain.Location = new Point(0, 599);
            statusStripMain.Name = "statusStripMain";
            statusStripMain.Size = new Size(956, 32);
            statusStripMain.TabIndex = 5;
            statusStripMain.Text = "statusStrip1";
            // 
            // toolStripStatusLabelMain
            // 
            toolStripStatusLabelMain.Margin = new Padding(10, 4, 0, 3);
            toolStripStatusLabelMain.Name = "toolStripStatusLabelMain";
            toolStripStatusLabelMain.Size = new Size(315, 25);
            toolStripStatusLabelMain.Text = "Sistema de Gestión de Club Deportivo";
            // 
            // tabControlMain
            // 
            tabControlMain.Appearance = TabAppearance.Buttons;
            tabControlMain.Controls.Add(tabPageHome);
            tabControlMain.Controls.Add(tabPageClientes);
            tabControlMain.Controls.Add(tabPagePagos);
            tabControlMain.Controls.Add(tabPageVencimientos);
            tabControlMain.Controls.Add(tabPageActividades);
            tabControlMain.Dock = DockStyle.Fill;
            tabControlMain.ImeMode = ImeMode.NoControl;
            tabControlMain.ItemSize = new Size(100, 90);
            tabControlMain.Location = new Point(3, 47);
            tabControlMain.Name = "tabControlMain";
            tabControlMain.Padding = new Point(10, 3);
            tabControlMain.SelectedIndex = 0;
            tabControlMain.Size = new Size(950, 549);
            tabControlMain.SizeMode = TabSizeMode.Fixed;
            tabControlMain.TabIndex = 4;
            tabControlMain.SelectedIndexChanged += TabControlMain_SelectedIndexChanged;
            tabControlMain.MouseMove += TabControlMain_MouseMove;
            // 
            // tabPageHome
            // 
            tabPageHome.BackColor = Color.Transparent;
            tabPageHome.Controls.Add(panelPageHome);
            tabPageHome.Location = new Point(4, 94);
            tabPageHome.Name = "tabPageHome";
            tabPageHome.Size = new Size(942, 451);
            tabPageHome.TabIndex = 7;
            tabPageHome.Text = "Inicio";
            tabPageHome.ToolTipText = "Sistema de Gestión de Club Deportivo";
            // 
            // panelPageHome
            // 
            panelPageHome.AutoSize = true;
            panelPageHome.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelPageHome.BackColor = SystemColors.ControlLightLight;
            panelPageHome.ColumnCount = 1;
            panelPageHome.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageHome.Controls.Add(lblPanelPageHomeTitle, 0, 1);
            panelPageHome.Controls.Add(picPanelPageHomeLogo, 0, 0);
            panelPageHome.Controls.Add(lblMainNotes, 0, 2);
            panelPageHome.Dock = DockStyle.Fill;
            panelPageHome.Location = new Point(0, 0);
            panelPageHome.Name = "panelPageHome";
            panelPageHome.RowCount = 3;
            panelPageHome.RowStyles.Add(new RowStyle(SizeType.Absolute, 120F));
            panelPageHome.RowStyles.Add(new RowStyle(SizeType.Absolute, 50F));
            panelPageHome.RowStyles.Add(new RowStyle());
            panelPageHome.Size = new Size(942, 451);
            panelPageHome.TabIndex = 0;
            // 
            // lblPanelPageHomeTitle
            // 
            lblPanelPageHomeTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblPanelPageHomeTitle.AutoSize = true;
            lblPanelPageHomeTitle.BackColor = Color.Transparent;
            lblPanelPageHomeTitle.Font = new Font("Segoe UI", 14F);
            lblPanelPageHomeTitle.ForeColor = Color.Coral;
            lblPanelPageHomeTitle.Location = new Point(3, 120);
            lblPanelPageHomeTitle.Name = "lblPanelPageHomeTitle";
            lblPanelPageHomeTitle.Size = new Size(936, 50);
            lblPanelPageHomeTitle.TabIndex = 1;
            lblPanelPageHomeTitle.Text = "lblPanelPageHomeTitle";
            lblPanelPageHomeTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // picPanelPageHomeLogo
            // 
            picPanelPageHomeLogo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            picPanelPageHomeLogo.BackColor = Color.Transparent;
            picPanelPageHomeLogo.Image = Properties.Resources.logo_alpha;
            picPanelPageHomeLogo.Location = new Point(3, 15);
            picPanelPageHomeLogo.Margin = new Padding(3, 15, 3, 3);
            picPanelPageHomeLogo.Name = "picPanelPageHomeLogo";
            picPanelPageHomeLogo.Size = new Size(936, 102);
            picPanelPageHomeLogo.SizeMode = PictureBoxSizeMode.Zoom;
            picPanelPageHomeLogo.TabIndex = 2;
            picPanelPageHomeLogo.TabStop = false;
            // 
            // lblMainNotes
            // 
            lblMainNotes.BackColor = Color.Beige;
            lblMainNotes.Dock = DockStyle.Fill;
            lblMainNotes.Font = new Font("Courier New", 9F);
            lblMainNotes.Location = new Point(3, 173);
            lblMainNotes.Multiline = true;
            lblMainNotes.Name = "lblMainNotes";
            lblMainNotes.ReadOnly = true;
            lblMainNotes.ScrollBars = ScrollBars.Vertical;
            lblMainNotes.Size = new Size(936, 275);
            lblMainNotes.TabIndex = 3;
            // 
            // tabPageClientes
            // 
            tabPageClientes.Controls.Add(panelPageClientes);
            tabPageClientes.Location = new Point(4, 94);
            tabPageClientes.Name = "tabPageClientes";
            tabPageClientes.Size = new Size(942, 451);
            tabPageClientes.TabIndex = 0;
            tabPageClientes.Text = "Clientes";
            tabPageClientes.ToolTipText = "Registro y gestión de socios/no socios";
            tabPageClientes.UseVisualStyleBackColor = true;
            // 
            // panelPageClientes
            // 
            panelPageClientes.AutoSize = true;
            panelPageClientes.ColumnCount = 1;
            panelPageClientes.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageClientes.Controls.Add(viewSwitcherClientes, 0, 0);
            panelPageClientes.Dock = DockStyle.Fill;
            panelPageClientes.Location = new Point(0, 0);
            panelPageClientes.Name = "panelPageClientes";
            panelPageClientes.RowCount = 1;
            panelPageClientes.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPageClientes.Size = new Size(942, 451);
            panelPageClientes.TabIndex = 0;
            // 
            // viewSwitcherClientes
            // 
            viewSwitcherClientes.Dock = DockStyle.Fill;
            viewSwitcherClientes.Location = new Point(3, 3);
            viewSwitcherClientes.Name = "viewSwitcherClientes";
            viewSwitcherClientes.Size = new Size(936, 445);
            viewSwitcherClientes.TabIndex = 1;
            // 
            // 
            // 
            viewSwitcherClientes.View1.Location = new Point(3, 55);
            viewSwitcherClientes.View1.Name = "panelView1";
            viewSwitcherClientes.View1.TabIndex = 0;
            // 
            // 
            // 
            viewSwitcherClientes.View2.Location = new Point(3, 428);
            viewSwitcherClientes.View2.Name = "panelView2";
            viewSwitcherClientes.View2.Size = new Size(200, 14);
            viewSwitcherClientes.View2.TabIndex = 0;
            // 
            // 
            // 
            viewSwitcherClientes.View2Button.Location = new Point(626, 3);
            viewSwitcherClientes.View2Button.Name = "btnShowView2";
            viewSwitcherClientes.View2Button.TabIndex = 0;
            // 
            // tabPagePagos
            // 
            tabPagePagos.Controls.Add(panelPagePagos);
            tabPagePagos.Location = new Point(4, 94);
            tabPagePagos.Name = "tabPagePagos";
            tabPagePagos.Size = new Size(192, 2);
            tabPagePagos.TabIndex = 1;
            tabPagePagos.Text = "Pagos";
            tabPagePagos.ToolTipText = "Gestión de cuotas y registro de pagos";
            tabPagePagos.UseVisualStyleBackColor = true;
            // 
            // panelPagePagos
            // 
            panelPagePagos.AutoSize = true;
            panelPagePagos.ColumnCount = 1;
            panelPagePagos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPagePagos.Controls.Add(viewSwitcherPagos, 0, 0);
            panelPagePagos.Dock = DockStyle.Fill;
            panelPagePagos.Location = new Point(0, 0);
            panelPagePagos.Name = "panelPagePagos";
            panelPagePagos.RowCount = 1;
            panelPagePagos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPagePagos.Size = new Size(192, 2);
            panelPagePagos.TabIndex = 0;
            // 
            // viewSwitcherPagos
            // 
            viewSwitcherPagos.Dock = DockStyle.Fill;
            viewSwitcherPagos.Location = new Point(3, 3);
            viewSwitcherPagos.Name = "viewSwitcherPagos";
            viewSwitcherPagos.Size = new Size(186, 1);
            viewSwitcherPagos.TabIndex = 1;
            // 
            // 
            // 
            viewSwitcherPagos.View1.Location = new Point(3, 55);
            viewSwitcherPagos.View1.Name = "panelView1";
            viewSwitcherPagos.View1.Size = new Size(180, 1);
            viewSwitcherPagos.View1.TabIndex = 0;
            // 
            // 
            // 
            viewSwitcherPagos.View2.Location = new Point(3, -16);
            viewSwitcherPagos.View2.Name = "panelView2";
            viewSwitcherPagos.View2.Size = new Size(180, 14);
            viewSwitcherPagos.View2.TabIndex = 0;
            // 
            // 
            // 
            viewSwitcherPagos.View2Button.Location = new Point(626, 3);
            viewSwitcherPagos.View2Button.Name = "btnShowView2";
            viewSwitcherPagos.View2Button.TabIndex = 0;
            // 
            // tabPageVencimientos
            // 
            tabPageVencimientos.Controls.Add(panelPageVencimientos);
            tabPageVencimientos.Location = new Point(4, 94);
            tabPageVencimientos.Name = "tabPageVencimientos";
            tabPageVencimientos.Size = new Size(192, 2);
            tabPageVencimientos.TabIndex = 2;
            tabPageVencimientos.Text = "Vencimientos";
            tabPageVencimientos.ToolTipText = "Control de cuotas vencidas";
            tabPageVencimientos.UseVisualStyleBackColor = true;
            // 
            // panelPageVencimientos
            // 
            panelPageVencimientos.ColumnCount = 1;
            panelPageVencimientos.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageVencimientos.Dock = DockStyle.Fill;
            panelPageVencimientos.Location = new Point(0, 0);
            panelPageVencimientos.Name = "panelPageVencimientos";
            panelPageVencimientos.RowCount = 1;
            panelPageVencimientos.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPageVencimientos.Size = new Size(192, 2);
            panelPageVencimientos.TabIndex = 0;
            // 
            // tabPageActividades
            // 
            tabPageActividades.Controls.Add(viewSwitcherActividades);
            tabPageActividades.Location = new Point(4, 94);
            tabPageActividades.Name = "tabPageActividades";
            tabPageActividades.Size = new Size(192, 2);
            tabPageActividades.TabIndex = 8;
            tabPageActividades.Text = "Actividades";
            tabPageActividades.UseVisualStyleBackColor = true;
            // 
            // viewSwitcherActividades
            // 
            viewSwitcherActividades.Dock = DockStyle.Fill;
            viewSwitcherActividades.Location = new Point(0, 0);
            viewSwitcherActividades.Name = "viewSwitcherActividades";
            viewSwitcherActividades.Size = new Size(192, 2);
            viewSwitcherActividades.TabIndex = 0;
            // 
            // 
            // 
            viewSwitcherActividades.View1.Dock = DockStyle.Fill;
            viewSwitcherActividades.View1.Location = new Point(3, 55);
            viewSwitcherActividades.View1.Name = "panelView1";
            viewSwitcherActividades.View1.Size = new Size(186, 1);
            viewSwitcherActividades.View1.TabIndex = 0;
            // 
            // 
            // 
            viewSwitcherActividades.View2.Dock = DockStyle.Fill;
            viewSwitcherActividades.View2.Location = new Point(3, -15);
            viewSwitcherActividades.View2.Name = "panelView2";
            viewSwitcherActividades.View2.Size = new Size(186, 14);
            viewSwitcherActividades.View2.TabIndex = 0;
            viewSwitcherActividades.View2.Visible = false;
            // 
            // 
            // 
            viewSwitcherActividades.View2Button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            viewSwitcherActividades.View2Button.AutoSize = true;
            viewSwitcherActividades.View2Button.BackColor = SystemColors.ButtonHighlight;
            viewSwitcherActividades.View2Button.Location = new Point(626, 3);
            viewSwitcherActividades.View2Button.Name = "btnShowView2";
            viewSwitcherActividades.View2Button.Size = new Size(200, 40);
            viewSwitcherActividades.View2Button.TabIndex = 0;
            viewSwitcherActividades.View2Button.Text = "Mostrar vista 2";
            viewSwitcherActividades.View2Button.UseVisualStyleBackColor = false;
            // 
            // panelPageActividades
            // 
            panelPageActividades.ColumnCount = 1;
            panelPageActividades.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageActividades.Dock = DockStyle.Fill;
            panelPageActividades.Location = new Point(0, 0);
            panelPageActividades.Name = "panelPageActividades";
            panelPageActividades.RowCount = 1;
            panelPageActividades.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPageActividades.Size = new Size(942, 451);
            panelPageActividades.TabIndex = 0;
            // 
            // formMain
            // 
            BackColor = SystemColors.Control;
            ClientSize = new Size(956, 631);
            Controls.Add(panelMain);
            Name = "formMain";
            Load += formMain_Load;
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            panelModuleHeader.ResumeLayout(false);
            panelModuleHeader.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            statusStripMain.ResumeLayout(false);
            statusStripMain.PerformLayout();
            tabControlMain.ResumeLayout(false);
            tabPageHome.ResumeLayout(false);
            tabPageHome.PerformLayout();
            panelPageHome.ResumeLayout(false);
            panelPageHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPanelPageHomeLogo).EndInit();
            tabPageClientes.ResumeLayout(false);
            tabPageClientes.PerformLayout();
            panelPageClientes.ResumeLayout(false);
            tabPagePagos.ResumeLayout(false);
            tabPagePagos.PerformLayout();
            panelPagePagos.ResumeLayout(false);
            tabPageVencimientos.ResumeLayout(false);
            tabPageActividades.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TableLayoutPanel panelMain;
        private CustomTabControl tabControlMain;
        private TabPage tabPageHome;
        private TableLayoutPanel panelPageHome;
        private Label lblPanelPageHomeTitle;
        private PictureBox picPanelPageHomeLogo;
        private TabPage tabPageClientes;
        private TableLayoutPanel panelPageClientes;
        private TabPage tabPagePagos;
        private TableLayoutPanel panelPagePagos;
        private TabPage tabPageVencimientos;
        private TableLayoutPanel panelPageVencimientos;
        private TabPage tabPageActividades;
        private TableLayoutPanel panelPageActividades;
        
        //private TabPage tabPageProfesores;
        //private TableLayoutPanel panelPageProfesores;
        //private TabPage tabPageRutinas;
        //private TableLayoutPanel panelPageRutinas;
        //private TabPage tabPageReportes;
        //private TableLayoutPanel panelPageReportes;

        private TableLayoutPanel panelModuleHeader;
        private Label lblModuleTitle;
        private TableLayoutPanel tableLayoutPanel2;
        private Label lblUserName;
        private StatusStrip statusStripMain;
        private ToolStripStatusLabel toolStripStatusLabelMain;
        private ViewSwitcherClientes viewSwitcherClientes;
        private ViewSwitcher viewSwitcherPagos;
        private TextBox lblMainNotes;
        private ViewSwitcher viewSwitcherActividades;
    }
}