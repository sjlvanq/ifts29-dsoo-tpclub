namespace Club1
{
    partial class ControlPagosDetalle
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
            panelPagePagosListadoDetalle = new TableLayoutPanel();
            panelPagePagosListadoDetalleAcciones = new TableLayoutPanel();
            btnPagePagosListadoDetalleEliminar = new Button();
            btnPagePagosListadoDetalleConsultarProximoVencimiento = new Button();
            btnPagePagosListadoDetalleGenerarComprobante = new Button();
            controlPagoDetalleInfo = new ControlPagoDetalleInfo();
            panelPagePagosListadoDetalle.SuspendLayout();
            panelPagePagosListadoDetalleAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelPagePagosListadoDetalle
            // 
            panelPagePagosListadoDetalle.AutoSize = false;
            panelPagePagosListadoDetalle.ColumnCount = 2;
            panelPagePagosListadoDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPagePagosListadoDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPagePagosListadoDetalle.Controls.Add(panelPagePagosListadoDetalleAcciones, 1, 0);
            panelPagePagosListadoDetalle.Controls.Add(controlPagoDetalleInfo, 0, 0);
            panelPagePagosListadoDetalle.Dock = DockStyle.Fill;
            panelPagePagosListadoDetalle.Location = new Point(0, 0);
            panelPagePagosListadoDetalle.Name = "panelPagePagosListadoDetalle";
            panelPagePagosListadoDetalle.RowCount = 1;
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelPagePagosListadoDetalle.Size = new Size(632, 424);
            panelPagePagosListadoDetalle.TabIndex = 0;
            panelPagePagosListadoDetalle.Paint += tableLayoutPanel1_Paint;
            // 
            // panelPagePagosListadoDetalleAcciones
            // 
            panelPagePagosListadoDetalleAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panelPagePagosListadoDetalleAcciones.AutoSize = false;
            panelPagePagosListadoDetalleAcciones.ColumnCount = 1;
            panelPagePagosListadoDetalleAcciones.ColumnStyles.Add(new ColumnStyle());
            panelPagePagosListadoDetalleAcciones.Controls.Add(btnPagePagosListadoDetalleEliminar, 0, 2);
            panelPagePagosListadoDetalleAcciones.Controls.Add(btnPagePagosListadoDetalleConsultarProximoVencimiento, 0, 1);
            panelPagePagosListadoDetalleAcciones.Controls.Add(btnPagePagosListadoDetalleGenerarComprobante, 0, 0);
            panelPagePagosListadoDetalleAcciones.Dock = DockStyle.Fill;
            panelPagePagosListadoDetalleAcciones.Location = new Point(319, 3);
            panelPagePagosListadoDetalleAcciones.Name = "panelPagePagosListadoDetalleAcciones";
            panelPagePagosListadoDetalleAcciones.RowCount = 3;
            panelPagePagosListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPagePagosListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPagePagosListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPagePagosListadoDetalleAcciones.Size = new Size(310, 418);
            panelPagePagosListadoDetalleAcciones.TabIndex = 0;
            // 
            // btnPagePagosListadoDetalleEliminar
            // 
            btnPagePagosListadoDetalleEliminar.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPagePagosListadoDetalleEliminar.AutoSize = false;
            btnPagePagosListadoDetalleEliminar.Location = new Point(3, 330);
            btnPagePagosListadoDetalleEliminar.Name = "btnPagePagosListadoDetalleEliminar";
            btnPagePagosListadoDetalleEliminar.Size = new Size(304, 35);
            btnPagePagosListadoDetalleEliminar.TabIndex = 2;
            btnPagePagosListadoDetalleEliminar.Text = "Eliminar";
            btnPagePagosListadoDetalleEliminar.UseVisualStyleBackColor = true;
            // 
            // btnPagePagosListadoDetalleConsultarProximoVencimiento
            // 
            btnPagePagosListadoDetalleConsultarProximoVencimiento.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPagePagosListadoDetalleConsultarProximoVencimiento.AutoSize = false;
            btnPagePagosListadoDetalleConsultarProximoVencimiento.Location = new Point(3, 191);
            btnPagePagosListadoDetalleConsultarProximoVencimiento.Name = "btnPagePagosListadoDetalleConsultarProximoVencimiento";
            btnPagePagosListadoDetalleConsultarProximoVencimiento.Size = new Size(304, 35);
            btnPagePagosListadoDetalleConsultarProximoVencimiento.TabIndex = 1;
            btnPagePagosListadoDetalleConsultarProximoVencimiento.Text = "Consultar Próximo Vencimientos";
            btnPagePagosListadoDetalleConsultarProximoVencimiento.UseVisualStyleBackColor = true;
            // 
            // btnPagePagosListadoDetalleGenerarComprobante
            // 
            btnPagePagosListadoDetalleGenerarComprobante.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btnPagePagosListadoDetalleGenerarComprobante.AutoSize = false;
            btnPagePagosListadoDetalleGenerarComprobante.Location = new Point(3, 52);
            btnPagePagosListadoDetalleGenerarComprobante.Name = "btnPagePagosListadoDetalleGenerarComprobante";
            btnPagePagosListadoDetalleGenerarComprobante.Size = new Size(304, 35);
            btnPagePagosListadoDetalleGenerarComprobante.TabIndex = 0;
            btnPagePagosListadoDetalleGenerarComprobante.Text = "Generar Comprobante";
            btnPagePagosListadoDetalleGenerarComprobante.UseVisualStyleBackColor = true;
            btnPagePagosListadoDetalleGenerarComprobante.Click += btnPagePagosListadoDetalleGenerarCarnet_Click;
            // 
            // controlPagoDetalleInfo
            // 
            controlPagoDetalleInfo.AutoSize = false;
            controlPagoDetalleInfo.BackColor = Color.Gray;
            controlPagoDetalleInfo.Dock = DockStyle.Fill;
            controlPagoDetalleInfo.Location = new Point(3, 0);
            controlPagoDetalleInfo.Name = "controlPagoDetalleInfo";
            controlPagoDetalleInfo.Size = new Size(310, 424);
            controlPagoDetalleInfo.TabIndex = 1;
            controlPagoDetalleInfo.Text = "Seleccione un pago\r\npara habilitar los botones\r\nde acción.\r\n";
            // 
            // ControlPagosDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPagePagosListadoDetalle);
            Name = "ControlPagosDetalle";
            Size = new Size(632, 424);
            panelPagePagosListadoDetalle.ResumeLayout(false);
            panelPagePagosListadoDetalle.PerformLayout();
            panelPagePagosListadoDetalleAcciones.ResumeLayout(false);
            panelPagePagosListadoDetalleAcciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel panelPagePagosListadoDetalle;
        private TableLayoutPanel panelPagePagosListadoDetalleAcciones;
        private Button btnPagePagosListadoDetalleGenerarComprobante;
        private Button btnPagePagosListadoDetalleConsultarProximoVencimiento;
        private Button btnPagePagosListadoDetalleEliminar;
        private ControlPagoDetalleInfo controlPagoDetalleInfo;
    }
}
