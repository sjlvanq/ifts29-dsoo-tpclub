using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Security;
using System.Text;
using System.Windows.Forms;
using Svg;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Forms
{
    public partial class FormCarnet : Form
    {
        private readonly Socio socioActual;

        public FormCarnet(Socio socio)
        {
            InitializeComponent();

            socioActual = socio;
            this.Icon = (Icon)Properties.Resources.club_icon;

            var carnetTemplate = Properties.Resources.carnet_svg.ToString();
            var carnet = carnetTemplate.Replace(
                "{{nombre_completo}}",
                SecurityElement.Escape(socio?.ClienteNombreCompleto ?? "") ?? "");
            carnet = carnet.Replace("{{dni}}", SecurityElement.Escape(socio?.Dni ?? "") ?? "");
            carnet = carnet.Replace(
                "{{numero_carnet}}",
                SecurityElement.Escape(socio?.ClienteNroCarnet ?? "") ?? "");

            Svg.SvgDocument svgDocument = Svg.SvgDocument.FromSvg<Svg.SvgDocument>(carnet);
            picCarnet.SizeMode = PictureBoxSizeMode.Zoom;
            picCarnet.Image = svgDocument.Draw(picCarnet.Width, picCarnet.Height);

        }

        private string ObtenerNombreArchivoPorDefecto()
        {
            var nombreCompleto = (socioActual?.ClienteNombreCompleto ?? string.Empty).Trim();
            if (string.IsNullOrWhiteSpace(nombreCompleto))
            {
                return "carnet_socio";
            }

            var sb = new StringBuilder();
            foreach (var ch in nombreCompleto.Normalize(NormalizationForm.FormD))
            {
                var category = CharUnicodeInfo.GetUnicodeCategory(ch);
                if (category == UnicodeCategory.NonSpacingMark)
                {
                    continue;
                }

                if (char.IsLetterOrDigit(ch))
                {
                    sb.Append(char.ToLowerInvariant(ch));
                }
                else if (sb.Length > 0 && sb[sb.Length - 1] != '_')
                {
                    sb.Append('_');
                }
            }

            var nombreNormalizado = sb.ToString().Trim('_');
            if (string.IsNullOrWhiteSpace(nombreNormalizado))
            {
                return "carnet_socio";
            }

            return $"carnet_{nombreNormalizado}";
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDescargar_Click(object sender, EventArgs e)
        {
            if (picCarnet.Image == null)
            {
                return;
            }

            using (var saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|BMP Image|*.bmp";
                saveFileDialog.DefaultExt = "png";
                saveFileDialog.AddExtension = true;
                saveFileDialog.Title = "Guardar Carnet";
                saveFileDialog.FileName = ObtenerNombreArchivoPorDefecto();

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    var rutaArchivo = saveFileDialog.FileName;
                    var extension = Path.GetExtension(rutaArchivo);
                    ImageFormat formato;

                    switch (extension.ToLowerInvariant())
                    {
                        case ".jpg":
                        case ".jpeg":
                            formato = ImageFormat.Jpeg;
                            break;
                        case ".bmp":
                            formato = ImageFormat.Bmp;
                            break;
                        case ".png":
                        default:
                            formato = ImageFormat.Png;
                            break;
                    }

                    if (string.IsNullOrEmpty(extension))
                    {
                        rutaArchivo = Path.ChangeExtension(rutaArchivo, saveFileDialog.DefaultExt);
                    }

                    picCarnet.Image.Save(rutaArchivo, formato);
                }
            }
        }
    }
}
