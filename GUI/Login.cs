using AppPlanillas.DAL;
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
            UsuarioENT usuario = new LoginDAL().IniciarSesion(this.textBox1.Text, this.textBox2.Text);
            if (usuario.Correo == "" && usuario.Contrasena == "")
            {
                MessageBox.Show("Correo o contraseña incorrectos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else {
                MessageBox.Show("Bienvenido(a).", "Ingreso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Form1 form1 = new Form1();
               form1.ShowDialog();
                this.textBox1.Text = "Usuario";
                this.textBox2.Text = "Contraseña";
            }
        }

     
        private void btnIngresar_MouseLeave(object sender, EventArgs e)
        {
            this.btnIngresar.Image = new Bitmap(Application.StartupPath + @"\IMG\startMedium.png");
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
           // UsuarioENT = new LoginDAL().IniciarSesion();
        }
    }
}
