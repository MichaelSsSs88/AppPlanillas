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

namespace AppPlanillas.GUI
{
    public partial class PanelFeriado : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        Dia_feriadoENT Dia_FeriadoENT;
        public PanelFeriado(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            if (pestaña == 1)
            {
               
            }
        }

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabFeriado.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabFeriado.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabFeriado.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertHoliday.Parent = null;
                this.tabEditHoliday.Parent = null;
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
            this.tabFeriado.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabFeriado.TabPages.Add(objColPages[intIndex]);
        }

       /* private void CargarTabla(int busqueda, int pestaña)
        {
            if (this.cmbEditarFeriado.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
            }
            if (this.cmbEliminarFeriado.SelectedIndex < 0)
            {
                this.panelEliminarFiltro.Visible = false;
            }

            this.Dia_FeriadoENT = new Dia_feriadoENT("Todos", "");
            Dia_FeriadoDAL horarioDAL = new HorarioDAL();
            if (busqueda == 1)
            {

                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, "");

                if (pestaña == 0)
                    this.dataGridView1.DataSource = this.HorarioENT.horarios;

                if (pestaña == 1)
                    this.dgvEditar.DataSource = this.HorarioENT.horarios;
                if (pestaña == 2)
                    this.dgvEliminar.DataSource = this.HorarioENT.horarios;
            }
            if (busqueda == 2)
            {
                try
                {

                    if (pestaña == 1)
                    {
                        this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(Int32.Parse(this.txtDatoABuscar.Text), "");
                        this.dgvEditar.DataSource = this.HorarioENT.horarios;
                    }

                    if (pestaña == 2)
                    {
                        this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(Int32.Parse(this.txtBuscarEliminar.Text), "");
                        this.dgvEliminar.DataSource = this.HorarioENT.horarios;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("EL identificador debe de ser numerico", "Datos Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            if (busqueda == 3)
            {

                if (pestaña == 1)
                {
                    this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, this.txtDatoABuscar.Text);
                    this.dgvEditar.DataSource = this.HorarioENT.horarios;
                }

                if (pestaña == 2)
                {
                    this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, this.txtBuscarEliminar.Text);
                    this.dgvEliminar.DataSource = this.HorarioENT.horarios;
                }

            }
        }*/
    }
}
