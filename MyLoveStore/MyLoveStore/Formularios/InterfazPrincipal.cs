using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyLoveStore
{

    

    public partial class InterfazPrincipal : Form
    {

        private Ajustes pageSettings;

        public InterfazPrincipal(Ajustes pageSettings)
        {
            InitializeComponent();
            this.pageSettings = pageSettings;
        }

        private void InterFazPrincipal_FormLoad(object sender, EventArgs e)
        {
            Ajustes pageSettings = new Ajustes();
            pageSettings.FormTheme();
        }


        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // ActivateDarkModePage();
        }

        private void InterfazPrincipal_Load(object sender, EventArgs e)
        {

        }

        
    }
}
