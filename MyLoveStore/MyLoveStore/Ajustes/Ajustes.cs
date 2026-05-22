using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoveStore.Ajustes
{
    public static class Ajustes
    {

        public static  byte sizeTitulo;
        public static string fontTitulo;
        public static string colorTitulo;

        public static byte SizeTitulo { get; private set; }
        public static string FontTitulo { get; private set; }
        public static string ColorTitulo { get; private set; }

        private static void InitialSettings(Form form)
        {
            
            form.BackColor = Color.FromRgb(255, 255, 255);

        }

        public static void FormTheme()
        {
            if (this.BackColor == Color.White || this.BackColor == Color.Control)
            {
                this.BackColor = Color.FromArgb(145, 139, 139);
            }
            else
            {
                this.BackColor = Color.White;
            }
        }

    }
}
