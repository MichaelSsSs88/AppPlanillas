﻿using AppPlanillas.DAL;
using AppPlanillas.ENT;
using GUI;
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
    public partial class PanelBusqueda : Form
    {
        private DepartamentoENT nuevoDepartamento;
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private int pestaña;
        public int idDepartamento { get; set; }
        public int idPuesto { get; set; }

        public int idEmpleado { get; set; }

        public PanelPuestos oyente = null;
        public PanelEmpleados oyenteEmpleados = null;
        public PanelDeduccion oyentepanelDeduccion = null;

        public PanelBusqueda(int pestaña, PanelPuestos listen, PanelEmpleados listenEmpleado, PanelDeduccion listenDeduccion)
        {
            InitializeComponent();
            this.cmbTipoBusquedaActualizar.SelectedIndex = 0;
            this.cmbBusquedaPuestos.SelectedIndex = 0;
            this.pnlFiltroActualizar.Visible = false;
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña-1);

            if(listen!=null)
                    this.oyente = listen;
            if (listenEmpleado != null)
                this.oyenteEmpleados = listenEmpleado;
            if (listenDeduccion != null)
                this.oyentepanelDeduccion = listenDeduccion;

            this.pestaña = pestaña;
            this.CargaTabla(pestaña,"Todos","");
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

        private void CargaTabla(int pestaña, string pFiltro, string pBusqueda)
        {
            if (pestaña == 1)
            {
                this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos("-1", "");
            }
            if (pestaña == 2)
            {
                this.dgvInsertar.DataSource = new PuestoDAL().ObtenerPuestos(pFiltro,pBusqueda);
            }
            if (pestaña == 3)
            {
                this.dgvEditar.DataSource = new EmpleadoDAL().ObtenerEmpleados(pFiltro, pBusqueda);
            }
        }
        


        private void cmbTipoBusquedaActualizar_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.cmbTipoBusquedaActualizar.SelectedIndex == 0)
            {
                this.pnlFiltroActualizar.Visible = false;
                this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos("-1", "");
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
                    this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos("-1", "");
                }
                else
                {
                    switch (this.cmbTipoBusquedaActualizar.Text)
                    {
                        case "Todos":
                            this.grdActualizar.DataSource = this.nuevoDepartamento.departamentos;
                            break;
                        case "Codigo":
                            this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos(this.txtBuscarActualizar.Text, "");
                            break;
                        case "Descripción":
                            this.grdActualizar.DataSource = new DepartamentoDAL().ObtenerDepartamentos("-1", this.txtBuscarActualizar.Text);
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
                oyente.Clic(this,this.pestaña,1);
            if(oyenteEmpleados!=null)
                oyenteEmpleados.Clic(this, this.pestaña, 1);
            if (oyentepanelDeduccion != null)
                oyentepanelDeduccion.Clic(this, this.pestaña, 1);
        }

        private void LimpiarEditarPuestos()
        {
            this.txtEditarCodigo.Text = "";
            this.txtEditarDescripcion.Text = "";
            this.ckbEditarActivo.Checked = true;
        }
        private void cmbBusquedaPuestos_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditarPuestos();
            if (this.cmbBusquedaPuestos.SelectedIndex > 0)
            {
                this.panelFiltro.Visible = true;
                if (this.cmbBusquedaPuestos.SelectedIndex == 1)
                {
                    this.lblPuestoABuscar.Text = "Digite el codigo: ";
                }
                else if (this.cmbBusquedaPuestos.SelectedIndex == 2)
                {
                    this.lblPuestoABuscar.Text = "Digite la descripcion: ";
                }
                else
                {
                    this.lblPuestoABuscar.Text = "Digite el código del departamento: ";
                }

            }
            else
            {
                this.CargaTabla(2, "Todos", "");
                this.panelFiltro.Visible = false;

            }
        }

        private void txtBuscarEditar_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBuscarPuestos_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.cmbBusquedaPuestos.Text == "")
            {
                this.CargaTabla(2, "Todos", "");
            }
            else
            {
                this.CargaTabla(2, this.cmbBusquedaPuestos.SelectedItem.ToString(), this.txtBuscarPuestos.Text);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.txtCodigoPuesto.Text != "")
                this.idPuesto = Int32.Parse(this.txtCodigoPuesto.Text);
            else
            {
                MessageBox.Show("Debe de seleccionar un puesto valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.BotonPulsado();
            this.Close();

        }

        private void dgvInsertar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvInsertar.CurrentRow.Index;
            this.txtCodigoPuesto.Text = this.dgvInsertar.Rows[fila].Cells["Id"].Value.ToString();
            this.txtInsertarDescripcion.Text = this.dgvInsertar.Rows[fila].Cells["Descripcion"].Value.ToString();
            this.txtInsertarDepartamento.Text = this.dgvInsertar.Rows[fila].Cells["Id_departamento"].Value.ToString();
            this.ckbActivo.Checked = Boolean.Parse(this.dgvInsertar.Rows[fila].Cells["Activo"].Value.ToString());

        }

        private void LimpiarEditarEmpleado()
        {
            this.txtEditarCedula.Text = "";
            this.txtEditarNombre.Text = "";
            this.txtEditarApellido1.Text = "";
            this.txtEditarApellido2.Text = "";
            this.dtpEditarFechaNacimiento.Value = DateTime.Today;
            this.txtEditarPuesto.Text = "";
            this.txtEditarSalarioHora.Text = "";
            this.picEditarImg.Image = null;
            this.ckbEditarActivo.Checked = false;

        }

        private void cmbEditarBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditarEmpleado();
            if (this.cmbEditarBusqueda.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
                if (this.cmbEditarBusqueda.SelectedIndex == 1)
                {
                    this.lblValorABuscar.Text = "Digite el numero de cédula: ";
                }
                else
                {
                    this.lblValorABuscar.Text = "Digite el nombre completo: ";
                }

            }
            else
            {
                this.panelFiltro.Visible = false;

            }
        }

        private void txtEditarBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.txtEditarBusqueda.Text == "")
            {
                this.CargaTabla(3, "Todos", "");
            }
            else
            {
                this.CargaTabla(3, this.cmbEditarBusqueda.SelectedItem.ToString(), this.txtEditarBusqueda.Text);
            }
        }

        private void dgvEditar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEditar.CurrentRow.Index;
            this.txtEditarCedula.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            this.txtEditarNombre.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            this.txtEditarApellido1.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
            this.txtEditarApellido2.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            this.dtpEditarFechaNacimiento.Value = DateTime.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn5"].Value.ToString()).Date;
            this.txtEditarPuesto.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
            this.txtEditarSalarioHora.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn13"].Value.ToString();
            this.picEditarImg.Image = (Image)this.dgvEditar.Rows[fila].Cells["dataGridViewImageColumn1"].Value;


            this.ckbEditarActivo.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn19"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtEditarCedula.Text != "")
                this.idEmpleado = Int32.Parse(this.txtEditarCedula.Text);
            else
            {
                MessageBox.Show("Debe de seleccionar un empleado valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.BotonPulsado();
            this.Close();
        }
    }
}
