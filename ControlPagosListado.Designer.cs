namespace Club1
{
    partial class ControlPagosListado
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
            components = new System.ComponentModel.Container();
            panelPagePagosListado = new TableLayoutPanel();
            dataGridPagosListadoLista = new DataGridView();
            pagoBindingSource = new BindingSource(components);
            controlPagoDetalle = new ControlPagosDetalle();
            panelPagePagosListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridPagosListadoLista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pagoBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panelPagePagosListado
            // 
            panelPagePagosListado.ColumnCount = 1;
            panelPagePagosListado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPagePagosListado.Controls.Add(dataGridPagosListadoLista, 0, 0);
            panelPagePagosListado.Controls.Add(controlPagoDetalle, 0, 1);
            panelPagePagosListado.Dock = DockStyle.Fill;
            panelPagePagosListado.Location = new Point(0, 0);
            panelPagePagosListado.Name = "panelPagePagosListado";
            panelPagePagosListado.RowCount = 2;
            panelPagePagosListado.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            panelPagePagosListado.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            panelPagePagosListado.Size = new Size(763, 491);
            panelPagePagosListado.TabIndex = 0;
            // 
            // dataGridPagosListadoLista
            // 
            dataGridPagosListadoLista.AccessibleName = "";
            dataGridPagosListadoLista.AllowUserToAddRows = false;
            dataGridPagosListadoLista.AllowUserToDeleteRows = false;
            dataGridPagosListadoLista.AllowUserToOrderColumns = true;
            dataGridPagosListadoLista.AutoGenerateColumns = false;
            dataGridPagosListadoLista.BackgroundColor = SystemColors.ControlLightLight;
            dataGridPagosListadoLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridPagosListadoLista.DataSource = pagoBindingSource;
            dataGridPagosListadoLista.Dock = DockStyle.Fill;
            dataGridPagosListadoLista.Location = new Point(3, 3);
            dataGridPagosListadoLista.MultiSelect = false;
            dataGridPagosListadoLista.Name = "dataGridPagosListadoLista";
            dataGridPagosListadoLista.ReadOnly = true;
            dataGridPagosListadoLista.RowHeadersWidth = 62;
            dataGridPagosListadoLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridPagosListadoLista.Size = new Size(757, 239);
            dataGridPagosListadoLista.StandardTab = true;
            dataGridPagosListadoLista.TabIndex = 1;
            dataGridPagosListadoLista.SelectionChanged += dataGridPagosListadoLista_SelectionChanged;
            // 
            // controlPagoDetalle
            // 
            controlPagoDetalle.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            controlPagoDetalle.Location = new Point(3, 348);
            controlPagoDetalle.Name = "controlPagoDetalle";
            controlPagoDetalle.Size = new Size(757, 154);
            controlPagoDetalle.TabIndex = 2;
            // 
            // ControlPagosListado
            // 
            Controls.Add(panelPagePagosListado);
            Name = "ControlPagosListado";
            Size = new Size(763, 491);
            panelPagePagosListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridPagosListadoLista).EndInit();
            ((System.ComponentModel.ISupportInitialize)pagoBindingSource).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private TableLayoutPanel panelPagePagosListado;
        private DataGridView dataGridPagosListadoLista;
        private BindingSource pagoBindingSource;
        private ControlPagosDetalle controlPagoDetalle;
    }
}
