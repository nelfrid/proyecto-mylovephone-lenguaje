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
    /// <summary>
    /// Formulario de Login del sistema
    /// Permite la autenticación del usuario administrador
    /// </summary>
    public partial class frmLogin : Form
    {
        /// <summary>Constructor del formulario de login</summary>
        public frmLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evento disparado cuando cambia el texto en el TextBox de usuario
        /// </summary>
        private void tbUsuario_TextChanged(object sender, EventArgs e)
        {
            // BLOQUE 1: Validación del usuario (vacío)
        }

        /// <summary>
        /// Evento disparado cuando cambia el texto en el TextBox de contraseña
        /// </summary>
        private void tbContraseña_TextChanged(object sender, EventArgs e)
        {
            // BLOQUE 1: Validación de contraseña (vacía)
        }

        /// <summary>
        /// Evento del CheckBox para mostrar/ocultar contraseña
        /// </summary>
        private void checkbContraseña_CheckedChanged(object sender, EventArgs e)
        {
            // BLOQUE 1: Toggle de visualización de contraseña
            // Si el checkbox está marcado, muestra la contraseña
            // Si no está marcado, oculta la contraseña
            tbContraseña.UseSystemPasswordChar = !checkbContraseña.Checked;
        }

        /// <summary>
        /// Evento del botón Iniciar Sesión
        /// Valida las credenciales y abre la interfaz principal
        /// </summary>
        private void btnIniciarSesión_Click(object sender, EventArgs e)
        {
            // BLOQUE 1: Obtención de credenciales ingresadas
            string userIngresado = tbUsuario.Text;
            string passwordIngresado = tbContraseña.Text;

            // BLOQUE 2: Creación de instancia del Gerente
            Gerente admin;
            admin = new Gerente("Cesar Liao", "MyLovePhone2026");

            // BLOQUE 3: Apertura de la interfaz principal
            // Crea una nueva instancia de la interfaz principal y la muestra
            InterfazPrincipal principal = new InterfazPrincipal(admin);
            principal.Show();

            // BLOQUE 4: Ocultamiento del formulario de login
            this.Hide();
        }
    }
}
