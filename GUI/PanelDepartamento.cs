using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppPlanillas.DAL;
using AppPlanillas.ENT;

namespace AppPlanillas.GUI
{
    public partial class PanelDepartamento : Form
    {

        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        public PanelDepartamento(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            DepartamentoENT nuevoDepartamento = new DepartamentoENT();
            this.dataGridView1.DataSource = nuevoDepartamento.departamentos;
        }

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabDepartamentos.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabDepartamentos.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabDepartamentos.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertDepartment.Parent = null;
                this.tabEditDepartment.Parent = null;
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
            this.tabDepartamentos.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabDepartamentos.TabPages.Add(objColPages[intIndex]);
        }

        private void btnGuardar_MouseHover(object sender, EventArgs e)
        {
            this.btnGuardar.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveBig.png");
        }

        private void btnGuardar_MouseLeave(object sender, EventArgs e)
        {
            this.btnGuardar.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveMedium1.png");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveSmall.png");
            DepartamentoENT nuevoDepartamento = new DepartamentoENT(-1,this.txtNombreDepartamento.Text,DateTime.Now.Date, "Prueba", DateTime.Now.Date, "Prueba", true);
            DepartamentoDAL guardarDepartamento = new DepartamentoDAL();
            guardarDepartamento.AgregarDepartamento(nuevoDepartamento);
            MessageBox.Show("¡Departamento insertado correctamente!", "Nuevo departamento", MessageBoxButtons.OK, MessageBoxIcon.Information);
            nuevoDepartamento = new DepartamentoENT();
            this.dataGridView1.DataSource = nuevoDepartamento.departamentos;
        }

        private void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveSmall.png");
        }

        private void btnReporte_MouseEnter(object sender, EventArgs e)
        {
            this.btnReporte.Image = new Bitmap(Application.StartupPath + @"\IMG\csvBig.png");
        }

        private void btnReporte_MouseLeave(object sender, EventArgs e)
        {
            this.btnReporte.Image = new Bitmap(Application.StartupPath + @"\IMG\csvMedium.png");
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            this.btnReporte.Image = new Bitmap(Application.StartupPath + @"\IMG\csvSmall.png");
        }
    }
}
