namespace Club1.UI.Controls
{
    public partial class ViewSwitcher
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            layoutViewSwitcher = new TableLayoutPanel();
            panelView1 = new Panel();
            panelView2 = new Panel();
            layoutViewSwitcherHeader = new TableLayoutPanel();
            lnkLblBack = new LinkLabel();
            btnShowView2 = new Button();
            controlFiltros = new ControlFiltros();
            layoutViewSwitcher.SuspendLayout();
            layoutViewSwitcherHeader.SuspendLayout();
            SuspendLayout();
            // 
            // layoutViewSwitcher
            // 
            layoutViewSwitcher.ColumnCount = 1;
            layoutViewSwitcher.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layoutViewSwitcher.Controls.Add(panelView1, 0, 1);
            layoutViewSwitcher.Controls.Add(panelView2, 0, 1);
            layoutViewSwitcher.Controls.Add(layoutViewSwitcherHeader, 0, 0);
            layoutViewSwitcher.Dock = DockStyle.Fill;
            layoutViewSwitcher.Location = new Point(0, 0);
            layoutViewSwitcher.Name = "layoutViewSwitcher";
            layoutViewSwitcher.RowCount = 2;
            layoutViewSwitcher.RowStyles.Add(new RowStyle());
            layoutViewSwitcher.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layoutViewSwitcher.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            layoutViewSwitcher.Size = new Size(959, 200);
            layoutViewSwitcher.TabIndex = 0;
            // 
            // panelView1
            // 
            panelView1.Dock = DockStyle.Fill;
            panelView1.Location = new Point(3, 55);
            panelView1.Name = "panelView1";
            panelView1.Size = new Size(953, 122);
            panelView1.TabIndex = 0;
            // 
            // panelView2
            // 
            panelView2.Dock = DockStyle.Fill;
            panelView2.Location = new Point(3, 183);
            panelView2.Name = "panelView2";
            panelView2.Size = new Size(953, 14);
            panelView2.TabIndex = 0;
            panelView2.Visible = false;
            // 
            // layoutViewSwitcherHeader
            // 
            layoutViewSwitcherHeader.AutoSize = true;
            layoutViewSwitcherHeader.ColumnCount = 3;
            layoutViewSwitcherHeader.ColumnStyles.Add(new ColumnStyle());
            layoutViewSwitcherHeader.ColumnStyles.Add(new ColumnStyle());
            layoutViewSwitcherHeader.ColumnStyles.Add(new ColumnStyle());
            layoutViewSwitcherHeader.Controls.Add(lnkLblBack, 0, 0);
            layoutViewSwitcherHeader.Controls.Add(btnShowView2, 2, 0);
            layoutViewSwitcherHeader.Controls.Add(controlFiltros, 1, 0);
            layoutViewSwitcherHeader.Dock = DockStyle.Fill;
            layoutViewSwitcherHeader.Location = new Point(3, 3);
            layoutViewSwitcherHeader.Name = "layoutViewSwitcherHeader";
            layoutViewSwitcherHeader.RowCount = 1;
            layoutViewSwitcherHeader.RowStyles.Add(new RowStyle());
            layoutViewSwitcherHeader.Size = new Size(953, 46);
            layoutViewSwitcherHeader.TabIndex = 0;
            // 
            // lnkLblBack
            // 
            lnkLblBack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lnkLblBack.AutoSize = true;
            lnkLblBack.Location = new Point(3, 0);
            lnkLblBack.Name = "lnkLblBack";
            lnkLblBack.Padding = new Padding(15, 0, 15, 0);
            lnkLblBack.Size = new Size(91, 46);
            lnkLblBack.TabIndex = 0;
            lnkLblBack.TabStop = true;
            lnkLblBack.Text = "Volver";
            lnkLblBack.TextAlign = ContentAlignment.MiddleCenter;
            lnkLblBack.Visible = false;
            lnkLblBack.LinkClicked += lnkLblBack_LinkClicked;
            // 
            // btnShowView2
            // 
            btnShowView2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnShowView2.AutoSize = true;
            btnShowView2.BackColor = SystemColors.ButtonHighlight;
            btnShowView2.Location = new Point(792, 3);
            btnShowView2.Name = "btnShowView2";
            btnShowView2.Size = new Size(158, 40);
            btnShowView2.TabIndex = 0;
            btnShowView2.Text = "Mostrar vista 2";
            btnShowView2.UseVisualStyleBackColor = false;
            btnShowView2.Click += btnShowView2_Click;
            // 
            // controlFiltros
            // 
            controlFiltros.AutoSize = true;
            controlFiltros.Dock = DockStyle.Fill;
            controlFiltros.Location = new Point(100, 3);
            controlFiltros.Name = "controlFiltros";
            controlFiltros.Size = new Size(617, 40);
            controlFiltros.TabIndex = 1;
            // 
            // ViewSwitcher
            // 
            Controls.Add(layoutViewSwitcher);
            Name = "ViewSwitcher";
            Size = new Size(959, 200);
            layoutViewSwitcher.ResumeLayout(false);
            layoutViewSwitcher.PerformLayout();
            layoutViewSwitcherHeader.ResumeLayout(false);
            layoutViewSwitcherHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel layoutViewSwitcher;
        private Panel panelView1;
        private Panel panelView2;
        private TableLayoutPanel layoutViewSwitcherHeader;
        private Button btnShowView2;
        private LinkLabel lnkLblBack;
        private ControlFiltros controlFiltros;
    }
}
