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
        int subMenu;
        public SubMenuFeriados(int numeroSubMenu)
        {
            this.subMenu = numeroSubMenu;
            InitializeComponent();
            this.ajustarBotones(this.subMenu);
        }

        public void ajustarBotones(int numeroSubMenu)
        {
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

        }

        private void btnInsertar_MouseHover(object sender, EventArgs e)
        {
            
            if (this.subMenu == 3)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayBig.png");
            }
            if (this.subMenu == 4)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendBig.png");
            }
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidaySmall.png");
            }
            if (this.subMenu == 4)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendSmall.png");
            }

        }

        private void btnInsertar_MouseLeave(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertHolidayMedium.png");
            }
            if (this.subMenu == 4)
            {
                this.btnInsertar.Image = new Bitmap(Application.StartupPath + @"\IMG\insertSpendMedium.png");
            }
        }

        private void btnEditarEmpleado_Click(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidaySmall.png");
            }
            if (this.subMenu == 4)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendSmall.png");
            }
        }

        private void btnEditarEmpleado_MouseHover(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayBig.png");
            }
            if (this.subMenu == 4)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendBig.png");
            }
        }

        private void btnEditarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editHolidayMedium.png");
            }
            if (this.subMenu == 4)
            {
                this.btnEditar.Image = new Bitmap(Application.StartupPath + @"\IMG\editSpendMedium.png");
            }
        }

        private void btnEliminarEmpleado_Click(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidaySmall.png");
            if (this.subMenu == 4)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendSmall.png");
        }

        private void btnEliminarEmpleado_MouseHover(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayBig.png");
            if (this.subMenu == 4)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendBig.png");
        }

        private void btnEliminarEmpleado_MouseLeave(object sender, EventArgs e)
        {
            if (this.subMenu == 3)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteHolidayMedium.png");
            if (this.subMenu == 4)
                this.btnEliminar.Image = new Bitmap(Application.StartupPath + @"\IMG\deleteSpendMedium.png");
        }
    }
}
