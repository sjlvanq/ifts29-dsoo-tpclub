using MySql.Data.MySqlClient;
using Org.BouncyCastle.Tls;
using Club1.Data.Repositories;
using Club1.Common;
using Club1.Data;

namespace Club1.UI.Forms
{
    public partial class FormLoginAndDbConnection : Form
    {
        private UsuarioRepo usuarioRepo = new UsuarioRepo();
        private int originalClientHeight;
        private bool isInitialized;
        private bool isUpdatingErrorMessageLayout;
        public int UsuarioAutenticadoId { get; private set; }
        public string CadenaConexion =>
            $"Server={txtDbServer.Text};Port={txtDbPort.Text};Database={txtDbDb.Text};Uid={txtDbUser.Text};Password={txtDbPass.Text};";

        public FormLoginAndDbConnection()
        {
            InitializeComponent();

            if (extenderTextBoxesForValidation1 is null)
            {
                extenderTextBoxesForValidation1 = new ExtenderTextBoxesForValidation();
            }

            RegistrarCamposRequeridos();
            Icon = (Icon)Properties.Resources.club_icon;
            btnConectar.DialogResult = DialogResult.None;
            AutoSize = false;
            originalClientHeight = ClientSize.Height;
            isInitialized = true;
        }

        private void RegistrarCamposRequeridos()
        {
            RegistrarCampoRequerido(txtLoginUser, lblLoginUser, tabPageLogin);
            RegistrarCampoRequerido(txtLoginPass, lblLoginPass, tabPageLogin);
            RegistrarCampoRequerido(txtDbServer, lblDbServer, tabPageDB);
            RegistrarCampoRequerido(txtDbPort, lblDbPort, tabPageDB);
            RegistrarCampoRequerido(txtDbDb, lblDbDb, tabPageDB);
            RegistrarCampoRequerido(txtDbUser, lblDbUser, tabPageDB);
            RegistrarCampoRequerido(txtDbPass, lblDbPass, tabPageDB);
        }

        private void RegistrarCampoRequerido(TextBox textBox, Label label, TabPage tabPage)
        {
            if (textBox is null || label is null || tabPage is null)
            {
                return;
            }

            extenderTextBoxesForValidation1.SetAssociatedLabel(textBox, label);
            extenderTextBoxesForValidation1.SetContainerTab(textBox, tabPage);
            extenderTextBoxesForValidation1.SetIsRequired(textBox, true);
        }

        private void btnConectar_Click(object sender, EventArgs e)
        {
            // Validación: Sin campos vacíos
            if (extenderTextBoxesForValidation1 is null)
            {
                lblErrorMessage.Text = "No se pudo inicializar la validación del formulario.";
                return;
            }

            if (!extenderTextBoxesForValidation1.ValidateAll(out Control? invalidControl))
            {
                Label? label = invalidControl is null
                    ? null
                    : extenderTextBoxesForValidation1.GetAssociatedLabel(invalidControl);

                lblErrorMessage.Text =
                    $"Por favor, complete todos los campos. El campo '{label?.Text ?? "campo no identificado"}' está vacío.";
                return;
            }

            // Validación: Información de conexión BD válida
            string cadena = CadenaConexion;
            try
            {
                using MySqlConnection test = new MySqlConnection(cadena);
                test.Open();
                test.Close();
            }
            catch (MySqlException ex)
            {
                lblErrorMessage.Text = $"No se pudo conectar a la base de datos: {ex.Message}";
                return;
            }
            catch (ArgumentException ex)
            {
                lblErrorMessage.Text = $"No se pudo conectar a la base de datos: {ex.Message}";
                return;
            }

            Conexion.CadenaConexion = cadena;

            // Validación: Información de autenticación válida
            try
            {
                if (usuarioRepo.accesoPermitido(txtLoginUser.Text, txtLoginPass.Text))
                {
                    UsuarioAutenticadoId = usuarioRepo.obtenerId(txtLoginUser.Text);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    //MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    lblErrorMessage.Text = "Usuario o Contraseña incorrectos";
                }
            }
            catch (MySqlException ex)
            {
                lblErrorMessage.Text = $"No se pudo validar al usuario: {ex.Message}";
            }
        }

        private void lblErrorMessage_TextChanged(object sender, EventArgs e)
        {
            UpdateErrorMessageLayout();
        }

        private void lblErrorMessage_Resize(object sender, EventArgs e)
        {
            UpdateErrorMessageLayout();
        }

        private void UpdateErrorMessageLayout()
        {
            if (!isInitialized || isUpdatingErrorMessageLayout)
            {
                return;
            }

            isUpdatingErrorMessageLayout = true;
            try
            {
                bool hasErrorMessage = !string.IsNullOrWhiteSpace(lblErrorMessage.Text);
                lblErrorMessage.Visible = hasErrorMessage;
                tableLayoutPanel1.PerformLayout();

                int errorMessageHeight = hasErrorMessage
                    ? lblErrorMessage.GetPreferredSize(new Size(lblErrorMessage.Width, 0)).Height
                    : 0;
                ClientSize = new Size(
                    ClientSize.Width,
                    originalClientHeight + errorMessageHeight);
            }
            finally
            {
                isUpdatingErrorMessageLayout = false;
            }
        }

        private void FormLoginAndDbConection_Load(object sender, EventArgs e)
        {

        }
    }
}
