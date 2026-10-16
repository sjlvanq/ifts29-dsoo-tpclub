using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Club1
{
    public partial class formLogin : Form
    {
        private Club club;
        private UsuarioRepo usuarioRepo = new UsuarioRepo();
        public formLogin(Club club)
        {
            this.club = club;

            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if(usuarioRepo.accesoPermitido(txtUsuario.Text, txtContrasena.Text))
            {
                new formRegistroSocio(club).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
