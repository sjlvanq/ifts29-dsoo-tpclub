namespace Club1
{
    partial class ControlActividadesDetalle
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
            ControlClienteDetalleLabel1 = new ControlClienteDetalleLabel();
            panelPageClientesListadoDetalle.SuspendLayout();
            panelPageClientesListadoDetalleAcciones.SuspendLayout();
            SuspendLayout();
            // 
            // panelPageClientesListadoDetalle
            // 
            panelPageClientesListadoDetalle.AutoSize = true;
            panelPageClientesListadoDetalle.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelPageClientesListadoDetalle.ColumnCount = 2;
            panelPageClientesListadoDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPageClientesListadoDetalle.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            panelPageClientesListadoDetalle.Controls.Add(panelPageClientesListadoDetalleAcciones, 1, 0);
            panelPageClientesListadoDetalle.Controls.Add(ControlClienteDetalleLabel1, 0, 0);
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
            panelPageClientesListadoDetalle.Paint += tableLayoutPanel1_Paint;
            // 
            // panelPageClientesListadoDetalleAcciones
            // 
            panelPageClientesListadoDetalleAcciones.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            panelPageClientesListadoDetalleAcciones.ColumnCount = 1;
            panelPageClientesListadoDetalleAcciones.ColumnStyles.Add(new ColumnStyle());
            panelPageClientesListadoDetalleAcciones.Controls.Add(btnPageClientesListadoDetalleEliminar, 0, 2);
            panelPageClientesListadoDetalleAcciones.Location = new Point(324, 3);
            panelPageClientesListadoDetalleAcciones.Name = "panelPageClientesListadoDetalleAcciones";
            panelPageClientesListadoDetalleAcciones.RowCount = 3;
            panelPageClientesListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPageClientesListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPageClientesListadoDetalleAcciones.RowStyles.Add(new RowStyle(SizeType.Percent, 33.3333321F));
            panelPageClientesListadoDetalleAcciones.Size = new Size(300, 418);
            panelPageClientesListadoDetalleAcciones.TabIndex = 0;
            // 
            // btnPageClientesListadoDetalleEliminar
            // 
            btnPageClientesListadoDetalleEliminar.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            btnPageClientesListadoDetalleEliminar.AutoSize = true;
            btnPageClientesListadoDetalleEliminar.Location = new Point(3, 330);
            btnPageClientesListadoDetalleEliminar.Name = "btnPageClientesListadoDetalleEliminar";
            btnPageClientesListadoDetalleEliminar.Size = new Size(294, 35);
            btnPageClientesListadoDetalleEliminar.TabIndex = 2;
            btnPageClientesListadoDetalleEliminar.Text = "Eliminar";
            btnPageClientesListadoDetalleEliminar.UseVisualStyleBackColor = true;
            // 
            // ControlClienteDetalleLabel1
            // 
            ControlClienteDetalleLabel1.BackColor = Color.Gray;
            ControlClienteDetalleLabel1.Dock = DockStyle.Fill;
            ControlClienteDetalleLabel1.Location = new Point(3, 0);
            ControlClienteDetalleLabel1.Name = "ControlClienteDetalleLabel1";
            ControlClienteDetalleLabel1.Size = new Size(310, 424);
            ControlClienteDetalleLabel1.TabIndex = 1;
            ControlClienteDetalleLabel1.Text = "Seleccione un cliente\r\npara habilitar los botones\r\nde acción.\r\n";
            ControlClienteDetalleLabel1.Click += ControlClienteDetalleLabel1_Click;
            // 
            // ControlActividadesDetalle
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panelPageClientesListadoDetalle);
            Name = "ControlActividadesDetalle";
            Size = new Size(632, 424);
            panelPageClientesListadoDetalle.ResumeLayout(false);
            panelPageClientesListadoDetalleAcciones.ResumeLayout(false);
            panelPageClientesListadoDetalleAcciones.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TableLayoutPanel panelPageClientesListadoDetalle;
        private TableLayoutPanel panelPageClientesListadoDetalleAcciones;
        private Button btnPageClientesListadoDetalleEliminar;
        private ControlClienteDetalleLabel ControlClienteDetalleLabel1;
    }
}
