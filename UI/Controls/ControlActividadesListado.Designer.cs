namespace Club1.UI.Controls
{
    partial class ControlActividadesListado
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
            panelPageClientesListado = new TableLayoutPanel();
            dataGridActividadesListadoLista = new DataGridView();
            actividadBindingSource = new BindingSource(components);
            panelPageClientesListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridActividadesListadoLista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)actividadBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panelPageClientesListado
            // 
            panelPageClientesListado.ColumnCount = 1;
            panelPageClientesListado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageClientesListado.Controls.Add(dataGridActividadesListadoLista, 0, 0);
            panelPageClientesListado.Dock = DockStyle.Fill;
            panelPageClientesListado.Location = new Point(0, 0);
            panelPageClientesListado.Name = "panelPageClientesListado";
            panelPageClientesListado.RowCount = 1;
            panelPageClientesListado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPageClientesListado.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListado.Size = new Size(699, 532);
            panelPageClientesListado.TabIndex = 0;
            // 
            // dataGridActividadesListadoLista
            // 
            dataGridActividadesListadoLista.AllowUserToAddRows = false;
            dataGridActividadesListadoLista.AllowUserToDeleteRows = false;
            dataGridActividadesListadoLista.AllowUserToOrderColumns = true;
            dataGridActividadesListadoLista.AutoGenerateColumns = false;
            dataGridActividadesListadoLista.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridActividadesListadoLista.BackgroundColor = SystemColors.ControlLightLight;
            dataGridActividadesListadoLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridActividadesListadoLista.DataSource = actividadBindingSource;
            dataGridActividadesListadoLista.Dock = DockStyle.Fill;
            dataGridActividadesListadoLista.Location = new Point(3, 3);
            dataGridActividadesListadoLista.MultiSelect = false;
            dataGridActividadesListadoLista.Name = "dataGridActividadesListadoLista";
            dataGridActividadesListadoLista.ReadOnly = true;
            dataGridActividadesListadoLista.RowHeadersWidth = 62;
            dataGridActividadesListadoLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridActividadesListadoLista.Size = new Size(693, 526);
            dataGridActividadesListadoLista.StandardTab = true;
            dataGridActividadesListadoLista.TabIndex = 0;
            // 
            // ControlActividadesListado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPageClientesListado);
            Name = "ControlActividadesListado";
            Size = new Size(699, 532);
            panelPageClientesListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridActividadesListadoLista).EndInit();
            ((System.ComponentModel.ISupportInitialize)actividadBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panelPageClientesListado;
        private DataGridView dataGridActividadesListadoLista;
        private BindingSource actividadBindingSource;
    }
}
