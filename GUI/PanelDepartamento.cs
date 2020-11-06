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
        private DepartamentoENT nuevoDepartamento;
        public PanelDepartamento(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.nuevoDepartamento = new DepartamentoENT();
            this.grdInsertar.DataSource = this.nuevoDepartamento.departamentos;
            this.grdActualizar.DataSource = this.nuevoDepartamento.departamentos;
            this.grdEliminar.DataSource = this.nuevoDepartamento.departamentos;
            this.pnlFiltroActualizar.Visible = false;
            this.pnlFiltroEliminar.Visible = false;
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
            this.grdInsertar.DataSource = nuevoDepartamento.departamentos;
        }

        private void btnGuardarEditar_Click(object sender, EventArgs e)
        {
            this.btnGuardar.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveSmall.png");
            if ((this.txtCodigoDepartamentoActualizar.Text != "") && (this.txtNombreDepartamentoActualizar.Text!="")) 
            { 
                DepartamentoDAL actualizarDepartamento = new DepartamentoDAL();
                this.nuevoDepartamento = new DepartamentoENT(Int32.Parse(this.txtCodigoDepartamentoActualizar.Text), this.txtNombreDepartamentoActualizar.Text, DateTime.Now.Date, "Jean Ca", DateTime.Now.Date, "Jean Ca", this.cbxActivoActualizar.Checked);
                actualizarDepartamento.ActualizarDepartamento(false, this.nuevoDepartamento);
                this.nuevoDepartamento = new DepartamentoENT();
                this.grdActualizar.DataSource = this.nuevoDepartamento.departamentos;
                this.txtCodigoDepartamentoActualizar.Text = "";
                this.txtNombreDepartamentoActualizar.Text = "";
                MessageBox.Show("¡Se modificado correctamente el departamento!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Debe seleccionar un departamento para editar!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
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

        private void textBox9_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
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
                catch
                {
                    MessageBox.Show("Error al cargar los datos de departamentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 0)
            {
                this.pnlFiltroActualizar.Visible = false;
                this.grdActualizar.DataSource = this.nuevoDepartamento.departamentos;
            }
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 1)
            {
                lblValorABuscar.Text = "Digite el código del departamento";
                this.pnlFiltroActualizar.Visible = true;
            }
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 2)
            {
                lblValorABuscar.Text = "Digite el nombre del departamento";
                this.pnlFiltroActualizar.Visible = true;
            }
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            int fila = this.grdActualizar.CurrentRow.Index;
            this.txtCodigoDepartamentoActualizar.Text = this.grdActualizar.Rows[fila].Cells[0].Value.ToString();
            this.txtNombreDepartamentoActualizar.Text = this.grdActualizar.Rows[fila].Cells[1].Value.ToString();
            this.cbxActivoActualizar.Checked = (bool)this.grdActualizar.Rows[fila].Cells[6].Value;
        }

        private void btnEliminarDepartamento_Click(object sender, EventArgs e)
        {
            if ((this.txtCodigoEliminar.Text != "") && (this.txtDescripcionEliminar.Text != ""))
            {
                DepartamentoDAL eliminarDepartamento = new DepartamentoDAL();
                this.nuevoDepartamento = new DepartamentoENT(Int32.Parse(this.txtCodigoEliminar.Text), this.txtDescripcionEliminar.Text, DateTime.Now.Date, "Jean Ca", DateTime.Now.Date, "Jean Ca", false);
                eliminarDepartamento.ActualizarDepartamento(true, this.nuevoDepartamento);
                this.nuevoDepartamento = new DepartamentoENT();
                this.grdEliminar.DataSource = this.nuevoDepartamento.departamentos;
                this.txtCodigoEliminar.Text = "";
                this.txtDescripcionEliminar.Text = "";
                MessageBox.Show("¡Se ha eliminado correctamente el departamento!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Debe seleccionar un departamento para eliminar!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbTipoBusquedaEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbTipoBusquedaEliminar.SelectedIndex == 0)
            {
                this.pnlFiltroEliminar.Visible = false;
                this.grdEliminar.DataSource = this.nuevoDepartamento.departamentos;
            }
            if (this.cmbTipoBusquedaEliminar.SelectedIndex == 1)
            {
                this.lblDigiteEliminar.Text = "Digite el código del departamento";
                this.pnlFiltroEliminar.Visible = true;
            }
            if (this.cmbTipoBusquedaEliminar.SelectedIndex == 2)
            {
                this.lblDigiteEliminar.Text = "Digite el nombre del departamento";
                this.pnlFiltroEliminar.Visible = true;
            }
        }

        private void txtBuscarEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    switch (this.cmbTipoBusquedaEliminar.Text)
                    {
                        case "Todos":
                            this.grdEliminar.DataSource = this.nuevoDepartamento.departamentos;
                            break;
                        case "Codigo":
                            this.grdEliminar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(Int32.Parse(this.txtBuscarEliminar.Text), "");
                            break;
                        case "Descripción":
                            this.grdEliminar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(-1, this.txtBuscarEliminar.Text);
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Error al cargar los datos de departamentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void grdEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.grdEliminar.CurrentRow.Index;
            this.txtCodigoEliminar.Text = this.grdEliminar.Rows[fila].Cells[0].Value.ToString();
            this.txtDescripcionEliminar.Text = this.grdEliminar.Rows[fila].Cells[1].Value.ToString();
        }

    }
}
