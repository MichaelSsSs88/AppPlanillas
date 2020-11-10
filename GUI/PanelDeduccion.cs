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
    public partial class PanelDeduccion : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private DeduccionENT nuevaDeduccion;
        public PanelDeduccion(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.nuevaDeduccion = new DeduccionENT();
            this.grdInsertar.DataSource = nuevaDeduccion.deducciones;
            this.grdEditar.DataSource = nuevaDeduccion.deducciones;
            this.grdEliminar.DataSource = nuevaDeduccion.deducciones;
            this.panelFiltro.Visible = false;
            this.panelFiltroEliminar.Visible = false;
        }

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabDeduccion.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabDeduccion.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabDeduccion.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertDeducción.Parent = null;
                this.tabEditDeducción.Parent = null;
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
            this.tabDeduccion.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabDeduccion.TabPages.Add(objColPages[intIndex]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.cmbSistemaAplicacionInsertar.SelectedIndex < 0)
            {
                MessageBox.Show("¡Debe seleccionar un sistema de aplicación de deducción!", "Ingresar deducción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (this.txtDescripcionInsertar.Text == "" || this.txtPorcentajeMontoInsertar.Text == "")
                {
                    MessageBox.Show("¡Debe completar la información de la deducción!", "Ingresar deducción", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    if (this.cmbEmpleadoInsertar.SelectedIndex >= 0)
                    {
                        this.nuevaDeduccion = new DeduccionENT(0, this.txtDescripcionInsertar.Text, this.cmbSistemaAplicacionInsertar.Text, Double.Parse(this.txtPorcentajeMontoInsertar.Text), Int32.Parse(this.cmbEmpleadoInsertar.Text), DateTime.Now.Date, "Jean Ca", DateTime.Now.Date, "Jean Ca", this.cbxActivoInsertar.Checked);
                    }
                    else
                    {
                        this.nuevaDeduccion = new DeduccionENT(0, this.txtDescripcionInsertar.Text, this.cmbSistemaAplicacionInsertar.Text, Double.Parse(this.txtPorcentajeMontoInsertar.Text), 0, DateTime.Now.Date, "Jean Ca", DateTime.Now.Date, "Jean Ca", this.cbxActivoInsertar.Checked);
                    }
                    try
                    {
                        DeduccionDAL insertarDeduccion = new DeduccionDAL();
                        insertarDeduccion.AgregarDeduccion(this.nuevaDeduccion);
                        MessageBox.Show("¡Se ha ingresado correctamente la deducción!", "Ingresar deducción", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.nuevaDeduccion = new DeduccionENT();
                        this.grdInsertar.DataSource = this.nuevaDeduccion.deducciones;
                        this.LimpiarInsertar();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("¡Ha ocurrido un error al insertar la deduccipon: " + ex.Message + "!", "Ingresar deducción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void LimpiarInsertar()
        {
            this.txtDescripcionInsertar.Text = "";
            this.cmbSistemaAplicacionInsertar.SelectedIndex = -1;
            this.txtPorcentajeMontoInsertar.Text = "";
            this.cmbEmpleadoInsertar.SelectedIndex = -1;
        }

        private void cmbSistemaAplicacionInsertar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.cmbSistemaAplicacionInsertar.SelectedIndex)
            {
                case 0:
                    this.lblValorInsertar.Text = "Indique el porcentaje de deducción:";
                    break;
                case 1:
                    this.lblValorInsertar.Text = "Indique el monto de deducción:";
                    break;
                default:
                    this.lblValorInsertar.Text = "Indique el:";
                    break;
            }
        }

        private void cmbBusquedaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch(this.cmbBusquedaEditar.SelectedIndex)
            {
                case 0:
                    this.panelFiltro.Visible = false;
                    break;
                case 1:
                    this.lblValorABuscarEditar.Text = "Digite el código de la deducción:";
                    this.LimpiarEditar();
                    this.panelFiltro.Visible = true;
     
                    break;
                case 2:
                    this.lblValorABuscarEditar.Text = "Digite la descripción de la deducción:";
                    this.LimpiarEditar();
                    this.panelFiltro.Visible = true;
                    break;
            }
        }

        private void LimpiarEditar()
        {
            this.txtBuscarEditar.Text = "";
            this.txtIdEditar.Text = "";
            this.txtDescripcionEditar.Text = "";
            this.txtValorEditar.Text = "";
            this.cmbSistemaEditar.SelectedIndex = -1;
            this.cbxActivoEditar.Checked = true;
        }

        private void grdEditar_Click(object sender, EventArgs e)
        {
            int fila = this.grdEditar.CurrentRow.Index;
            this.txtIdEditar.Text = this.grdEditar.Rows[fila].Cells[0].Value.ToString();
            this.txtDescripcionEditar.Text = this.grdEditar.Rows[fila].Cells[1].Value.ToString();
            if (this.grdEditar.Rows[fila].Cells[3].Value.ToString() == "Porcentaje")
            {
                this.cmbSistemaEditar.SelectedIndex = 0;
            }
            else
            {
                this.cmbSistemaEditar.SelectedIndex = 1;
            }
            this.txtValorEditar.Text = this.grdEditar.Rows[fila].Cells[2].Value.ToString();
            this.cbxActivoEditar.Checked = (bool)this.grdEditar.Rows[fila].Cells[9].Value;
        }

        private void cmbSistemaEditar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbSistemaEditar.SelectedIndex)
            {
                case 0:
                    this.lblValorEditar.Text = "Indique el porcentaje de deducción:";
                    break;
                case 1:
                    this.lblValorEditar.Text = "Indique el monto de deducción:";
                    break;
                default:
                    this.lblValorEditar.Text = "Indique el:";
                    break;
            }
        }

        private void txtBuscarEditar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    switch (this.cmbBusquedaEditar.Text)
                    {
                        case "Todos":
                            this.grdEditar.DataSource = this.nuevaDeduccion.deducciones;
                            break;
                        case "Código":
                            this.grdEditar.DataSource = new DeduccionDAL().ObtenerDeducciones(Int32.Parse(this.txtBuscarEditar.Text), "");
                            break;
                        case "Descripción":
                            this.grdEditar.DataSource = new DeduccionDAL().ObtenerDeducciones(-1, this.txtBuscarEditar.Text);
                            break;
                        default:
                            break;
                    }
                }
                catch
                {
                    MessageBox.Show("Error al cargar los datos de departamentos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };
            this.txtIdEditar.Text = "";
            this.txtDescripcionEditar.Text = "";
            this.txtValorEditar.Text = "";
            this.cmbSistemaEditar.SelectedIndex = -1;
            this.cbxActivoEditar.Checked = true;
        }
    }
}
