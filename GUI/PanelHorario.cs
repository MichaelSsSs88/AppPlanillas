using ProyectoIIIC;
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
    public partial class PanelHorario : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        HorarioENT HorarioENT;
        public PanelHorario(int pestaña)
        {
            
           
            InitializeComponent();
            // this.dataGridView1.DataSource = this.HorarioENT.horarios;
            
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.CargarTabla(1, pestaña);
            if (this.comboBox3.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
            }
        }

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabHorario.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabHorario.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabHorario.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertSchedule.Parent = null;
                this.tabEditSchedule.Parent = null;
            }

        }


        /// <summary>
        ///     Muestra una ficha
        /// </summary>
        public void ShowTab(int intTab)
        {
            ShowHideTab(intTab, true);
        }

        /// <summary>
        ///     Oculta una ficha
        /// </summary>
        public void HideTab(int intTab)
        {
            ShowHideTab(intTab, false);
        }

        /// <summary>
        ///     Muestra / oculta una ficha
        /// </summary>
        public void ShowHideTab(int intTab, bool blnVisible)
        { // Inicializa el control
            InitControl();
            // Oculta la página
            arrBoolPagesVisible[intTab] = blnVisible;
            // Elimina todas las fichas
            this.tabHorario.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabHorario.TabPages.Add(objColPages[intIndex]);
        }

        private void CargarTabla(int busqueda, int pestaña)
        {
            Console.WriteLine(pestaña);
            this.HorarioENT = new HorarioENT();
            HorarioDAL horarioDAL = new HorarioDAL();
            if (busqueda == 1)
            {

                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, "");

                if(pestaña==0)
                    this.dataGridView1.DataSource = this.HorarioENT.horarios;

                if(pestaña==1)
                    this.dataGridView2.DataSource = this.HorarioENT.horarios;
            }
            if(busqueda == 2)
            {
                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(Int32.Parse(this.txtDatoABuscar.Text), "") ;
                if (pestaña == 1)
                    this.dataGridView2.DataSource = this.HorarioENT.horarios;
            }
            if(busqueda == 3)
            {
                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, this.txtDatoABuscar.Text);
                if (pestaña == 1)
                    this.dataGridView2.DataSource = this.HorarioENT.horarios;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //Console.WriteLine(this.dtpHoraSalida.Value.ToShortTimeString());
           // DateTime hora this.dtpHoraSalida.
                /*TimeSpan hora2 = TimeSpan.Parse(this.dtpHoraSalida.Value.ToString("dd/MM/yyyy HH:mm"));
            //Console.WriteLine(this.dtpHoraSalida.Value);
            //Console.WriteLine(this.dtpHoraSalida.Value.ToShortTimeString());
            //DateTime hora = hora2;
            Console.WriteLine(hora2);*/
            this.HorarioENT = new HorarioENT(-1, this.dtpHoraEntrada.Value, this.dtpHoraSalida.Value, this.cmbDia.SelectedItem.ToString(), this.txtDescripcion.Text, Int32.Parse(this.txtHorasOrdinarias.Text), DateTime.Now.Date, "Pablo", DateTime.Now.Date, "Pablo", true);
            HorarioDAL horarioDAL = new HorarioDAL();
            horarioDAL.AgregarHorario(this.HorarioENT);
            this.CargarTabla(0,1);

        }

        private void dtpHoraEntrada_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas =  TimeSpan.Parse(this.dtpHoraSalida.Value.ToString("HH:mm"))- TimeSpan.Parse(this.dtpHoraEntrada.Value.ToString("HH:mm")) ;
            this.txtHorasOrdinarias.Text = horas.Hours.ToString();
          //  this.txtHorasOrdinarias.Text = this.dtpHoraEntrada.Value.ToShortTimeString() - this.dtpHoraSalida.Value.ToShortTimeString();
        }

        private void dtpHoraSalida_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas =  TimeSpan.Parse(this.dtpHoraSalida.Value.ToString("HH:mm"))- TimeSpan.Parse(this.dtpHoraEntrada.Value.ToString("HH:mm")) ;
            this.txtHorasOrdinarias.Text = horas.Hours.ToString();
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDia.SelectedIndex == 0)
            {
                this.panelFiltro.Visible = false;
            }
            if (this.cmbDia.SelectedIndex == 1)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el codigo del horario: ";
            }
            if (this.cmbDia.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el día del horario: ";
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.comboBox3.SelectedIndex == 0)
            {
                this.panelFiltro.Visible = false;
                this.txtDatoABuscar.Text = "";
                this.CargarTabla(1,1);
            }
            if (this.comboBox3.SelectedIndex == 1)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el codigo del horario: ";
            }
            if (this.comboBox3.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el día del horario: ";
            }

        }

        private void txtDatoABuscar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(this.comboBox3.SelectedIndex==1)
                   this.CargarTabla(2,1);
                else
                {
                    this.CargarTabla(3, 1);
                }
            }
        }
    }
}
