using AppPlanillas.ENT;
using DAL;
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
    public partial class PanelMarcas : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private UsuarioENT UsuarioENT;
        public PanelMarcas(int pestaña, UsuarioENT usuarioEnt)
        {
            this.UsuarioENT = usuarioEnt;
            InitializeComponent();
            this.ckbFecha_Click(null, null);
            this.ckbFechaFin_CheckedChanged(null, null);
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.HideTab(3);
            this.ShowTab(pestaña);
            this.cmbTipoMarca.SelectedIndex = 0;
            this.cmbEstado.SelectedIndex = 0;
            this.CargarTabla(pestaña, "", "");
        }

        private void CargarTabla(int pestaña, string filtro, string dato)
        {
            if (pestaña == 1)
            {

                this.dgvInsertar.DataSource = new MarcaDAL().ObtenerMarcas("","","",0,0,""); //new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 2)
            {
                this.dgvEditar.DataSource = new MarcaDAL().ObtenerMarcas("", "", "", 0, 0, "");//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
           /* if (pestaña == 2)
            {
                this.dgvEliminar.DataSource = new PuestoDAL().ObtenerPuestos(filtro, dato);//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }*/

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
                this.tabEditHour.Parent = null;
                this.tabInsertHour.Parent = null;
                this.tabFindClock.Parent = null;
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

        private void ckbFecha_Click(object sender, EventArgs e)
        {
            if (this.ckbFecha.Checked)
            {
                this.dtpFechaInicio.Visible = true;
            }
            else
            {
                this.dtpFechaInicio.Visible = false;
                if (this.ckbFechaFin.Checked)
                    this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
                else
                {
                    if(this.cmbEstado.SelectedItem!=null)
                        this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

                }
            }

            if (this.ckbFecha.Checked || this.ckbFechaFin.Checked)
                this.cmbTipoMarca.Enabled = true;
            else
            {
                this.cmbTipoMarca.SelectedIndex = 0;
                this.cmbTipoMarca.Enabled = false;
            }
        }

        private void ckbFechaFin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked)
            {
                this.dtpFechaFin.Visible = true;
            }
            else
            {
                this.dtpFechaFin.Visible = false;
                if (this.ckbFecha.Checked)
                    this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEstado.SelectedItem != null)
                        this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

                }
            }

            if (this.ckbFecha.Checked || this.ckbFechaFin.Checked)
                this.cmbTipoMarca.Enabled = true;
            else
            {
                this.cmbTipoMarca.SelectedIndex = 0;
                this.cmbTipoMarca.Enabled = false;
            }
                
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            // if (this.ckbFechaFin.Visible)
            //this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value,
            // else
            // this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            if(this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"),this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text),Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

            
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void cmbTipoMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if(this.cmbEstado.SelectedItem != null)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void ckbFecha_CheckedChanged(object sender, EventArgs e)
        {
            
        }
        public void Clic(object emisor, int pestaña, int panel)
        {
            if (panel == 1)
            {
                PanelBusqueda entrada = (PanelBusqueda)emisor;
                if(pestaña==3)
                {
                    this.txtEmpleado.Text = entrada.idEmpleado.ToString();
                    this.txtInsertarEmpleado.Text= entrada.idEmpleado.ToString();
                }
                    
                if(pestaña== 1)
                    this.txtDepartamento.Text = entrada.idDepartamento.ToString();
            }
        }

        private void linkEmpleado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(3, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void linkDepartamento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(1, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimeSpan diferencia = this.dtpInsertarFechaSalida.Value - this.dtpInsertarFechaEntrada.Value;

            if(diferencia.TotalMinutes>0)
            {
                if(this.txtInsertarEmpleado.Text!="0")
                    new MarcaDAL().AgregarMarcaManual(new MarcaENT(-1, this.dtpInsertarFechaEntrada.Value, this.dtpInsertarFechaSalida.Value, "generado", Int32.Parse(this.txtInsertarEmpleado.Text), null, null, DateTime.Today, this.UsuarioENT.Nombre, DateTime.Today, this.UsuarioENT.Nombre, 0));
                else
                    MessageBox.Show("Debe de seleccionar un empledao para asignar la marca", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else
                MessageBox.Show("La hora y feha de salida debe de ser mayor a la de entrada", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(3, null, null, this);
            panelBusqueda.ShowDialog();

        }

        private void ckbEditarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked)
                this.dgvEditar.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvEditar.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }
    }
}
