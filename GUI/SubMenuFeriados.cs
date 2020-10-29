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
    public partial class SubMenuFeriados: Form
    {
        public int subMenu;
        public int boton;
        public Form1 oyente = null;
        public SubMenuFeriados(int numeroSubMenu, Form1 listen)
        {
            this.subMenu = numeroSubMenu;
            this.oyente = listen;
            InitializeComponent();
            this.ajustarBotones(this.subMenu);
        }

        public void ajustarBotones(int numeroSubMenu)
        {
            if (numeroSubMenu == 2)
            {
                this.btnInsertar.Text = "Insertar Departamento";
                this.btnEditar.Text = "Editar Departamento";
                this.btnEliminar.Text = "Eliminar Departamento";
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentMedium.png");
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentMedium.png");
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentMedium.png");
            }
            if (numeroSubMenu == 3)
            {
                this.btnInsertar.Text = "Insertar Feriado";
                this.btnEditar.Text = "Editar Feriado";
                this.btnEliminar.Text = "Eliminar Feriado";
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayMedium.png");
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayMedium.png");
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayMedium.png");

            }
            if (numeroSubMenu == 4)
            {
                this.btnInsertar.Text = "Insertar deducción";
                this.btnEditar.Text = "Editar deducción";
                this.btnEliminar.Text = "Eliminar deducción";
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendMedium.png");
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendMedium.png");
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendMedium.png");

            }
            if (numeroSubMenu == 5)
            {
                this.btnInsertar.Text = "Insertar Horario";
                this.btnEditar.Text = "Editar Horario";
                this.btnEliminar.Text = "Eliminar Horario";
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayMedium.png");
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayMedium.png");
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayMedium.png");

            }

        }

        private void btnInsertar_MouseHover(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentBig.png");
            }
            if (this.subMenu == 3)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayBig.png");
            }
            if (this.subMenu == 4)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendBig.png");
            }
            if (this.subMenu == 5)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayBig.png");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentSmall.png");
            }
            if (this.subMenu == 3)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidaySmall.png");
            }
            if (this.subMenu == 4)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendSmall.png");
            }
            if (this.subMenu == 5)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidaySmall.png");
            }
            this.boton = 1;

            this.BotonPulsado();
        }

        private void btnInsertar_MouseLeave(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertdepartamentMedium.png");
            }
            if (this.subMenu == 3)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayMedium.png");
            }
            if (this.subMenu == 4)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendMedium.png");
            }
            if (this.subMenu == 5)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayMedium.png");
            }


        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentSmall.png");
            }
            if (this.subMenu == 3)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidaySmall.png");
            }
            if (this.subMenu == 4)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendSmall.png");
            }
            if (this.subMenu == 5)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidaySmall.png");
            }
            this.boton = 2;

            this.BotonPulsado();
        }

        private void btnEditarEmpleado_MouseHover(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentBig.png");
            }
            if (this.subMenu == 3)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayBig.png");
            }
            if (this.subMenu == 4)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendBig.png");
            }
            if (this.subMenu == 5)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayBig.png");
            }
        }

        private void btnEditarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editdepartamentMedium.png");
            }
            if (this.subMenu == 3)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayMedium.png");
            }
            if (this.subMenu == 4)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendMedium.png");
            }
            if (this.subMenu == 5)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayMedium.png");
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if(this.subMenu==2)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentSmall.png");
            if (this.subMenu == 3)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidaySmall.png");
            if (this.subMenu == 4)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendSmall.png");
            if (this.subMenu == 5)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidaySmall.png");
            this.boton = 3;

            this.BotonPulsado();
        }

        private void btnEliminarEmpleado_MouseHover(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentBig.png");
            if (this.subMenu == 3)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayBig.png");
            if (this.subMenu == 4)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendBig.png");
            if (this.subMenu == 5)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayBig.png");
        }

        private void btnEliminarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            if (this.subMenu == 2)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentMedium.png");
            if (this.subMenu == 3)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayMedium.png");
            if (this.subMenu == 4)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendMedium.png");
            if (this.subMenu == 5)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayMedium.png");
        }

        protected virtual void BotonPulsado()
        {
            if (oyente != null)
                oyente.Clic(this);
        }
    }
}
