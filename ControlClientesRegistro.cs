using System;
using System.Windows.Forms;

namespace Club1
{
    public partial class ControlClientesRegistro : UserControl
    {

        public event EventHandler? ClienteRegistrado;
        private readonly Club club;

        public ControlClientesRegistro(Club club)
        {
            this.club = club ?? throw new ArgumentNullException(nameof(club));
            InitializeComponent();
            btnPageClientesRegistroRegistrar.Click += BtnRegistrar_Click;
            btnPageClientesRegistroLimpiar.Click += (_, _) => Limpiar();
        }

        private void BtnRegistrar_Click(object? sender, EventArgs e)
        {
            try
            {
                Socio socio = new Socio(
                    txtPageClientesRegistroFieldsIDNumber.Text.Trim(),
                    txtPageClientesRegistroFieldsFirstName.Text.Trim(),
                    txtPageClientesRegistroFieldsLastName.Text.Trim(),
                    txtPageClientesRegistroFieldsPhone.Text.Trim()
                );
                socio.TieneAptoFisico = chkPageClientesRegistroFieldsHealthCert.Checked;

                club.registrarSocio(socio);

                MessageBox.Show("Cliente registrado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                ClienteRegistrado?.Invoke(this, EventArgs.Empty);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtPageClientesRegistroFieldsIDNumber.Clear();
            txtPageClientesRegistroFieldsFirstName.Clear();
            txtPageClientesRegistroFieldsLastName.Clear();
            txtPageClientesRegistroFieldsPhone.Clear();
            chkPageClientesRegistroFieldsHealthCert.Checked = false;
            dtpPageClientesRegistroFieldsCreatedDate.Value = DateTime.Now;
        }
    }
}
