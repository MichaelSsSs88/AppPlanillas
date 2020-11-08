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
    public partial class PanelFeriado : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        Dia_feriadoENT Dia_FeriadoENT;
        public PanelFeriado(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.cmbEditarFeriado.SelectedIndex=0;
            this.cmbEliminarFeriado.SelectedIndex = 0;
            this.CargarTabla(pestaña);
            if (pestaña == 1)
            {
               
            }
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
                this.tabInsertHoliday.Parent = null;
                this.tabEditHoliday.Parent = null;
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

       private void CargarTabla(int pestaña)
        {
            if(this.cmbEditarFeriado.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
            }
            if (this.cmbEliminarFeriado.SelectedIndex < 0)
            {
                this.panelEliminarFiltro.Visible = false;
            }

            this.Dia_FeriadoENT = new Dia_feriadoENT("Todos", "");
            Dia_feriadoDAL feriadoDAL = new Dia_feriadoDAL();


            if (pestaña == 0)
            {
                this.Dia_FeriadoENT.feriados = feriadoDAL.ObtenerFeriados("Todos", "");
                this.dgvInsertar.DataSource = this.Dia_FeriadoENT.feriados;
            }

            if (pestaña == 1)
            {
                if (this.txtBuscarEditar.Text == "")
                {
                    this.Dia_FeriadoENT.feriados = feriadoDAL.ObtenerFeriados("Todos", this.txtBuscarEditar.Text);
                }
                else
                {
                    this.Dia_FeriadoENT.feriados = feriadoDAL.ObtenerFeriados(this.cmbEditarFeriado.SelectedItem.ToString(), this.txtBuscarEditar.Text);
                }
                
                this.dgvEditar.DataSource = this.Dia_FeriadoENT.feriados;
            }
            if (pestaña == 2)
            {
                this.Dia_FeriadoENT.feriados = feriadoDAL.ObtenerFeriados(this.cmbEliminarFeriado.SelectedItem.ToString(), this.txtEliminarBuscar.Text);
                this.dgvEliminar.DataSource = this.Dia_FeriadoENT.feriados;
            }
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Dia_FeriadoENT = new Dia_feriadoENT(-1, Int32.Parse(this.cmbInsertarDia.SelectedItem.ToString()), Int32.Parse(this.cmbInsertarMes.SelectedItem.ToString()), this.txtInsertarMotivo.Text, this.ckbPago.Checked,DateTime.Now,"Marvin", DateTime.Now, "Julio",this.ckbActivo.Checked );
            Dia_feriadoDAL feriadoDAL = new Dia_feriadoDAL();
            feriadoDAL.AgregarFeriado(this.Dia_FeriadoENT);
            this.CargarTabla(0);
            MessageBox.Show("EL feriado fue agregado exitosamente", "Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbEditarFeriado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.cmbEditarFeriado.SelectedIndex == 0)
            {
                this.CargarTabla(1);
                this.panelFiltro.Visible = false;
            }
            if (this.cmbEditarFeriado.SelectedIndex == 1)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el codigo del feriado: ";
            }
            if (this.cmbEditarFeriado.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el mes del feriado: ";
            }
            if (this.cmbEditarFeriado.SelectedIndex == 3)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el motivo del feriado: ";
            }
        }

        private void txtBuscarEditar_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            this.CargarTabla(1);
            
        }

        private void LimpiarEditar()
        {
            this.txtEditarCodigo.Text = "";
            this.txtEditarMotivo.Text = "";
            this.cmbEditarMes.SelectedIndex = -1;
            this.cmbEditarDia.SelectedIndex = -1;
            this.ckbEditarPago.Checked = true;
            this.ckbActivo.Checked = true;
        }

        private void LimpiarEliminar()
        {
            this.txtEliminarId.Text = "";
            this.txtEliminarMotivo.Text = "";
            this.cmbEliminarMes.SelectedIndex = -1;
            this.cmbEliminarDia.SelectedIndex = -1;
            this.chkEliminarPago.Checked = true;
            this.chkEliminarActivo.Checked = true;
        }

        private void dgvEditar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEditar.CurrentRow.Index;
            this.txtEditarCodigo.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            this.txtEditarMotivo.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            this.cmbEditarMes.SelectedItem = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            this.cmbEditarDia.SelectedItem = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
            this.ckbEditarPago.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn5"].Value.ToString());
            this.ckbEditarActivo.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn17"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveSmall.png");
            if (this.txtEditarMotivo.Text != "" && this.cmbEditarDia.SelectedIndex!=-1 && this.cmbEditarMes.SelectedIndex != -1)
            {
                this.Dia_FeriadoENT = new Dia_feriadoENT(Int32.Parse(this.txtEditarCodigo.Text), Int32.Parse(this.cmbEditarDia.SelectedItem.ToString()), Int32.Parse(this.cmbEditarMes.SelectedItem.ToString()), this.txtEditarMotivo.Text, this.ckbEditarPago.Checked, DateTime.Now, "", DateTime.Now, "Frank", this.ckbEditarActivo.Checked);
                Dia_feriadoDAL feriadoDAL = new Dia_feriadoDAL();
                feriadoDAL.ActualizarDiaFeriado(this.Dia_FeriadoENT);
                MessageBox.Show("EL feriado fue editado exitosamente", "Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.cmbEditarDia.SelectedIndex = -1;
                this.LimpiarEditar();
                this.CargarTabla(1);
                
            }
            else
            {
                MessageBox.Show("Todos los datos deben de estar completos", "Feriados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveBig.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveMedium1.png");
        }

        private void cmbEliminarFeriado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEliminar();
            if (this.cmbEliminarFeriado.SelectedIndex == 0)
            {
                this.CargarTabla(2);
                this.panelEliminarFiltro.Visible = false;
            }
            if (this.cmbEliminarFeriado.SelectedIndex == 1)
            {
                this.panelEliminarFiltro.Visible = true;
                this.lblEliminarBusca.Text = "Digite el codigo del feriado: ";
            }
            if (this.cmbEliminarFeriado.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblEliminarBusca.Text = "Digite el mes del feriado: ";
            }
            if (this.cmbEliminarFeriado.SelectedIndex == 3)
            {
                this.panelEliminarFiltro.Visible = true;
                this.lblEliminarBusca.Text = "Digite el motivo del feriado: ";
            }

        }

        private void txtEliminarBuscar_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEliminar();
            this.CargarTabla(2);
        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEliminar.CurrentRow.Index;
            this.txtEliminarId.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            this.txtEliminarMotivo.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            this.cmbEliminarMes.SelectedItem = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
            this.cmbEliminarDia.SelectedItem = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            this.chkEliminarPago.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn11"].Value.ToString());
            this.chkEliminarActivo.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn20"].Value.ToString());
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentMedium.png");
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentBig.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentSmall.png");
            if (this.txtEliminarId.Text != "")
            {
                Dia_feriadoDAL feriadoDAL = new Dia_feriadoDAL();
                try
                {
                    feriadoDAL.EliminarDiaFeriado(Int32.Parse(this.txtEliminarId.Text));
                    MessageBox.Show("El feriado fue eliminado correctamente", "Feriados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.cmbEliminarFeriado.SelectedIndex = 0;
                    this.LimpiarEliminar();
                    this.CargarTabla(2);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("El feriado no fue eliminado correctamente", "Feriados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }
    }
}
