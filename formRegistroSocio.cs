namespace Club1
{
    public partial class formRegistroSocio : Form
    {
        Club club;
        private List<String> tipoDocumento = new List<String> { "DNI", "Pasaporte", "Cédula" };
        private List<String> tipoSocio = new List<String> { "Tipo 1", "Tipo 2" };
        public formRegistroSocio(Club club)
        {
            this.club = club;
            InitializeComponent();
        }

        private void formRegistroSocio_Load(object sender, EventArgs e)
        {
            this.cmbTipoDocumento.DataSource = tipoDocumento;
            this.cmbTipoSocio.DataSource = tipoSocio;
        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                this.club.registrarSocio(new Socio(
                    txtNumeroDocumento.Text.Trim(),
                    txtNombre.Text.Trim(),
                    txtApellido.Text.Trim(),
                    txtTelefono.Text.Trim()
                ));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
