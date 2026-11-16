using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Club1.Models;
using Club1.Data.Repositories;
using Club1.Data;
using Club1.Common;

namespace Club1.UI.Controls
{
    public partial class ControlPagosRegistro : UserControl
    {
        public event EventHandler? PagoRegistrado;

        private readonly Club club;
        private readonly int usuarioId;
        private readonly SocioRepo socioRepo = new();
        private readonly CuotaRepo cuotaRepo = new();
        private readonly ActividadRepo actividadRepo = new();

        private Socio? clienteActual;
        private List<CuotaInfo> cuotasPendientes = new();
        private List<Actividad> actividadesDisponibles = new();
        private Dictionary<int, Actividad> actividadesPorIndice = new();

        public ControlPagosRegistro(Club club, int usuarioId)
        {
            this.club = club ?? throw new ArgumentNullException(nameof(club));
            this.usuarioId = usuarioId;
            InitializeComponent();
            btnPagePagosRegistroBuscar.Click += BtnBuscar_Click;
            btnPagePagosRegistroRegistrar.Click += BtnRegistrar_Click;
            btnPagePagosRegistroLimpiar.Click += (_, _) => Limpiar();
            rbPagePagosRegistroTipoCuota.CheckedChanged += RbTipo_CheckedChanged;
            rbPagePagosRegistroTipoActividad.CheckedChanged += RbTipo_CheckedChanged;

            actividadesDisponibles = actividadRepo.obtenerTodas();
            CargarActividades();
        }

        private void CargarActividades()
        {
            cmbPagePagosRegistroActividad.Items.Clear();
            actividadesPorIndice.Clear();
            int indice = 0;

            foreach (var actividad in actividadesDisponibles)
            {
                if (actividad.FechaBaja == DateTime.MinValue)
                {
                    cmbPagePagosRegistroActividad.Items.Add(
                        $"{actividad.Nombre} - ${actividad.PrecioDiario:F2}");
                    actividadesPorIndice[indice] = actividad;
                    indice++;
                }
            }
        }

        private void BtnBuscar_Click(object? sender, EventArgs e)
        {
            string dni = txtPagePagosRegistroDni.Text.Trim();
            if (string.IsNullOrWhiteSpace(dni))
            {
                MessageBox.Show("Ingrese un DNI para buscar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            clienteActual = socioRepo.obtenerPorDni(dni);
            if (clienteActual == null)
            {
                MessageBox.Show("Cliente no encontrado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MostrarCliente(clienteActual);
        }

        private void MostrarCliente(Socio cliente)
        {
            lblPagePagosRegistroClienteNombre.Text = $"{cliente.Nombre} {cliente.Apellido}";
            lblPagePagosRegistroClienteTelefono.Text = cliente.Telefono;
            lblPagePagosRegistroClienteCarnet.Text = cliente.ClienteEsSocio ? cliente.NroCarnet.ToString() : "No es socio";
            lblPagePagosRegistroClienteAptoFisico.Text = cliente.TieneAptoFisico ? "Sí" : "No";

            if (cliente.ClienteEsSocio)
            {
                rbPagePagosRegistroTipoCuota.Enabled = true;
                rbPagePagosRegistroTipoActividad.Enabled = false;
                rbPagePagosRegistroTipoCuota.Checked = true;
                CargarCuotasPendientes(cliente.IdCliente);
            }
            else
            {
                rbPagePagosRegistroTipoCuota.Enabled = false;
                rbPagePagosRegistroTipoActividad.Enabled = true;
                rbPagePagosRegistroTipoActividad.Checked = true;
            }

            grpPagePagosRegistroCliente.Visible = true;
            grpPagePagosRegistroPago.Visible = true;
        }

        private void CargarCuotasPendientes(int idCliente)
        {
            cuotasPendientes = cuotaRepo.obtenerCuotasPorCliente(idCliente);
            cmbPagePagosRegistroCuota.Items.Clear();

            foreach (var cuota in cuotasPendientes)
            {
                if (!cuota.Pagada)
                {
                    cmbPagePagosRegistroCuota.Items.Add(
                        $"Cuota {cuota.NroCuota}/{cuota.TotalCuotas} - Vence: {cuota.FechaVencimiento:dd/MM/yyyy} - ${cuota.Importe:F2}");
                }
            }

            if (cmbPagePagosRegistroCuota.Items.Count == 0)
            {
                MessageBox.Show("El cliente no tiene cuotas pendientes.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void RbTipo_CheckedChanged(object? sender, EventArgs e)
        {
            if (rbPagePagosRegistroTipoCuota.Checked)
            {
                grpPagePagosRegistroCuota.Visible = true;
                grpPagePagosRegistroActividad.Visible = false;
            }
            else if (rbPagePagosRegistroTipoActividad.Checked)
            {
                grpPagePagosRegistroCuota.Visible = false;
                grpPagePagosRegistroActividad.Visible = true;
            }
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            if (clienteActual == null)
            {
                MessageBox.Show("Debe buscar un cliente primero.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                Pago pago;

                if (rbPagePagosRegistroTipoCuota.Checked)
                {
                    if (cmbPagePagosRegistroCuota.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione una cuota.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var cuotaSeleccionada = cuotasPendientes[cmbPagePagosRegistroCuota.SelectedIndex];
                    pago = new Pago(
                        clienteActual.IdCliente,
                        usuarioId,
                        cuotaSeleccionada.Importe,
                        cmbPagePagosRegistroMedioPago.SelectedItem?.ToString() ?? "EFECTIVO",
                        DateTime.Now,
                        cuotaSeleccionada.IdCuota,
                        null);
                }
                else
                {
                    if (cmbPagePagosRegistroActividad.SelectedIndex == -1)
                    {
                        MessageBox.Show("Seleccione una actividad.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var actividadSeleccionada = actividadesPorIndice[cmbPagePagosRegistroActividad.SelectedIndex];
                    pago = new Pago(
                        clienteActual.IdCliente,
                        usuarioId,
                        actividadSeleccionada.PrecioDiario,
                        cmbPagePagosRegistroMedioPago.SelectedItem?.ToString() ?? "EFECTIVO",
                        DateTime.Now,
                        null,
                        actividadSeleccionada.IdActividad);
                }

                club.registrarPago(pago);
                MessageBox.Show("Pago registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                PagoRegistrado?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtPagePagosRegistroDni.Clear();
            lblPagePagosRegistroClienteNombre.Text = string.Empty;
            lblPagePagosRegistroClienteTelefono.Text = string.Empty;
            lblPagePagosRegistroClienteCarnet.Text = string.Empty;
            lblPagePagosRegistroClienteAptoFisico.Text = string.Empty;
            grpPagePagosRegistroCliente.Visible = false;
            grpPagePagosRegistroPago.Visible = false;
            cmbPagePagosRegistroCuota.Items.Clear();
            cmbPagePagosRegistroMedioPago.SelectedIndex = -1;
            clienteActual = null;
            cuotasPendientes.Clear();
        }
    }
}
