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
    public partial class PanelPuestos : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        public PanelPuestos(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.cmbEditarFeriado.SelectedIndex = 0;
            this.cmbEliminarFeriado.SelectedIndex = 0;
            //this.CargarTabla(pestaña);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(1, this);
            panelBusqueda.ShowDialog();
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
                this.tabInsertJob.Parent = null;
                this.tabEditJob.Parent = null;
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

        public void Clic(object emisor, int pestaña, int panel)
        {
            if (panel == 1)
            {
                PanelBusqueda entrada = (PanelBusqueda)emisor;
                if (pestaña == 1)
                {
                    this.txtInsertarDepartamento.Text=entrada.idDepartamento.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
