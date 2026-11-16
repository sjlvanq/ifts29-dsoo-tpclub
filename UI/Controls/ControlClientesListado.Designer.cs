namespace Club1
{
    partial class ControlClientesListado
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
            dataGridClientesListadoLista = new DataGridView();
            dniDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nombreDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            apellidoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            telefonoDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            nroCarnetDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            tieneAptoFisicoDataGridViewCheckBoxColumn = new DataGridViewCheckBoxColumn();
            socioBindingSource = new BindingSource(components);
            controlClientesDetalle1 = new ControlClientesDetalle();
            panelPageClientesListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridClientesListadoLista).BeginInit();
            ((System.ComponentModel.ISupportInitialize)socioBindingSource).BeginInit();
            SuspendLayout();
            // 
            // panelPageClientesListado
            // 
            panelPageClientesListado.ColumnCount = 1;
            panelPageClientesListado.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelPageClientesListado.Controls.Add(dataGridClientesListadoLista, 0, 0);
            panelPageClientesListado.Controls.Add(controlClientesDetalle1, 0, 1);
            panelPageClientesListado.Dock = DockStyle.Fill;
            panelPageClientesListado.Location = new Point(0, 0);
            panelPageClientesListado.Name = "panelPageClientesListado";
            panelPageClientesListado.RowCount = 2;
            panelPageClientesListado.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            panelPageClientesListado.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            panelPageClientesListado.Size = new Size(699, 532);
            panelPageClientesListado.TabIndex = 0;
            // 
            // dataGridClientesListadoLista
            // 
            dataGridClientesListadoLista.AccessibleName = "";
            dataGridClientesListadoLista.AllowUserToAddRows = false;
            dataGridClientesListadoLista.AllowUserToDeleteRows = false;
            dataGridClientesListadoLista.AllowUserToOrderColumns = true;
            dataGridClientesListadoLista.AutoGenerateColumns = false;
            dataGridClientesListadoLista.BackgroundColor = SystemColors.ControlLightLight;
            dataGridClientesListadoLista.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridClientesListadoLista.Columns.AddRange(new DataGridViewColumn[] { dniDataGridViewTextBoxColumn, nombreDataGridViewTextBoxColumn, apellidoDataGridViewTextBoxColumn, telefonoDataGridViewTextBoxColumn, nroCarnetDataGridViewTextBoxColumn, tieneAptoFisicoDataGridViewCheckBoxColumn });
            dataGridClientesListadoLista.DataSource = socioBindingSource;
            dataGridClientesListadoLista.Dock = DockStyle.Fill;
            dataGridClientesListadoLista.Location = new Point(3, 3);
            dataGridClientesListadoLista.MultiSelect = false;
            dataGridClientesListadoLista.Name = "dataGridClientesListadoLista";
            dataGridClientesListadoLista.ReadOnly = true;
            dataGridClientesListadoLista.RowHeadersWidth = 62;
            dataGridClientesListadoLista.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridClientesListadoLista.Size = new Size(693, 313);
            dataGridClientesListadoLista.StandardTab = true;
            dataGridClientesListadoLista.TabIndex = 0;
            dataGridClientesListadoLista.SelectionChanged += dataGridClientesListadoLista_SelectionChanged;
            // 
            // dniDataGridViewTextBoxColumn
            // 
            dniDataGridViewTextBoxColumn.DataPropertyName = "Dni";
            dniDataGridViewTextBoxColumn.HeaderText = "Dni";
            dniDataGridViewTextBoxColumn.MinimumWidth = 8;
            dniDataGridViewTextBoxColumn.Name = "dniDataGridViewTextBoxColumn";
            dniDataGridViewTextBoxColumn.ReadOnly = true;
            dniDataGridViewTextBoxColumn.Width = 150;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            nombreDataGridViewTextBoxColumn.MinimumWidth = 8;
            nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            nombreDataGridViewTextBoxColumn.ReadOnly = true;
            nombreDataGridViewTextBoxColumn.Width = 150;
            // 
            // apellidoDataGridViewTextBoxColumn
            // 
            apellidoDataGridViewTextBoxColumn.DataPropertyName = "Apellido";
            apellidoDataGridViewTextBoxColumn.HeaderText = "Apellido";
            apellidoDataGridViewTextBoxColumn.MinimumWidth = 8;
            apellidoDataGridViewTextBoxColumn.Name = "apellidoDataGridViewTextBoxColumn";
            apellidoDataGridViewTextBoxColumn.ReadOnly = true;
            apellidoDataGridViewTextBoxColumn.Width = 150;
            // 
            // telefonoDataGridViewTextBoxColumn
            // 
            telefonoDataGridViewTextBoxColumn.DataPropertyName = "Telefono";
            telefonoDataGridViewTextBoxColumn.HeaderText = "Telefono";
            telefonoDataGridViewTextBoxColumn.MinimumWidth = 8;
            telefonoDataGridViewTextBoxColumn.Name = "telefonoDataGridViewTextBoxColumn";
            telefonoDataGridViewTextBoxColumn.ReadOnly = true;
            telefonoDataGridViewTextBoxColumn.Width = 150;
            // 
            // nroCarnetDataGridViewTextBoxColumn
            // 
            nroCarnetDataGridViewTextBoxColumn.DataPropertyName = "NroCarnet";
            nroCarnetDataGridViewTextBoxColumn.HeaderText = "NroCarnet";
            nroCarnetDataGridViewTextBoxColumn.MinimumWidth = 8;
            nroCarnetDataGridViewTextBoxColumn.Name = "nroCarnetDataGridViewTextBoxColumn";
            nroCarnetDataGridViewTextBoxColumn.ReadOnly = true;
            nroCarnetDataGridViewTextBoxColumn.Width = 150;
            // 
            // tieneAptoFisicoDataGridViewCheckBoxColumn
            // 
            tieneAptoFisicoDataGridViewCheckBoxColumn.DataPropertyName = "TieneAptoFisico";
            tieneAptoFisicoDataGridViewCheckBoxColumn.HeaderText = "TieneAptoFisico";
            tieneAptoFisicoDataGridViewCheckBoxColumn.MinimumWidth = 8;
            tieneAptoFisicoDataGridViewCheckBoxColumn.Name = "tieneAptoFisicoDataGridViewCheckBoxColumn";
            tieneAptoFisicoDataGridViewCheckBoxColumn.ReadOnly = true;
            tieneAptoFisicoDataGridViewCheckBoxColumn.Width = 150;
            // 
            // socioBindingSource
            // 
            socioBindingSource.DataSource = typeof(Socio);
            // 
            // controlClientesDetalle1
            // 
            controlClientesDetalle1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            controlClientesDetalle1.Location = new Point(3, 348);
            controlClientesDetalle1.Name = "controlClientesDetalle1";
            controlClientesDetalle1.Size = new Size(693, 154);
            controlClientesDetalle1.TabIndex = 1;
            controlClientesDetalle1.PagosHistorialRequested += controlClientesDetalle1_PagosHistorialRequested;
            // 
            // ControlClientesListado
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPageClientesListado);
            Name = "ControlClientesListado";
            Size = new Size(699, 532);
            panelPageClientesListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridClientesListadoLista).EndInit();
            ((System.ComponentModel.ISupportInitialize)socioBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panelPageClientesListado;
        private DataGridView dataGridClientesListadoLista;
        private BindingSource socioBindingSource;
        private ControlClientesDetalle controlClientesDetalle1;
        private DataGridViewTextBoxColumn dniDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn apellidoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn telefonoDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn nroCarnetDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn tieneAptoFisicoDataGridViewCheckBoxColumn;
    }
}
