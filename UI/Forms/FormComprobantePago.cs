using System;
using System.Windows.Forms;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Forms
{
    public class FormComprobantePago : Form
    {
        public FormComprobantePago(PagoListDTO pago)
        {
            Text = "Comprobante de pago";
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;

            TextBox txt = new TextBox
            {
                Multiline = true,
                WordWrap = true,
                ReadOnly = true,
                ScrollBars = ScrollBars.Vertical,
                Dock = DockStyle.Fill,
                Font = new System.Drawing.Font("Consolas", 10),
                Text = BuildTexto(pago)
            };

            Button btnCerrar = new Button { Text = "Cerrar", Dock = DockStyle.Bottom, Height = 35 };
            btnCerrar.Click += (_, _) => Close();

            Controls.Add(txt);
            Controls.Add(btnCerrar);
        }

        private static string BuildTexto(PagoListDTO pago)
        {
            string salto = Environment.NewLine;

            return $"COMPROBANTE DE PAGO{salto}" +
                   $"-------------------{salto}" +
                   $"Cliente: {pago.ClienteNombreCompleto} ({pago.ClienteDni}){salto}" +
                   ((!string.IsNullOrWhiteSpace(pago.ClienteNroCarnet)) ?
                       ($"Nro. Carnet: {pago.ClienteNroCarnet}{salto}") :
                       ($"Actividad: {(string.IsNullOrWhiteSpace(pago.ActividadNombre) ? "-" : pago.ActividadNombre)}{salto}")) +
                   $"Medio de pago: {pago.MedioPago}{salto}" +
                   $"Importe: ${pago.Importe}{salto}" +
                   $"Fecha de pago: {pago.FechaPago:dd/MM/yyyy HH:mm}{salto}" +
                   $"Fecha de emisión: {DateTime.Now:dd/MM/yyyy HH:mm}";
        }

    }
}
