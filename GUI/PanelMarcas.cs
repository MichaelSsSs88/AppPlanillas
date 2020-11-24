using DAL;
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
        public PanelMarcas()
        {
            InitializeComponent();
            this.ckbFecha_Click(null, null);
            this.ckbFechaFin_CheckedChanged(null, null);
            this.cmbTipoMarca.SelectedIndex = 0;
            this.cmbEstado.SelectedIndex = 0;
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
                    this.txtEmpleado.Text = entrada.idEmpleado.ToString();
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
    }
}
