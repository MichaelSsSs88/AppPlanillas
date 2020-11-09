using AppPlanillas.DAL;
using AppPlanillas.ENT;
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
    public partial class PanelBusqueda : Form
    {
        private DepartamentoENT nuevoDepartamento;
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        public int idDepartamento { get; set; }
        public PanelPuestos oyente = null;
        public PanelBusqueda(int pestaña, PanelPuestos listen)
        {
            InitializeComponent();
            this.cmbTipoBusquedaActualizar.SelectedIndex = 0;
            this.pnlFiltroActualizar.Visible = false;
            this.oyente = listen;
            this.CargaTabla(pestaña);
        }
        private void LimpiarEditar()
        {
            this.txtEditarCodigo.Text = "";
            this.txtEditarDescripcion.Text = "";
            this.ckbEditarActivo.Checked = true;
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

        private void CargaTabla(int pestaña)
        {
            if (pestaña == 1)
            {
                this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(-1, "");
            }
        }
        


        private void cmbTipoBusquedaActualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 0)
            {
                this.pnlFiltroActualizar.Visible = false;
                this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(-1, "");
                this.txtBuscarActualizar.Text = "";
            }
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 1)
            {
                lblValorABuscar.Text = "Digite el código del departamento";
                this.pnlFiltroActualizar.Visible = true;
                this.txtBuscarActualizar.Text = "";
            }
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 2)
            {
                lblValorABuscar.Text = "Digite el nombre del departamento";
                this.pnlFiltroActualizar.Visible = true;
                this.txtBuscarActualizar.Text = "";
            }
            this.txtEditarCodigo.Text = "";
            this.txtEditarDescripcion.Text = "";
        }

        private void txtBuscarActualizar_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            try
            {
                if (this.txtBuscarActualizar.Text == "")
                {
                    this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(-1, "");
                }
                else
                {
                    switch (this.cmbTipoBusquedaActualizar.Text)
                    {
                        case "Todos":
                            this.grdActualizar.DataSource = this.nuevoDepartamento.departamentos;
                            break;
                        case "Codigo":
                            this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(Int32.Parse(this.txtBuscarActualizar.Text), "");
                            break;
                        case "Descripción":
                            this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(-1, this.txtBuscarActualizar.Text);
                            break;
                        default:
                            break;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error al cargar los datos de departamentos o parametros no aceptados", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void grdActualizar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.grdActualizar.CurrentRow.Index;
            this.txtEditarCodigo.Text = this.grdActualizar.Rows[fila].Cells[0].Value.ToString();
            this.txtEditarDescripcion.Text = this.grdActualizar.Rows[fila].Cells[1].Value.ToString();
            this.ckbEditarActivo.Checked = (bool)this.grdActualizar.Rows[fila].Cells[6].Value;
            this.ckbEditarActivo.Enabled = false;
        }

        private void btnGuardarActualizar_Click(object sender, EventArgs e)
        {
            if (this.txtEditarCodigo.Text != "")
                this.idDepartamento = Int32.Parse(this.txtEditarCodigo.Text);
            else
            {
                MessageBox.Show("Debe de seleccionar un departamento valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.BotonPulsado();
            this.Close();
        }

        protected virtual void BotonPulsado()
        {
            if (oyente != null)
                oyente.Clic(this,1,1);
        }
    }
}
