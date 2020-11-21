using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPlanillas.GUI
{
    public partial class PanelSubMenuMarcas : Form
    {
        Form1 oyente;
        public int submenu = 0;
        public PanelSubMenuMarcas(Form1 Form1)
        {
            this.oyente = Form1;
            InitializeComponent();
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

        }
        protected virtual void BotonPulsado()
        {
            if (oyente != null)
                oyente.Clic_2(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.submenu = 1;
            this.BotonPulsado();
        }
    }
}
