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
using DAL;

namespace AppPlanillas.GUI
{
    public partial class PanelDeduccion : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private DeduccionENT nuevaDeduccion;
        private UsuarioENT UsuarioENT;
        public PanelDeduccion(int pestaña, UsuarioENT pusuarioENT)
        {
            this.UsuarioENT = pusuarioENT;
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
                    if (this.txtEmpleadoInsertar.Text != "")
                    {
                        this.nuevaDeduccion = new DeduccionENT(0, this.txtDescripcionInsertar.Text, this.cmbSistemaAplicacionInsertar.Text, Double.Parse(this.txtPorcentajeMontoInsertar.Text), Int32.Parse(this.txtEmpleadoInsertar.Text), DateTime.Now.Date, this.UsuarioENT.Nombre, DateTime.Now.Date, this.UsuarioENT.Nombre, this.cbxActivoInsertar.Checked);
                    }
                    else
                    {
                        this.nuevaDeduccion = new DeduccionENT(0, this.txtDescripcionInsertar.Text, this.cmbSistemaAplicacionInsertar.Text, Double.Parse(this.txtPorcentajeMontoInsertar.Text), 0, DateTime.Now.Date, this.UsuarioENT.Nombre, DateTime.Now.Date, this.UsuarioENT.Nombre, this.cbxActivoInsertar.Checked);
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
            this.txtEmpleadoInsertar.Text = "";
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
            this.txtIdEmpleadoEditar.Text = "";
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
            if ((int)this.grdEditar.Rows[fila].Cells[4].Value == 0)
            {
                this.txtIdEmpleadoEditar.Text = "";
            }
            else
            {
                this.txtIdEmpleadoEditar.Text = this.grdEditar.Rows[fila].Cells[4].Value.ToString();
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

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            if ((this.txtIdEditar.Text != "") && (this.txtDescripcionEditar.Text != "") && (this.txtValorEditar.Text != "") && (this.cmbSistemaEditar.SelectedIndex >= 0) && (this.cmbSistemaEditar.Text != ""))
            {
                DeduccionDAL actualizarDeduccion = new DeduccionDAL();
                if (this.txtIdEmpleadoEditar.Text == "")
                {
                    this.nuevaDeduccion = new DeduccionENT(Int32.Parse(this.txtIdEditar.Text), this.txtDescripcionEditar.Text, this.cmbSistemaEditar.Text, Double.Parse(this.txtValorEditar.Text), 0, DateTime.Now.Date, this.UsuarioENT.Nombre, DateTime.Now.Date, this.UsuarioENT.Nombre, this.cbxActivoEditar.Checked);
                }
                else
                {
                    this.nuevaDeduccion = new DeduccionENT(Int32.Parse(this.txtIdEditar.Text), this.txtDescripcionEditar.Text, this.cmbSistemaEditar.Text, Double.Parse(this.txtValorEditar.Text), Int32.Parse(this.txtIdEmpleadoEditar.Text), DateTime.Now.Date, this.UsuarioENT.Nombre, DateTime.Now.Date, this.UsuarioENT.Nombre, this.cbxActivoEditar.Checked);
                }
                actualizarDeduccion.ActualizarDeduccion(this.nuevaDeduccion);
                this.nuevaDeduccion = new DeduccionENT();
                this.grdEditar.DataSource = this.nuevaDeduccion.deducciones;
                this.LimpiarEditar();
                MessageBox.Show("¡Se modificado correctamente la deducción!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("¡Debe seleccionar un departamento para editar!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void cmbBusquedaEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.cmbBusquedaEliminar.SelectedIndex)
            {
                case 0:
                    this.panelFiltroEliminar.Visible = false;
                    this.LimpiarEliminar();
                    break;
                case 1:
                    this.lblValorABuscarEliminar.Text = "Digite el código de la deducción:";
                    this.LimpiarEliminar();
                    this.panelFiltroEliminar.Visible = true;

                    break;
                case 2:
                    this.lblValorABuscarEliminar.Text = "Digite la descripción de la deducción:";
                    this.LimpiarEliminar();
                    this.panelFiltroEliminar.Visible = true;
                    break;
            }
        }

        private void LimpiarEliminar()
        {
            this.txtValorABuscarEliminar.Text = "";
            this.txtIdEliminar.Text = "";
            this.txtDescripcionEliminar.Text = "";
            this.txtValorEliminar.Text = "";
            this.txtIdEmpleadoEliminar.Text = "";
            this.cmbSistemaEliminar.SelectedIndex = -1;
        }

        private void txtValorABuscarEliminar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    switch (this.cmbBusquedaEliminar.Text)
                    {
                        case "Todos":
                            this.grdEliminar.DataSource = this.nuevaDeduccion.deducciones;
                            break;
                        case "Código":
                            this.grdEliminar.DataSource = new DeduccionDAL().ObtenerDeducciones(Int32.Parse(this.txtValorABuscarEliminar.Text), "");
                            break;
                        case "Descripción":
                            this.grdEliminar.DataSource = new DeduccionDAL().ObtenerDeducciones(-1, this.txtValorABuscarEliminar.Text);
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
            this.txtIdEliminar.Text = "";
            this.txtDescripcionEliminar.Text = "";
            this.txtValorEliminar.Text = "";
            this.txtIdEmpleadoEliminar.Text = "";
            this.cmbSistemaEliminar.SelectedIndex = -1;
        }

        private void grdEliminar_Click(object sender, EventArgs e)
        {
            int fila = this.grdEliminar.CurrentRow.Index;
            this.txtIdEliminar.Text = this.grdEliminar.Rows[fila].Cells[0].Value.ToString();
            this.txtDescripcionEliminar.Text = this.grdEliminar.Rows[fila].Cells[1].Value.ToString();
            if (this.grdEliminar.Rows[fila].Cells[3].Value.ToString() == "Porcentaje")
            {
                this.cmbSistemaEliminar.SelectedIndex = 0;
            }
            else
            {
                this.cmbSistemaEliminar.SelectedIndex = 1;
            }
            if ((int)this.grdEliminar.Rows[fila].Cells[4].Value == 0)
            {
                this.txtIdEmpleadoEliminar.Text = "";
            }
            else
            {
                this.txtIdEmpleadoEliminar.Text = this.grdEliminar.Rows[fila].Cells[4].Value.ToString();
            }
            this.txtValorEliminar.Text = this.grdEliminar.Rows[fila].Cells[2].Value.ToString();
            this.cbxActivoEliminar.Checked = (bool)this.grdEliminar.Rows[fila].Cells[9].Value;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if ((this.txtIdEliminar.Text != "") && (this.txtDescripcionEliminar.Text != "") && (this.txtValorEliminar.Text != ""))
            {
                DeduccionDAL eliminarDeduccion = new DeduccionDAL();
                if (eliminarDeduccion.EliminarDeduccion(Int32.Parse(this.txtIdEliminar.Text)) == 0)
                {
                    this.nuevaDeduccion = new DeduccionENT();
                    this.grdEliminar.DataSource = this.nuevaDeduccion.deducciones;
                    this.LimpiarEliminar();
                    MessageBox.Show("¡Se ha eliminado correctamente la deducción!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("¡Ha ocurrido un error al eliminar la deducción, intentelo de nuevo o contacte al administrador del sistema!", "Eliminar deducción", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("¡Debe seleccionar una deducción para eliminar!", "Actualización de registro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Clic(object emisor, int pestaña, int panel)
        {
            if (panel == 1)
            {
                PanelBusqueda entrada = (PanelBusqueda)emisor;
                if (pestaña == 3)
                {
                    this.txtEmpleadoInsertar.Text = entrada.idEmpleado.ToString();
                    this.txtIdEmpleadoEditar.Text = entrada.idEmpleado.ToString();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(3, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(3, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerarCSV generarCSV = new GenerarCSV(this.grdInsertar);
            generarCSV.ExportarDatos(this.grdInsertar);
        }
    }
}
