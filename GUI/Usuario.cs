using AppPlanillas.DAL;
using AppPlanillas.ENT;
using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Usuario : Form
    {
        private UnificacionENT unificacionEnt;
        private bool Tramite;
        public bool Update= false;
        public Usuario(UnificacionENT unificacionEnt, bool Tramite)
        {
            this.Tramite = Tramite;
            this.unificacionEnt = unificacionEnt;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtUsuario.Text.Trim() != "" && this.txtContraseña.Text.Trim() != "")
            {
                if (new LoginDAL().IniciarSesion(this.txtUsuario.Text, this.txtContraseña.Text).Correo != "")
                {

                    UsuarioENT usuario = new LoginDAL().IniciarSesion(this.txtUsuario.Text, this.txtContraseña.Text);
                    if (usuario.Tipo == "Administrador")
                    {
                        if (Tramite)
                        {
                            this.unificacionEnt.estado = "aprobado";
                            new UnificacionDAL().EditarUnificacionQuitarMarca(this.unificacionEnt);
                            MessageBox.Show("Unificacion aprobada, ya se encuentra lista para proceder con el pago", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Update = true;
                        }
                        else
                        {
                            this.unificacionEnt.estado = "generado";
                            new UnificacionDAL().EditarUnificacionQuitarMarca(this.unificacionEnt);
                            MessageBox.Show("Unificacion se encuentra en estado generado, ahora puede realizar modificaciones", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Update = true;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario debe de tener permisos de administrador", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    this.Dispose();
                    //this.FrmClock.Close();
                    //

                }

                else
                    MessageBox.Show("Usuario invalido", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {

                MessageBox.Show("Para ingresar es necesario insertar usuario y contraseña", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
