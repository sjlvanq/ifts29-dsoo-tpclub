using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Club1.Common;
using Club1.Models;
using Club1.UI.Controls;

namespace Club1.UI.Forms
{
    public partial class FormMain : Form
    {
        private const string DefaultHomeTitleText = "Sistema de Gestión de Club Deportivo";
        private const string DefaultStatusText = "Sistema de Gestión de Club Deportivo";
        private readonly Common.Club club;
        private readonly int usuarioId;

        public FormMain(Common.Club club, int usuarioId)
        {
            this.club = club ?? throw new ArgumentNullException(nameof(club));
            this.usuarioId = usuarioId;
            this.Icon = (Icon)Properties.Resources.club_icon;
            InitializeComponent();

            if (viewSwitcherVencimientos == null)
            {
                viewSwitcherVencimientos = new ViewSwitcher(components!);
                panelPageVencimientos.Controls.Add(viewSwitcherVencimientos, 0, 0);
            }

            toolStripStatusLabelMain.Text = DefaultStatusText;
            statusStripMain.Visible = true;
            tabControlMain.MouseLeave += TabControlMain_MouseLeave;
            tabControlMain.SelectedTab = tabPageHome;
            panelPageHome.Visible = true;
            StartPosition = FormStartPosition.CenterParent;

            this.lblPanelPageHomeTitle.Text = DefaultHomeTitleText;
            this.lblMainNotes.Text = getVersionNotes();
            //Debug.Write(this.lblMainNotes.Text);

            this.viewSwitcherClientes.View2Button.Text = "Nuevo Cliente";
            var controlClientesListado = new ControlClientesListado() { Dock = DockStyle.Fill };
            this.viewSwitcherClientes.View1.Controls.Add(controlClientesListado);

            this.viewSwitcherClientes.Filtros.ConfigurarCampos(new[]
            {
                new FiltroField("", "Sin filtro"),
                new FiltroField(nameof(Socio.Dni), "DNI"),
                new FiltroField(nameof(Socio.Nombre), "Nombre"),
                new FiltroField(nameof(Socio.Apellido), "Apellido")
            });

            var controlClientesRegistro = new ControlClientesRegistro(club) { Dock = DockStyle.Fill };
            controlClientesRegistro.ClienteRegistrado += (_, _) => controlClientesListado.Recargar();
            this.viewSwitcherClientes.View2.Controls.Add(controlClientesRegistro);
            this.viewSwitcherClientes.FiltroChanged += controlClientesListado.AplicarFiltro;
            this.viewSwitcherClientes.PagosHistorialRequested += (sender, args) => {
                this.viewSwitcherPagos.Filtros.SetFiltro(nameof(PagoListDTO.ClienteDni), args.ClienteDni);
                this.tabControlMain.SelectedTab = this.tabPagePagos;
            };

            this.viewSwitcherVencimientos.View2Button.Text = "Próximo Vencimiento para Cliente";
            var controlVencimientosListado = new ControlVencimientosListado() { Dock = DockStyle.Fill };
            this.viewSwitcherVencimientos.View1.Controls.Add(controlVencimientosListado);
            var controlVencimientoCliente = new ControlVencimientoCliente() { Dock = DockStyle.Fill };
            this.viewSwitcherVencimientos.View2.Controls.Add(controlVencimientoCliente);

            this.viewSwitcherPagos.View2Button.Text = "Registrar Pago";
            this.viewSwitcherPagos.View2Button.Enabled = true;
            var controlPagosListado = new ControlPagosListado() { Dock = DockStyle.Fill };
            this.viewSwitcherPagos.View1.Controls.Add(controlPagosListado);
            var controlPagosRegistro = new ControlPagosRegistro(club, usuarioId) { Dock = DockStyle.Fill };
            controlPagosRegistro.PagoRegistrado += (_, _) => controlPagosListado.Recargar();
            this.viewSwitcherPagos.View2.Controls.Add(controlPagosRegistro);

            this.viewSwitcherVencimientos.Filtros.Visible = false;
            this.viewSwitcherVencimientos.ConfigureFiltersOnDefaultView(false);
            this.viewSwitcherVencimientos.View1Link.Text = "Todos los vencimientos de hoy";

            this.viewSwitcherActividades.View2Button.Text = "Nueva Actividad";
            var controlActividadesListado = new ControlActividadesListado() { Dock = DockStyle.Fill };
            this.viewSwitcherActividades.View1.Controls.Add(controlActividadesListado);

            this.viewSwitcherActividades.Filtros.ConfigurarCampos(new[]
            {
                new FiltroField("", "Sin filtro"),
                new FiltroField(nameof(Actividad.Nombre), "Nombre Act."),
                new FiltroField(nameof(Actividad.PrecioDiario), "Precio Diario"),
                new FiltroField(nameof(Actividad.FechaBaja), "Fecha de Baja")
            });

            this.viewSwitcherActividades.View2Button.Enabled = false;
            this.viewSwitcherActividades.FiltroChanged += controlActividadesListado.AplicarFiltro;

            //this.viewSwitcherActividades.View2.Controls.Add(new ControlActividadesRegistro() { Dock = DockStyle.Fill });

            this.viewSwitcherPagos.ProximoVencimientoRequested += (_, args) =>
            {
                this.tabControlMain.SelectedTab = this.tabPageVencimientos;
                this.viewSwitcherVencimientos.ShowView2();
                controlVencimientoCliente.ConsultarPorDni(args.ClienteDni);
            };

            this.viewSwitcherPagos.Filtros.ConfigurarCampos(new[]
            {
                new FiltroField("", "Sin filtro"),
                new FiltroField(nameof(PagoListDTO.ClienteDni), "DNI Cliente"),
                new FiltroField(nameof(PagoListDTO.ClienteNroCarnet), "Nro Carnet"),
                //new FiltroField(nameof(PagoListDTO.IdCuota), "ID Cuota")
            });

            this.viewSwitcherPagos.FiltroChanged += controlPagosListado.AplicarFiltro;


        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            lblModuleTitle.Text = "";
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro de que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void TabControlMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControlMain.SelectedTab != null)
            {
                if (tabControlMain.SelectedTab == tabControlMain.TabPages[0])
                {
                    lblModuleTitle.Text = "";
                    lblModuleTitle.Visible = false;
                }
                else
                {
                    lblModuleTitle.Text = tabControlMain.SelectedTab.ToolTipText;
                    lblModuleTitle.Visible = true;

                    // TODO: Refactorizar para desacoplar al nombre de pestañas
                    // y controles ViewSwitcher.
                    switch (tabControlMain.SelectedTab.Name)
                    {
                        case "tabPageClientes":
                            viewSwitcherClientes.ResetView();
                            break;
                        case "tabPagePagos":
                            viewSwitcherPagos.ResetView();
                            break;
                        case "tabPageVencimientos":
                            viewSwitcherVencimientos.ResetView();
                            break;
                    }
                }
            }
        }
        private void TabControlMain_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < tabControlMain.TabCount; i++)
            {
                Rectangle rect = tabControlMain.GetTabRect(i);
                if (rect.Contains(e.Location))
                {
                    toolStripStatusLabelMain.Text = string.IsNullOrWhiteSpace(tabControlMain.TabPages[i].ToolTipText)
                        ? DefaultStatusText
                        : tabControlMain.TabPages[i].ToolTipText;
                    return;
                }
            }

            toolStripStatusLabelMain.Text = DefaultStatusText;
        }

        private void TabControlMain_MouseLeave(object? sender, EventArgs e)
        {
            toolStripStatusLabelMain.Text = DefaultStatusText;
        }

        private String getVersionNotes(String fileName = "version_notes.txt")
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return "No se han podido recuperar las notas de versión.\nDetalle: nombre de archivo no válido.";
            }

            try
            {
                var resolvedPath = ResolveVersionNotesPath(fileName);
                if (string.IsNullOrEmpty(resolvedPath))
                {
                    return "No se han podido recuperar las notas de versión.\nDetalle: no se encontró el archivo '" + fileName + "' en el directorio de ejecución ni en los directorios padre.";
                }

                var versionNotes = new StringBuilder();
                using var sr = new StreamReader(resolvedPath);
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    versionNotes.AppendLine(line);
                }

                return versionNotes.ToString();
            }
            catch (Exception e)
            {
                return "No se han podido recuperar las notas de versión.\nDetalle:" + e.Message;
            }
        }

        private static string? ResolveVersionNotesPath(string fileName)
        {
            if (Path.IsPathRooted(fileName) && File.Exists(fileName))
            {
                return fileName;
            }

            var candidatePaths = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                Path.Combine(AppContext.BaseDirectory, fileName),
                Path.Combine(Directory.GetCurrentDirectory(), fileName),
                Path.Combine(Path.GetDirectoryName(Application.ExecutablePath) ?? AppContext.BaseDirectory, fileName)
            };

            foreach (var candidate in candidatePaths)
            {
                if (File.Exists(candidate))
                {
                    return candidate;
                }
            }

            var directory = new DirectoryInfo(AppContext.BaseDirectory);
            while (directory != null)
            {
                var candidate = Path.Combine(directory.FullName, fileName);
                if (File.Exists(candidate))
                {
                    return candidate;
                }

                directory = directory.Parent;
            }

            return null;
        }

    }
}