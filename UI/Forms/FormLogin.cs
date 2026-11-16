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

namespace Club1.UI.Forms
{
    public partial class FormLogin : Form
    {
        private Club club;
        private UsuarioRepo usuarioRepo = new UsuarioRepo();
        public FormLogin(Club club)
        {
            this.club = club;

            InitializeComponent();
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (usuarioRepo.accesoPermitido(txtUsuario.Text, txtContrasena.Text))
            {
                new FormRegistroSocio(club).Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
