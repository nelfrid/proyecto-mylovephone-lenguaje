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

            Gerente admin = new Gerente("user-admin", "0000");

            Application.Run(new InterfazPrincipal(admin));
        }
    }
}