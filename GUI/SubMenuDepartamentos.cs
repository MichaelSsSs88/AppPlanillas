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
    public partial class SubMenuDepartamentos : Form
    {
        public SubMenuDepartamentos()
        {
            InitializeComponent();
        }

        private void btnInsertar_MouseHover(object sender, EventArgs e)
        {
            this.btnInsertarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentBig.png");
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            this.btnInsertarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentSmall.png");
        }

        private void btnInsertar_MouseLeave(object sender, EventArgs e)
        {
            this.btnInsertarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentMedium.png");
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            this.btnEditarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentSmall.png");
        }

        private void btnEditarEmpleado_MouseHover(object sender, EventArgs e)
        {
            this.btnEditarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentBig.png");
        }

        private void btnEditarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            this.btnEditarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentMedium.png");
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            this.btnEliminarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentSmall.png");
        }

        private void btnEliminarEmpleado_MouseHover(object sender, EventArgs e)
        {
            this.btnEliminarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentBig.png");
        }

        private void btnEliminarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            this.btnEliminarDepartamento.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentMedium.png");
        }
    }
}
