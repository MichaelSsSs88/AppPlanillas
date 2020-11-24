using AppPlanillas.DAL;
using AppPlanillas.ENT;
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
    public partial class PanelPuestos : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private UsuarioENT UsuarioENT;
        public PanelPuestos(int pestaña, UsuarioENT usuarioEnt)
        {
            this.UsuarioENT = usuarioEnt;
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.panelFiltro.Visible = false;
            this.cmbEditarBusqueda.SelectedIndex = 0;
            this.cmbEliminarBusqueda.SelectedIndex = 0;
            this.CargarTabla(pestaña, "Todos","");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(1, this, null,null);
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

        private void CargarTabla(int pestaña, string filtro, string dato)
        {
            if (pestaña == 0)
            {
                
                this.dgvInsertar.DataSource = new PuestoDAL().ObtenerPuestos(filtro, dato); //new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 1)
            {
                this.dgvEditar.DataSource = new PuestoDAL().ObtenerPuestos(filtro, dato);//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 2)
            {
                this.dgvEliminar.DataSource = new PuestoDAL().ObtenerPuestos(filtro, dato);//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }

        }

        private void LimpiarEditar()
        {
            this.txtEditarCodigo.Text = "";
            this.txtEditarDescripcion.Text = "";
            this.txtEditarDepartamento.Text = "";
            this.ckbEditarActivo.Checked = false;

        }

        private void LimpiarEliminar()
        {
            this.txtEliminarCodigo.Text = "";
            this.txtEliminarDescripcion.Text = "";
            this.txtEliminarDepartamento.Text = "";
            this.ckbEliminarActivo.Checked = false;
            this.txtEliminarBuscar.Text = "";

        }

        public void Clic(object emisor, int pestaña, int panel)
        {
            if (panel == 1)
            {
                PanelBusqueda entrada = (PanelBusqueda)emisor;
                if (pestaña == 1)
                {
                    this.txtInsertarDepartamento.Text=entrada.idDepartamento.ToString();
                    this.txtEditarDepartamento.Text = entrada.idDepartamento.ToString();
                }
                if (pestaña == 2)
                {
                    this.txtEditarDepartamento.Text = entrada.idDepartamento.ToString();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.txtInsertarDepartamento.Text != "" && this.txtInsertarDescripcion.Text != "")
            {
                new PuestoDAL().AgregarPuesto(new PuestoENT(-1, this.txtInsertarDescripcion.Text, Int32.Parse(this.txtInsertarDepartamento.Text), DateTime.Now, this.UsuarioENT.Nombre, DateTime.Now, this.UsuarioENT.Nombre, this.ckbInsertarActivo.Checked));
                this.CargarTabla(0, "Todos", "");
                MessageBox.Show("El puesto se guardo correctamente", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else{
                MessageBox.Show("Todos los datos deben de ser completados", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(1, this, null,null);
            panelBusqueda.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (this.txtEditarDepartamento.Text != "" && this.txtEditarDescripcion.Text != "")
            {
                new PuestoDAL().ActualizarPuestos(new PuestoENT(Int32.Parse(this.txtEditarCodigo.Text), this.txtEditarDescripcion.Text, Int32.Parse(this.txtEditarDepartamento.Text), DateTime.Now, this.UsuarioENT.Nombre, DateTime.Now, this.UsuarioENT.Nombre, this.ckbEditarActivo.Checked));
                this.LimpiarEditar();
                this.cmbEditarBusqueda.SelectedIndex = -1;
                this.txtEditarBuscar.Text = "";
                this.CargarTabla(1, "Todos", "");
                MessageBox.Show("El puesto se actualizo correctamente", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Todos los datos deben de ser completados", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void cmbEditarFeriado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.cmbEditarBusqueda.SelectedIndex > 0)
            {
                this.panelFiltro.Visible = true;
                if (this.cmbEditarBusqueda.SelectedIndex == 1)
                {
                    this.lblValorABuscar.Text = "Digite el codigo: ";
                }
                else if (this.cmbEditarBusqueda.SelectedIndex == 2)
                {
                    this.lblValorABuscar.Text = "Digite la descripcion: ";
                }
                else
                {
                    this.lblValorABuscar.Text = "Digite el código del departamento: ";
                }

            }
            else
            {
                this.panelFiltro.Visible = false;

            }
        }

        private void txtEditarBuscar_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.txtEditarBuscar.Text == "")
            {
                this.CargarTabla(1, "Todos", "");
            }
            else
            {
                this.CargarTabla(1, this.cmbEditarBusqueda.SelectedItem.ToString(), this.txtEditarBuscar.Text);
            }
        }

        private void dgvEditar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEditar.CurrentRow.Index;
            this.txtEditarCodigo.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            this.txtEditarDescripcion.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            this.txtEditarDepartamento.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
            this.ckbEditarActivo.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn15"].Value.ToString());
        }

        private void cmbEliminarBusqueda_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEliminar();
            if (this.cmbEliminarBusqueda.SelectedIndex > 0)
            {
                this.panelEliminarFiltro.Visible = true;
                if (this.cmbEliminarBusqueda.SelectedIndex == 1)
                {
                    this.lblEliminarBusca.Text = "Digite el codigo: ";
                }
                else if (this.cmbEliminarBusqueda.SelectedIndex == 2)
                {
                    this.lblEliminarBusca.Text = "Digite la descripcion: ";
                }
                else
                {
                    this.lblEliminarBusca.Text = "Digite el código del departamento: ";
                }

            }
            else
            {
                if (this.cmbEliminarBusqueda.SelectedIndex == 0)
                {
                    this.CargarTabla(2, "Todos", "");
                }
                    this.panelEliminarFiltro.Visible = false;

            }
        }

        private void txtEliminarBuscar_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEliminar();
            if (this.txtEliminarBuscar.Text == "")
            {
                this.CargarTabla(2, "Todos", "");
            }
            else
            {
                this.CargarTabla(2, this.cmbEliminarBusqueda.SelectedItem.ToString(), this.txtEliminarBuscar.Text);
            }
        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEliminar.CurrentRow.Index;
            this.txtEliminarCodigo.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            this.txtEliminarDescripcion.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            this.txtEliminarDepartamento.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            this.ckbEliminarActivo.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn16"].Value.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtEliminarCodigo.Text != "")
                {
                    new PuestoDAL().EliminarPuesto(Int32.Parse(this.txtEliminarCodigo.Text));
                    this.LimpiarEliminar();
                    this.cmbEliminarBusqueda.SelectedIndex = -1;
                    this.txtEliminarBuscar.Text = "";
                    this.CargarTabla(2, "Todos", "");
                    MessageBox.Show("El puesto se elimino correctamente", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Debe de existir pusto seleccionado para eliminar", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("El puesto no puede ser eliminado", "Puestos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerarCSV generarCSV = new GenerarCSV(this.dgvInsertar);
            generarCSV.ExportarDatos(this.dgvInsertar);
        }
    }
}
