using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Controls
{
    public partial class CustomTabControl : TabControl
    {
        private bool _isUpdatingItemSize;

        public CustomTabControl()
        {
            // Necesario para el ajuste automático del tamaño de las pestañas al cambiar el tamaño del control
            this.Dock = DockStyle.Fill;
            this.SizeMode = TabSizeMode.Fixed;

            InitializeComponent();
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            if (_isUpdatingItemSize) { return; }

            if (this.DesignMode || this.TabCount <= 0 || this.ClientSize.Width <= 0)
            {
                return;
            }

            int horizontalPadding = this.Padding.X * 2;
            int availableWidth = this.ClientSize.Width - horizontalPadding;
            int desiredWidth = availableWidth / this.TabCount;

            Size itemSize = this.ItemSize;
            if (itemSize.Width != desiredWidth)
            {
                itemSize.Width = desiredWidth;
                _isUpdatingItemSize = true;
                try
                {
                    this.ItemSize = itemSize;
                }
                finally
                {
                    _isUpdatingItemSize = false;
                }
            }

            /*
            protected override void OnControlAdded(ControlEventArgs e)
            {
                base.OnControlAdded(e);
                //this.TabPages[this.TabCount - 1].Controls.Add(new TableLayoutPanel());
            }
            */
        }
    }
}
