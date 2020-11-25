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
            this.ckbEditarFecha_CheckedChanged(null, null);
            this.ckbEditarFechaFin_CheckedChanged(null, null);
            this.ckbEliminarFecha_CheckedChanged(null, null);
            this.ckbEliminarFechaFin_CheckedChanged(null, null);
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.HideTab(3);
            this.ShowTab(pestaña);
            this.cmbTipoMarca.SelectedIndex = 0;
            this.cmbEstado.SelectedIndex = 0;
            this.cmbEditarTipoMarca.SelectedIndex = 0;
            this.cmbEditarEstado.SelectedIndex = 0;
            this.cmbEliminarTipoMarca.SelectedIndex = 0;
            this.cmbEliminarEstado.SelectedIndex = 0;
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
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", "", 0, 0, "");//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 3)
            {
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", "", 0, 0, "");//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
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
                    this.txtEditarEmpleado.Text = entrada.idEmpleado.ToString();
                    this.txtEliminarEmpleado.Text = entrada.idEmpleado.ToString();
                    this.txtInsertarEmpleado.Text= entrada.idEmpleado.ToString();
                }
                    
                if(pestaña== 1)
                    this.txtDepartamento.Text = entrada.idDepartamento.ToString();
                    this.txtEditarDepartamento.Text = entrada.idDepartamento.ToString();
                    this.txtEliminarDepartamento.Text = entrada.idDepartamento.ToString();
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
            if(this.ckbEditarFecha.Checked)
            {
                this.dtpEditarFechaInicio.Visible = true;
            }
            else
            {
                this.dtpEditarFechaInicio.Visible = false;
                if (this.ckbEditarFechaFin.Checked)
                    this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEditarEstado.SelectedItem != null)
                        this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());

                }
            }

            if (this.ckbEditarFecha.Checked || this.ckbEditarFechaFin.Checked)
                this.cmbEditarTipoMarca.Enabled = true;
            else
            {
                this.cmbEditarTipoMarca.SelectedIndex = 0;
                this.cmbEditarTipoMarca.Enabled = false;
            }
        }

        private void dtpEditarFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFechaFin.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());

        }

        private void ckbEditarFechaFin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFechaFin.Checked)
            {
                this.dtpEditarFechaFin.Visible = true;
            }
            else
            {
                this.dtpEditarFechaFin.Visible = false;
                if (this.ckbEditarFecha.Checked)
                    this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEditarEstado.SelectedItem != null)
                        this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());

                }
            }

            if (this.ckbEditarFecha.Checked || this.ckbEditarFechaFin.Checked)
                this.cmbEditarTipoMarca.Enabled = true;
            else
            {
                this.cmbEditarTipoMarca.SelectedIndex = 0;
                this.cmbEditarTipoMarca.Enabled = false;
            }
        }

        private void dtpEditarFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());

        }

        private void cmbEditarTipoMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFechaFin.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.cmbEditarEstado.SelectedItem != null)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
        }

        private void txtEditarEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFechaFin.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.cmbEditarEstado.SelectedItem != null)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
        }

        private void label1_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFechaFin.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.cmbEditarEstado.SelectedItem != null)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());

        }

        private void linkLabel4_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(3, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(1, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void cmbEditarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbEditarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFecha.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEditarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.ckbEditarFechaFin.Checked)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEditarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());
            else if (this.cmbEditarEstado.SelectedItem != null)
                this.dgvEditarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEditarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEditarEmpleado.Text), Int32.Parse(this.txtEditarDepartamento.Text), this.cmbEditarEstado.SelectedItem.ToString());


        }

        private void dgvEditar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEditarMarca.CurrentRow.Index;
            Console.WriteLine(fila);
            if (this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString() == "generado")
            {
                this.txtEditarCodigo.Text = this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
                if (this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString() != "")
                {
                    this.dtpEditarEntrada.Text = this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
                    this.dtpEditarEntrada.Checked = true;
                }
                   
                else
                    this.dtpEditarEntrada.Checked = false;

                if (this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value != null)
                {
                    this.dtpEditarSalida.Text = this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
                    this.dtpEditarSalida.Checked = true;
                }
                   
                else
                    this.dtpEditarSalida.Checked = false;

                this.txtEditarIdEmpleado.Text = this.dgvEditarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn5"].Value.ToString();
               /// this.ckbEditarActivo.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn15"].Value.ToString());
            }
            else
                MessageBox.Show("La marca seleccionada debe de estar en estado generado", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.txtEditarCodigo.Text!= "")
            {
                
                DateTime? inicio = null;
                DateTime? salida = null;
                if (this.dtpEditarEntrada.Checked)
                    inicio = this.dtpEditarEntrada.Value;
                if (this.dtpEditarSalida.Checked)
                    salida = this.dtpEditarSalida.Value;

                new MarcaDAL().EditarMarca(new MarcaENT(Int32.Parse(this.txtEditarCodigo.Text), inicio, salida, "generado", Int32.Parse(this.txtEditarIdEmpleado.Text), null, null, DateTime.Now, "", DateTime.Now, this.UsuarioENT.Nombre, 0));
                CargarTabla(2, "", "");
            }
            else
            {
                MessageBox.Show("Debe seleccionar la marca a editar ", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ckbEliminarFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFecha.Checked)
            {
                this.dtpEliminarFechaInicio.Visible = true;
            }
            else
            {
                this.dtpEliminarFechaInicio.Visible = false;
                if (this.ckbEliminarFechaFin.Checked)
                    this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEliminarEstado.SelectedItem != null)
                        this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());

                }
            }

            if (this.ckbEliminarFecha.Checked || this.ckbEliminarFechaFin.Checked)
                this.cmbEliminarTipoMarca.Enabled = true;
            else
            {
                this.cmbEliminarTipoMarca.SelectedIndex = 0;
                this.cmbEliminarTipoMarca.Enabled = false;
            }
        }

        private void dtpEliminarFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFechaFin.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());

        }

        private void ckbEliminarFechaFin_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFechaFin.Checked)
            {
                this.dtpEliminarFechaFin.Visible = true;
            }
            else
            {
                this.dtpEliminarFechaFin.Visible = false;
                if (this.ckbEliminarFecha.Checked)
                    this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEliminarEstado.SelectedItem != null)
                        this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());

                }
            }

            if (this.ckbEliminarFecha.Checked || this.ckbEliminarFechaFin.Checked)
                this.cmbEliminarTipoMarca.Enabled = true;
            else
            {
                this.cmbEliminarTipoMarca.SelectedIndex = 0;
                this.cmbEliminarTipoMarca.Enabled = false;
            }
        }

        private void dtpEliminarFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());

        }

        private void cmbEliminarTipoMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFechaFin.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.cmbEliminarEstado.SelectedItem != null)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
        }

        private void txtEliminarEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFechaFin.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.cmbEliminarEstado.SelectedItem != null)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
        }

        private void label2_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFechaFin.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.cmbEliminarEstado.SelectedItem != null)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());

        }

        private void linkLabel6_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(3, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void linkLabel5_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(1, null, null, this);
            panelBusqueda.ShowDialog();
        }

        private void cmbEliminarEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbEliminarFechaFin.Checked && this.ckbEditarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFecha.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas(this.dtpEliminarFechaInicio.Value.ToString("dd/MM/yyyy HH:mm"), "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.ckbEliminarFechaFin.Checked)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", this.dtpEliminarFechaFin.Value.ToString("dd/MM/yyyy HH:mm"), this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());
            else if (this.cmbEliminarEstado.SelectedItem != null)
                this.dgvEliminarMarca.DataSource = new MarcaDAL().ObtenerMarcas("", "", this.cmbEliminarTipoMarca.SelectedItem.ToString(), Int32.Parse(this.txtEliminarEmpleado.Text), Int32.Parse(this.txtEliminarDepartamento.Text), this.cmbEliminarEstado.SelectedItem.ToString());


        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEliminarMarca.CurrentRow.Index;
            Console.WriteLine(fila);
            if (this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn10"].Value.ToString() == "generado")
            {
                this.txtEliminarCodigo.Text = this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
                if (this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString() != "")
                {
                    this.dtpEliminarEntrada.Text = this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
                    this.dtpEliminarEntrada.Checked = true;
                }

                else
                    this.dtpEliminarEntrada.Checked = false;

                if (this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value != null)
                {
                    this.dtpEliminarSalida.Text = this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
                    this.dtpEliminarSalida.Checked = true;
                }

                else
                    this.dtpEliminarSalida.Checked = false;

                this.txtEliminarIdEmpleado.Text = this.dgvEliminarMarca.Rows[fila].Cells["dataGridViewTextBoxColumn11"].Value.ToString();
                /// this.ckbEliminarActivo.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn15"].Value.ToString());
            }
            else
                MessageBox.Show("La marca seleccionada debe de estar en estado generado", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtEliminarCodigo.Text != "")
            {
                try
                {
                    new MarcaDAL().EliminarMarca(Int32.Parse(this.txtEliminarCodigo.Text));
                    this.CargarTabla(3, "", "");
                }
                catch
                {
                    MessageBox.Show("No se puede eliminar la marca,contactar administrador del sistema", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("Debe seleccionar la marca a eliminar ", "Marcas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
