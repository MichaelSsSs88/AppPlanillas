﻿using AppPlanillas.Properties;
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
using AppPlanillas.GUI;
using GUI;
using AppPlanillas.ENT;

namespace AppPlanillas
{
    public partial class Form1 : Form
    {
        private Form activeForm = null;
        private Form activeFormContenedor = null;
        private UsuarioENT UsuarioENT;
        public Form1(UsuarioENT usuarioEnt)
        {
            this.UsuarioENT = usuarioEnt;
            InitializeComponent();
            if (this.UsuarioENT.Tipo != "Administrador")
            {
                this.lblUsers.Visible = false;
                this.btnUsers.Visible = false;
            }
            this.EstadoMenu(1, false);
            this.EstadoMenu(2, false);
            this.EstadoMenu(3, false);
            this.Size= Screen.PrimaryScreen.WorkingArea.Size;
            
        }

        private void CLoseChildForm()
        {
            if (this.activeForm != null)
            {
                activeForm.Close();
            }
        }
            private void OpenChildForm(Form ChildForm)
        {
            if (this.activeForm != null)
            {
                activeForm.Close();
            }
            this.activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.panelMenuHorizontal.Controls.Add(ChildForm);
            this.panelMenuHorizontal.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }

        private void CLoseChildFormContenedor()
        {
            if (this.activeFormContenedor != null)
            {
                activeFormContenedor.Close();
            }
        }
        private void OpenChildFormContenedor(Form ChildForm)
        {
            if (this.activeFormContenedor != null)
            {
                activeFormContenedor.Close();
            }
            this.activeFormContenedor = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.PanelContenedor.Controls.Add(ChildForm);
            this.PanelContenedor.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
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

        private void EstadoMenu(int posicionMenu, bool visible)
        {
            if (posicionMenu == 1)
            {
                this.panelMantenimiento.Visible = visible;
                this.lblEspacionMantenimiento1.Visible = visible;
                this.lblEspacionMantenimiento2.Visible = visible;
                this.lblEspacionMantenimiento3.Visible = visible;
                this.lblEspacionMantenimiento4.Visible = visible;
                this.lblEspacionMantenimiento5.Visible = visible;
                this.lblEspacionMantenimiento6.Visible = visible;
            }
            if (posicionMenu == 2)
            {
                this.panelProcesos.Visible = visible;
                this.lblEspacionProceso1.Visible = visible;
                this.lblEspacionProceso2.Visible = visible;
                this.lblEspacioProceso3.Visible = visible;
            }
            if(posicionMenu == 3)
            {
                this.panelSeguridad.Visible = visible;
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

        private void label1_Click(object sender, EventArgs e)
        {
            this.CLoseChildForm();
            this.CLoseChildFormContenedor();
            if (this.panelMantenimiento.Visible)
            {
                this.EstadoMenu(1, false);
            }
            else
            {
                this.EstadoMenu(1, true);
            }
            
        }

        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            if (this.panelMantenimiento.Visible)
            {
                this.EstadoMenu(1, false);
            }
            else
            {
                this.EstadoMenu(1, true);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            if (this.panelProcesos.Visible)
            {
                this.EstadoMenu(2, false);
            }
            else
            {
                this.EstadoMenu(2, true);
            }

        }

        private void label14_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            if (this.panelProcesos.Visible)
            {
                this.EstadoMenu(2, false);
            }
            else
            {
                this.EstadoMenu(2, true);
            }
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            //this.OpenChildForm(new SubMenuEmpleados());
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(1, this));

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(2, this));
            //this.OpenChildForm(new SubMenuDepartamentos());
        }

        private void panelMenuHorizontal_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnTamañoPanel_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void panel5_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);

        }

        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            if (this.panelSeguridad.Visible)
            {
                this.EstadoMenu(3, false);
            }
            else
            {
                this.EstadoMenu(3, true);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(3,this));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(4,this));
        }

        private void btnHorario_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(5, this));
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.btnEmpleado_Click(sender, e);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.button2_Click(sender, e);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.button4_Click(sender, e);
        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.button5_Click(sender, e);
        }

        private void label13_Click(object sender, EventArgs e)
        {
            this.btnHorario_Click(sender, e);
        }
        public void Clic_2(object emisor)
        {
            PanelSubMenuMarcas entrada = (PanelSubMenuMarcas)emisor;
            //if (entrada.submenu == 1)
            //{
                this.OpenChildFormContenedor(new PanelMarcas(entrada.submenu-1, this.UsuarioENT));
           // }
        }
            public void Clic(object emisor)
        {
            SubMenuFeriados entrada = (SubMenuFeriados)emisor;
           
            if ((entrada.subMenu == 1))
            {
                this.OpenChildFormContenedor(new PanelEmpleados(entrada.boton - 1, this.UsuarioENT));
            }
            if ((entrada.subMenu==2))
            {
                this.OpenChildFormContenedor(new PanelDepartamento(entrada.boton-1, this.UsuarioENT));
            }

            if ((entrada.subMenu == 3))
            {
                this.OpenChildFormContenedor(new PanelFeriado(entrada.boton - 1, this.UsuarioENT));
            }
            if ((entrada.subMenu == 4))
            {
                this.OpenChildFormContenedor(new PanelDeduccion(entrada.boton - 1, this.UsuarioENT));
            }
            if ((entrada.subMenu == 5))
            {
               
                this.OpenChildFormContenedor(new PanelHorario(entrada.boton - 1, this.UsuarioENT));
            }
            if ((entrada.subMenu == 6))
            {

                this.OpenChildFormContenedor(new PanelPuestos(entrada.boton - 1, this.UsuarioENT));
            }
            if ((entrada.subMenu == 10))
            {

                this.OpenChildFormContenedor(new PanelUsuario(entrada.boton - 1, this.UsuarioENT));
            }
            if ((entrada.subMenu == 11))
            {

                this.OpenChildFormContenedor(new PanelUnificacion(entrada.boton - 1, this.UsuarioENT));
            }
        }

        private void label10_Click(object sender, EventArgs e)
        {
            //this.CLoseChildFormContenedor();
            this.btnSeguridad_Click(sender, e);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(10, this));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.OpenChildForm(new SubMenuFeriados(6, this));
        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.button1_Click(sender, e);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            PanelContraseña panelContraseña = new PanelContraseña(this.UsuarioENT);
            panelContraseña.ShowDialog();
            this.Close();
        }

        private void lblUsers_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            this.button3_Click(sender, e);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            this.OpenChildForm(new PanelSubMenuMarcas(this));

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            this.OpenChildForm(new SubMenuFeriados(11, this));

        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.CLoseChildFormContenedor();
            this.CLoseChildForm();
            this.OpenChildFormContenedor(new PanelPagos(this.UsuarioENT));
        }
    }

}
