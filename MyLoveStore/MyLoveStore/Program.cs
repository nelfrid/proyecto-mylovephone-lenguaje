using System;
using System.Windows.Forms;
using MyLoveStore.Clases;

namespace MyLoveStore
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Start the application with the login form by default. If you want to launch the main interface directly,
            // create a Gerente instance and pass it to InterfazPrincipal instead.
            Application.Run(new MyLoveStore.Formularios.frmLogin());
        }
    }
}