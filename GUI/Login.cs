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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnIngresar_MouseHover(object sender, EventArgs e)
        {
            this.btnIngresar.Image = new Bitmap(Application.StartupPath + @"\IMG\startBig.png");
        }

        private void btnIngresar_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnIngresar.Image = new Bitmap(Application.StartupPath + @"\IMG\startSmall.png");
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

     
        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            this.btnIngresar.Image = new Bitmap(Application.StartupPath + @"\IMG\startMedium.png");
        }
    }
}
