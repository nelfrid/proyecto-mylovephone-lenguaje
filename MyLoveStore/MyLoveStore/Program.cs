using System;
using System.Windows.Forms;
using MyLoveStore.Clases;

namespace MyLoveStore
{
    /// <summary>
    /// Clase Principal del programa
    /// Punto de entrada de la aplicación Windows Forms
    /// </summary>
    internal static class Program
    {
        /// <summary>
        /// Método Main - Punto de entrada de la aplicación
        /// STAThread es requerido para aplicaciones Windows Forms
        /// </summary>
        [STAThread]
        static void Main()
        {
            // BLOQUE 1: Habilitación de estilos visuales
            // Activa los estilos visuales modernos para los controles
            Application.EnableVisualStyles();

            // BLOQUE 2: Configuración de renderizado de texto
            // Establece la compatibilidad de renderizado de texto
            Application.SetCompatibleTextRenderingDefault(false);

            // BLOQUE 3: Inicio de la aplicación
            // Inicia la aplicación directamente con el formulario de Inventario
            // Se crea una instancia de Gerente para pasar al formulario
            Gerente adminPrueba = new Gerente("user-admin", "0000");
            Application.Run(new MyLoveStore.Formularios.frmLogin());
        }
    }
}
