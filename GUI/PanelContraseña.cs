using AppPlanillas.DAL;
using AppPlanillas.ENT;
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
    public partial class PanelContraseña : Form
    {
        private UsuarioENT UsuarioEnt;
        public PanelContraseña(UsuarioENT UsuarioEnt)
        {
            this.UsuarioEnt = UsuarioEnt;
            
            InitializeComponent();
            this.txtUsuario.Text = this.UsuarioEnt.Correo;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtContraseña.Text.Trim() != "")
            {
                if (this.txtContraseña.Text.CompareTo(this.txtConfirmar.Text) == 0)
                {
                    new UsuarioDAL().ActualizarUsuario(new UsuarioENT(this.UsuarioEnt.Id, this.UsuarioEnt.Nombre, this.UsuarioEnt.Correo, this.UsuarioEnt.Tipo, this.txtContraseña.Text, DateTime.Now, "", DateTime.Now, this.UsuarioEnt.Nombre, this.UsuarioEnt.getActivo));
                    MessageBox.Show("Su contraseña a sido actualizada", "Contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Las contraseñas no coinciden", "Contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe digitar las contraseñas", "Contraseñas", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
