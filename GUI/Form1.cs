using AppPlanillas.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AppPlanillas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hand, int usng, int wparam, int lparam);

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnSlide_Click(object sender, EventArgs e)
        {
           
        }

       

      

        private void btnSalir_MouseHover(object sender, EventArgs e)
        {
            this.btnSalir.Image= new Bitmap(Application.StartupPath + @"\IMG\CloseOverOut.png");
        }

        private void btnSalir_MouseLeave(object sender, EventArgs e)
        {
            this.btnSalir.Image = new Bitmap(Application.StartupPath + @"\IMG\Close.png");

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.btnSalir.Image = new Bitmap(Application.StartupPath + @"\IMG\CloseClick.png");
            this.Close();
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.btnTamañoPanel.Image = new Bitmap(Application.StartupPath + @"\IMG\PanelBig.png");
        }

        private void btnTamañoPanel_MouseLeave(object sender, EventArgs e)
        {
           this.btnTamañoPanel.Image = new Bitmap(Application.StartupPath + @"\IMG\PanelMedium.png");
        }

        private void btnTamañoPanel_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnTamañoPanel.Image = new Bitmap(Application.StartupPath + @"\IMG\PanelSmall.png");
            if (this.MenuVertical.Width == 250)
            {
                this.MenuVertical.Width = 120;
            }
            else
            {
                this.MenuVertical.Width = 250;
            }

        }

        private void btnMinimize_MouseHover(object sender, EventArgs e)
        {
            this.btnMinimize.Image = new Bitmap(Application.StartupPath + @"\IMG\minimizeBig.png");
        }

        private void btnMinimize_MouseLeave(object sender, EventArgs e)
        {
            this.btnMinimize.Image = new Bitmap(Application.StartupPath + @"\IMG\minimizaMedium.png");
        }

        private void btnMinimize_MouseClick(object sender, MouseEventArgs e)
        {
            this.btnMinimize.Image = new Bitmap(Application.StartupPath + @"\IMG\minimizeSmall.png");
            // this.MinimumSize.
            this.WindowState = FormWindowState.Minimized;
        }

        private void SubMenu_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle,0x112,0xf012,0);
        }
    }
}
