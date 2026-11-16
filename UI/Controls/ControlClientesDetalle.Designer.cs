namespace Club1.UI.Controls
{
    partial class ControlClientesDetalle
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
            panelPageClientesListadoDetalle = new TableLayoutPanel();
            panelPageClientesListadoDetalleAcciones = new TableLayoutPanel();
            btnPageClientesListadoDetalleEliminar = new Button();
            btnPageClientesListadoDetalleConsultarPagos = new Button();
            btnPageClientesListadoDetalleGenerarCarnet = new Button();
            controlClienteDetalleInfo1 = new ControlClienteDetalleInfo();
            panelPageClientesListadoDetalle.SuspendLayout();
            panelPageClientesListadoDetalleAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelPageClientesListadoDetalle
            // 
            panelPageClientesListadoDetalle.ColumnCount = 2;
            panelPageClientesListadoDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPageClientesListadoDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPageClientesListadoDetalle.Controls.Add(panelPageClientesListadoDetalleAcciones, 1, 0);
            panelPageClientesListadoDetalle.Controls.Add(controlClienteDetalleInfo1, 0, 0);
            panelPageClientesListadoDetalle.Dock = DockStyle.Fill;
            panelPageClientesListadoDetalle.Location = new Point(0, 0);
            panelPageClientesListadoDetalle.Name = "panelPageClientesListadoDetalle";
            panelPageClientesListadoDetalle.RowCount = 1;
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPageClientesListadoDetalle.Size = new Size(632, 424);
            panelPageClientesListadoDetalle.TabIndex = 0;
            // 
            // panelPageClientesListadoDetalleAcciones
            // 
            panelPageClientesListadoDetalleAcciones.ColumnCount = 1;
            panelPageClientesListadoDetalleAcciones.ColumnStyles.Add(new ColumnStyle());
            panelPageClientesListadoDetalleAcciones.Controls.Add(btnPageClientesListadoDetalleEliminar, 0, 2);
            panelPageClientesListadoDetalleAcciones.Controls.Add(btnPageClientesListadoDetalleConsultarPagos, 0, 1);
            panelPageClientesListadoDetalleAcciones.Controls.Add(btnPageClientesListadoDetalleGenerarCarnet, 0, 0);
            panelPageClientesListadoDetalleAcciones.Dock = DockStyle.Fill;
            panelPageClientesListadoDetalleAcciones.Location = new Point(319, 3);
            panelPageClientesListadoDetalleAcciones.Name = "panelPageClientesListadoDetalleAcciones";
            panelPageClientesListadoDetalleAcciones.RowCount = 3;
            panelPageClientesListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPageClientesListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPageClientesListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPageClientesListadoDetalleAcciones.Size = new Size(310, 418);
            panelPageClientesListadoDetalleAcciones.TabIndex = 0;
            // 
            // btnPageClientesListadoDetalleEliminar
            // 
            btnPageClientesListadoDetalleEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPageClientesListadoDetalleEliminar.Enabled = false;
            btnPageClientesListadoDetalleEliminar.Location = new Point(3, 281);
            btnPageClientesListadoDetalleEliminar.Name = "btnPageClientesListadoDetalleEliminar";
            btnPageClientesListadoDetalleEliminar.Size = new Size(304, 134);
            btnPageClientesListadoDetalleEliminar.TabIndex = 2;
            btnPageClientesListadoDetalleEliminar.Text = "Eliminar";
            btnPageClientesListadoDetalleEliminar.UseVisualStyleBackColor = true;
            // 
            // btnPageClientesListadoDetalleConsultarPagos
            // 
            btnPageClientesListadoDetalleConsultarPagos.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPageClientesListadoDetalleConsultarPagos.Enabled = false;
            btnPageClientesListadoDetalleConsultarPagos.Location = new Point(3, 142);
            btnPageClientesListadoDetalleConsultarPagos.Name = "btnPageClientesListadoDetalleConsultarPagos";
            btnPageClientesListadoDetalleConsultarPagos.Size = new Size(304, 133);
            btnPageClientesListadoDetalleConsultarPagos.TabIndex = 1;
            btnPageClientesListadoDetalleConsultarPagos.Text = "Consultar Pagos";
            btnPageClientesListadoDetalleConsultarPagos.UseVisualStyleBackColor = true;
            btnPageClientesListadoDetalleConsultarPagos.Click += btnPageClientesListadoDetalleConsultarPagos_Click;
            // 
            // btnPageClientesListadoDetalleGenerarCarnet
            // 
            btnPageClientesListadoDetalleGenerarCarnet.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPageClientesListadoDetalleGenerarCarnet.Enabled = false;
            btnPageClientesListadoDetalleGenerarCarnet.Location = new Point(3, 3);
            btnPageClientesListadoDetalleGenerarCarnet.Name = "btnPageClientesListadoDetalleGenerarCarnet";
            btnPageClientesListadoDetalleGenerarCarnet.Size = new Size(304, 133);
            btnPageClientesListadoDetalleGenerarCarnet.TabIndex = 0;
            btnPageClientesListadoDetalleGenerarCarnet.Text = "Generar Carnet";
            btnPageClientesListadoDetalleGenerarCarnet.UseVisualStyleBackColor = true;
            btnPageClientesListadoDetalleGenerarCarnet.Click += btnPageClientesListadoDetalleGenerarCarnet_Click;
            // 
            // controlClienteDetalleInfo1
            // 
            controlClienteDetalleInfo1.Dock = DockStyle.Fill;
            controlClienteDetalleInfo1.Location = new Point(3, 3);
            controlClienteDetalleInfo1.Name = "controlClienteDetalleInfo1";
            controlClienteDetalleInfo1.Size = new Size(310, 418);
            controlClienteDetalleInfo1.TabIndex = 1;
            // 
            // ControlClientesDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPageClientesListadoDetalle);
            Name = "ControlClientesDetalle";
            Size = new Size(632, 424);
            panelPageClientesListadoDetalle.ResumeLayout(false);
            panelPageClientesListadoDetalleAcciones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel panelPageClientesListadoDetalle;
        private TableLayoutPanel panelPageClientesListadoDetalleAcciones;
        private Button btnPageClientesListadoDetalleGenerarCarnet;
        private Button btnPageClientesListadoDetalleConsultarPagos;
        private Button btnPageClientesListadoDetalleEliminar;
        private ControlClienteDetalleInfo controlClienteDetalleInfo1;
    }
}
