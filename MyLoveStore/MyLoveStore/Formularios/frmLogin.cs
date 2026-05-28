using MyLoveStore.Clases;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoveStore.Formularios
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbContraseña_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkbContraseña_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesión_Click(object sender, EventArgs e)
        {
            string userIngresado = tbUsuario.Text;
            string passwordIngresado = tbContraseña.Text;

            Gerente admin;

            admin = new Gerente("user-admin", "0000");

            InterfazPrincipal principal = new InterfazPrincipal(admin);
            principal.Show();
            this.Hide();
        }
    }
}
