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
    public partial class PanelEmpleados : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        public PanelEmpleados(int pestaña)
        {
            InitializeComponent();
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
                arrBoolPagesVisible = new bool[this.tabDepartamentos.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabDepartamentos.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabDepartamentos.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertEmployed.Parent = null;
                this.tabEditEmployed.Parent = null;
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

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarEmpleado_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (this.comboBox3.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
            }*/
            if (this.comboBox3.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
                if (this.comboBox3.SelectedIndex == 1)
                {
                    this.lblValorABuscar.Text = "Digiten el numero de cédula: ";
                }
                else
                {
                    this.lblValorABuscar.Text = "Digite el nombre: ";
                }

            }
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (this.comboBox3.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
                if (this.comboBox3.SelectedIndex == 0)
                {
                    this.lblValorABuscar.Text = "Digiten el numero de cédula: ";
                }
                else
                {
                    this.lblValorABuscar.Text = "Digite el nombre: ";
                }
                
            }*/
        }
    }

    
}
