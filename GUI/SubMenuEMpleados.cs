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
    public partial class SubMenuEmpleados : Form
    {
        public SubMenuEmpleados()
        {
            InitializeComponent();
        }

        private void btnInsertar_MouseHover(object sender, EventArgs e)
        {
            this.btnInsertarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\insertBig.png");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.btnInsertarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSmall.png");
        }

        private void btnInsertar_MouseLeave(object sender, EventArgs e)
        {
            this.btnInsertarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\insertMedium.png");
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            this.btnEditarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\editSmall.png");
        }

        private void btnEditarEmpleado_MouseHover(object sender, EventArgs e)
        {
            this.btnEditarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\editBig.png");
        }

        private void btnEditarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            this.btnEditarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\editMedium.png");
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            this.btnEliminarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSmall.png");
        }

        private void btnEliminarEmpleado_MouseHover(object sender, EventArgs e)
        {
            this.btnEliminarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteBig.png");
        }

        private void btnEliminarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            this.btnEliminarEmpleado.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteMedium.png");
        }
    }
}
