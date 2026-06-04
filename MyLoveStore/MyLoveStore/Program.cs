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

<<<<<<< HEAD
            Application.Run(new MyLoveStore.Formularios.frmLogin());
=======
            Gerente admin = new Gerente("user-admin", "0000");

            Application.Run(new InterfazPrincipal(admin));
>>>>>>> 454b7b4bb225762e66cb6ccdfd69051eec75f6c1
        }
    }
}