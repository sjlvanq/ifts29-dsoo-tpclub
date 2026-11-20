namespace Club1.UI.Controls
{
    partial class ControlVencimientosListado
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
            panelPageVencimientosListado = new TableLayoutPanel();
            dataGridVencimientosListadoLista = new DataGridView();
            vencimientoBindingSource = new BindingSource(components);
            lblControlVencimientoListadoHeader = new Label();
            panelPageVencimientosListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVencimientosListadoLista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)vencimientoBindingSource).BeginInit();
            SuspendLayout();
            //
            // panelPageVencimientosListado
            //
            panelPageVencimientosListado.ColumnCount = 1;
            panelPageVencimientosListado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageVencimientosListado.Controls.Add(dataGridVencimientosListadoLista, 0, 1);
            panelPageVencimientosListado.Controls.Add(lblControlVencimientoListadoHeader, 0, 0);
            panelPageVencimientosListado.Dock = DockStyle.Fill;
            panelPageVencimientosListado.Location = new Point(0, 0);
            panelPageVencimientosListado.Name = "panelPageVencimientosListado";
            panelPageVencimientosListado.RowCount = 2;
            panelPageVencimientosListado.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            panelPageVencimientosListado.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            panelPageVencimientosListado.Size = new Size(763, 491);
            panelPageVencimientosListado.TabIndex = 0;
            //
            // dataGridVencimientosListadoLista
            //
            dataGridVencimientosListadoLista.AccessibleName = "";
            dataGridVencimientosListadoLista.AllowUserToAddRows = false;
            dataGridVencimientosListadoLista.AllowUserToDeleteRows = false;
            dataGridVencimientosListadoLista.AllowUserToOrderColumns = true;
            dataGridVencimientosListadoLista.AutoGenerateColumns = false;
            dataGridVencimientosListadoLista.BackgroundColor = SystemColors.ControlLightLight;
            dataGridVencimientosListadoLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridVencimientosListadoLista.DataSource = vencimientoBindingSource;
            dataGridVencimientosListadoLista.Dock = DockStyle.Fill;
            dataGridVencimientosListadoLista.Location = new Point(3, 43);
            dataGridVencimientosListadoLista.MultiSelect = false;
            dataGridVencimientosListadoLista.Name = "dataGridVencimientosListadoLista";
            dataGridVencimientosListadoLista.ReadOnly = true;
            dataGridVencimientosListadoLista.RowHeadersWidth = 62;
            dataGridVencimientosListadoLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridVencimientosListadoLista.Size = new Size(757, 445);
            dataGridVencimientosListadoLista.StandardTab = true;
            dataGridVencimientosListadoLista.TabIndex = 1;
            //
            // lblControlVencimientoListadoHeader
            //
            lblControlVencimientoListadoHeader.AutoSize = true;
            lblControlVencimientoListadoHeader.BackColor = SystemColors.Info;
            lblControlVencimientoListadoHeader.Dock = DockStyle.Fill;
            lblControlVencimientoListadoHeader.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblControlVencimientoListadoHeader.Location = new Point(3, 0);
            lblControlVencimientoListadoHeader.Name = "lblControlVencimientoListadoHeader";
            lblControlVencimientoListadoHeader.Size = new Size(757, 40);
            lblControlVencimientoListadoHeader.TabIndex = 2;
            lblControlVencimientoListadoHeader.Text = "lblControlVencimientoListadoHeader";
            lblControlVencimientoListadoHeader.TextAlign = ContentAlignment.MiddleCenter;
            //
            // ControlVencimientosListado
            //
            Controls.Add(panelPageVencimientosListado);
            Name = "ControlVencimientosListado";
            Size = new Size(763, 491);
            panelPageVencimientosListado.ResumeLayout(false);
            panelPageVencimientosListado.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridVencimientosListadoLista).EndInit();
            ((System.ComponentModel.ISupportInitialize)vencimientoBindingSource).EndInit();
            ResumeLayout(false);
        }



        #endregion

        private TableLayoutPanel panelPageVencimientosListado;
        private DataGridView dataGridVencimientosListadoLista;
        private BindingSource vencimientoBindingSource;
        private Label lblControlVencimientoListadoHeader;
    }
}
