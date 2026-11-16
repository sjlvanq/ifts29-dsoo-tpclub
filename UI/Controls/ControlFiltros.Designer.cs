namespace Club1.UI.Controls
{
    partial class ControlFiltros
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
            panelControlFiltros = new TableLayoutPanel();
            lblControlFiltrosFiltro = new Label();
            txtControlFiltrosSearch = new TextBox();
            cmbControlFiltrosField = new ComboBox();
            lnkLblControlFiltrosLimpiar = new LinkLabel();
            panelControlFiltros.SuspendLayout();
            SuspendLayout();
            // 
            // panelControlFiltros
            // 
            panelControlFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            panelControlFiltros.AutoSize = true;
            panelControlFiltros.ColumnCount = 4;
            panelControlFiltros.ColumnStyles.Add(new ColumnStyle());
            panelControlFiltros.ColumnStyles.Add(new ColumnStyle());
            panelControlFiltros.ColumnStyles.Add(new ColumnStyle());
            panelControlFiltros.ColumnStyles.Add(new ColumnStyle());
            panelControlFiltros.Controls.Add(lblControlFiltrosFiltro, 0, 0);
            panelControlFiltros.Controls.Add(txtControlFiltrosSearch, 2, 0);
            panelControlFiltros.Controls.Add(cmbControlFiltrosField, 1, 0);
            panelControlFiltros.Controls.Add(lnkLblControlFiltrosLimpiar, 3, 0);
            panelControlFiltros.Location = new Point(0, 0);
            panelControlFiltros.Name = "panelControlFiltros";
            panelControlFiltros.RowCount = 1;
            panelControlFiltros.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelControlFiltros.Size = new Size(614, 92);
            panelControlFiltros.TabIndex = 0;
            // 
            // lblControlFiltrosFiltro
            // 
            lblControlFiltrosFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblControlFiltrosFiltro.AutoSize = true;
            lblControlFiltrosFiltro.Location = new Point(3, 0);
            lblControlFiltrosFiltro.Name = "lblControlFiltrosFiltro";
            lblControlFiltrosFiltro.Size = new Size(52, 92);
            lblControlFiltrosFiltro.TabIndex = 0;
            lblControlFiltrosFiltro.Text = "Filtro";
            lblControlFiltrosFiltro.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtControlFiltrosSearch
            // 
            txtControlFiltrosSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            txtControlFiltrosSearch.Location = new Point(291, 3);
            txtControlFiltrosSearch.Name = "txtControlFiltrosSearch";
            txtControlFiltrosSearch.Size = new Size(224, 31);
            txtControlFiltrosSearch.TabIndex = 1;
            // 
            // cmbControlFiltrosField
            // 
            cmbControlFiltrosField.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            cmbControlFiltrosField.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbControlFiltrosField.FormattingEnabled = true;
            cmbControlFiltrosField.Location = new Point(61, 3);
            cmbControlFiltrosField.Name = "cmbControlFiltrosField";
            cmbControlFiltrosField.Size = new Size(224, 33);
            cmbControlFiltrosField.TabIndex = 2;
            cmbControlFiltrosField.SelectedIndexChanged += cmbControlFiltrosField_SelectedIndexChanged;
            // 
            // lnkLblControlFiltrosLimpiar
            // 
            lnkLblControlFiltrosLimpiar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lnkLblControlFiltrosLimpiar.AutoSize = true;
            lnkLblControlFiltrosLimpiar.Location = new Point(521, 0);
            lnkLblControlFiltrosLimpiar.Name = "lnkLblControlFiltrosLimpiar";
            lnkLblControlFiltrosLimpiar.Size = new Size(90, 92);
            lnkLblControlFiltrosLimpiar.TabIndex = 3;
            lnkLblControlFiltrosLimpiar.TabStop = true;
            lnkLblControlFiltrosLimpiar.Text = "Limpiar";
            lnkLblControlFiltrosLimpiar.TextAlign = ContentAlignment.MiddleCenter;
            lnkLblControlFiltrosLimpiar.LinkClicked += lnkLblControlFiltrosLimpiar_LinkClicked;
            // 
            // ControlFiltros
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelControlFiltros);
            Name = "ControlFiltros";
            Size = new Size(713, 92);
            panelControlFiltros.ResumeLayout(false);
            panelControlFiltros.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel panelControlFiltros;
        private Label lblControlFiltrosFiltro;
        private TextBox txtControlFiltrosSearch;
        private ComboBox cmbControlFiltrosField;
        private LinkLabel lnkLblControlFiltrosLimpiar;
    }
}
