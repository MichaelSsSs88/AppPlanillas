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
            this.CargarTabla(1,1);
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
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
            this.HorarioENT = new HorarioENT();
            HorarioDAL horarioDAL = new HorarioDAL();
            if (busqueda == 1)
            {

                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, "");
                this.dataGridView1.DataSource = this.HorarioENT.horarios;
            }
            if(busqueda == 2)
            {
                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(Int32.Parse(this.txtDatoABuscar.Text), "") ;
            }
            if(busqueda == 3)
            {
                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, this.txtDatoABuscar.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Console.WriteLine(this.dtpHoraSalida.Value.ToShortTimeString());
           // DateTime hora this.dtpHoraSalida.
                TimeSpan hora2 = TimeSpan.Parse(this.dtpHoraSalida.Value.ToString("HH:mm"));
            DateTime hora = hora2;
            Console.WriteLine(hora);
            /*this.HorarioENT = new HorarioENT(-1, this.dtpHoraEntrada.Value, this.dtpHoraSalida.Value.ToString(), this.cmbDia.SelectedItem.ToString(), this.txtDescripcion.Text, Int32.Parse(this.txtHorasOrdinarias.Text), DateTime.Now.Date, "Pablo", DateTime.Now.Date, "Pablo", true);
            HorarioDAL horarioDAL = new HorarioDAL();
            horarioDAL.AgregarHorario(this.HorarioENT);
            this.CargarTabla(1,1);*/

        }
    }
}
