using System.Globalization;
using MySql.Data.MySqlClient;

namespace Club1
{
    public partial class ControlVencimientoCliente : UserControl
    {
        private readonly VencimientoRepo vencimientoRepo = new();

        public ControlVencimientoCliente()
        {
            InitializeComponent();
            btnBuscarCliente.Click += btnBuscarCliente_Click;
        }

        public void ConsultarPorDni(string dni)
        {
            cmbCriterioBusqueda.SelectedIndex = 1;
            txtValorBusqueda.Text = dni;
            btnBuscarCliente_Click(btnBuscarCliente, EventArgs.Empty);
        }

        private void btnBuscarCliente_Click(object? sender, EventArgs e)
        {
            LimpiarVencimiento();

            string valor = txtValorBusqueda.Text.Trim();
            if (string.IsNullOrWhiteSpace(valor))
            {
                MostrarMensaje("Ingrese un número de carnet o un DNI.", MessageBoxIcon.Warning);
                txtValorBusqueda.Focus();
                return;
            }

            Vencimiento? vencimiento;
            try
            {
                if (cmbCriterioBusqueda.SelectedIndex == 0)
                {
                    if (!int.TryParse(valor, NumberStyles.None, CultureInfo.InvariantCulture, out int nroCarnet)
                        || nroCarnet <= 0)
                    {
                        MostrarMensaje("Ingrese un número de carnet válido.", MessageBoxIcon.Warning);
                        txtValorBusqueda.Focus();
                        return;
                    }

                    vencimiento = vencimientoRepo.obtenerProximoVencimientoPorCarnet(nroCarnet);
                }
                else if (cmbCriterioBusqueda.SelectedIndex == 1)
                {
                    if (valor.Length > 10)
                    {
                        MostrarMensaje("El DNI no puede superar los 10 caracteres.", MessageBoxIcon.Warning);
                        txtValorBusqueda.Focus();
                        return;
                    }

                    vencimiento = vencimientoRepo.obtenerProximoVencimientoPorDni(valor);
                }
                else
                {
                    MostrarMensaje("Seleccione un criterio de búsqueda válido.", MessageBoxIcon.Warning);
                    return;
                }
            }
            catch (MySqlException ex)
            {
                MostrarMensaje($"No se pudo consultar el vencimiento.\n{ex.Message}", MessageBoxIcon.Error);
                return;
            }

            if (vencimiento == null)
            {
                MostrarMensaje(
                    "No se encontró un vencimiento pendiente para ese cliente.",
                    MessageBoxIcon.Information);
                return;
            }

            MostrarVencimiento(vencimiento);
        }

        private void MostrarVencimiento(Vencimiento vencimiento)
        {
            txtNombreCompleto.Text = vencimiento.ClienteNombreCompleto;
            txtDni.Text = vencimiento.ClienteDni;
            txtNroCarnet.Text = vencimiento.ClienteNroCarnet;
            txtTelefono.Text = vencimiento.ClienteTelefono;
            txtPlan.Text = vencimiento.PlanNombre;
            txtNroCuota.Text = vencimiento.CuotaNroCuota.ToString(CultureInfo.CurrentCulture);
            txtTotalCuotas.Text = vencimiento.CuotaTotalCuotas.ToString(CultureInfo.CurrentCulture);
            txtFechaVencimiento.Text =
                vencimiento.CuotaFechaVencimiento.ToString("dd/MM/yyyy", CultureInfo.CurrentCulture);
            txtTieneCuotaSiguiente.Text = vencimiento.TieneCuotaSiguiente ? "Sí" : "No";
            txtImporteCuotaSiguiente.Text = vencimiento.CuotaImporteSiguiente.HasValue
                ? vencimiento.CuotaImporteSiguiente.Value.ToString("C2", CultureInfo.CurrentCulture)
                : "No disponible";
        }

        private void LimpiarVencimiento()
        {
            txtNombreCompleto.Clear();
            txtDni.Clear();
            txtNroCarnet.Clear();
            txtTelefono.Clear();
            txtPlan.Clear();
            txtNroCuota.Clear();
            txtTotalCuotas.Clear();
            txtFechaVencimiento.Clear();
            txtTieneCuotaSiguiente.Clear();
            txtImporteCuotaSiguiente.Clear();
        }

        private void MostrarMensaje(string mensaje, MessageBoxIcon icono)
        {
            MessageBox.Show(
                this,
                mensaje,
                "Consulta de vencimiento",
                MessageBoxButtons.OK,
                icono);
        }
    }
}
