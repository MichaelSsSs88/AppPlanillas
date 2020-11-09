using DAL;
using ENT;
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
    public partial class PanelHorario : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        HorarioENT HorarioENT;
        public PanelHorario(int pestaña)
        {
            
           
            InitializeComponent();
            // this.dataGridView1.DataSource = this.HorarioENT.horarios;
            
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.CargarTabla(1, pestaña);
           
        }

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabHorario.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabHorario.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabHorario.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertSchedule.Parent = null;
                this.tabEditSchedule.Parent = null;
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
            this.tabHorario.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabHorario.TabPages.Add(objColPages[intIndex]);
        }

        private void CargarTabla(int busqueda, int pestaña)
        {
            if (this.cmbEditarHorario.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
            }
            if (this.cmbEliminarHorario.SelectedIndex < 0)
            {
                this.panelEliminarFiltro.Visible = false;
            }

            this.HorarioENT = new HorarioENT();
            HorarioDAL horarioDAL = new HorarioDAL();
            if (busqueda == 1)
            {

                this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, "");

                if(pestaña==0)
                    this.dataGridView1.DataSource = this.HorarioENT.horarios;

                if(pestaña==1)
                    this.dgvEditar.DataSource = this.HorarioENT.horarios;
                if(pestaña == 2)
                    this.dgvEliminar.DataSource = this.HorarioENT.horarios;
            }
            if(busqueda == 2)
            {
                try
                {
                   
                    if (pestaña == 1)
                    {
                        this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(Int32.Parse(this.txtDatoABuscar.Text), "");
                        this.dgvEditar.DataSource = this.HorarioENT.horarios;
                    }
                       
                    if (pestaña == 2)
                    {
                        this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(Int32.Parse(this.txtBuscarEliminar.Text), "");
                        this.dgvEliminar.DataSource = this.HorarioENT.horarios;
                    }
                        

                }
                catch (Exception ex)
                {
                    MessageBox.Show("EL identificador debe de ser numerico", "Datos Erroneos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
            }
            if(busqueda == 3)
            {
                
                if (pestaña == 1)
                {
                    this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, this.txtDatoABuscar.Text);
                    this.dgvEditar.DataSource = this.HorarioENT.horarios;
                }
                   
                if (pestaña == 2)
                {
                    this.HorarioENT.horarios = horarioDAL.ObtenerHorarios(-1, this.txtBuscarEliminar.Text);
                    this.dgvEliminar.DataSource = this.HorarioENT.horarios;
                }
                   
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.button3.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveSmall.png");
           
            if (this.dtpHoraEntrada.Value.ToString() != "" && this.dtpHoraSalida.Value.ToString() != "" && this.cmbDia.SelectedItem != null && this.txtDescripcion.Text != "" && Int32.Parse(this.txtHorasOrdinarias.Text) > 0)
            { 
                this.HorarioENT = new HorarioENT(-1, this.dtpHoraEntrada.Value, this.dtpHoraSalida.Value, this.cmbDia.SelectedItem.ToString(), this.txtDescripcion.Text, Int32.Parse(this.txtHorasOrdinarias.Text), DateTime.Now.Date, "Pablo", DateTime.Now.Date, "Pablo", this.ckbActivo.Checked);
                HorarioDAL horarioDAL = new HorarioDAL();
                horarioDAL.AgregarHorario(this.HorarioENT);
                MessageBox.Show("El horario fue creado correctamente", "Horarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.CargarTabla(1,0);
            }
            else
            {
                MessageBox.Show("Datos erroneos, la hora inicial debe de ser menor que la final", "Datos incompletos", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void dtpHoraEntrada_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas =  TimeSpan.Parse(this.dtpHoraSalida.Value.ToString("HH:mm"))- TimeSpan.Parse(this.dtpHoraEntrada.Value.ToString("HH:mm")) ;
            this.txtHorasOrdinarias.Text = horas.Hours.ToString();
          //  this.txtHorasOrdinarias.Text = this.dtpHoraEntrada.Value.ToShortTimeString() - this.dtpHoraSalida.Value.ToShortTimeString();
        }

        private void dtpHoraSalida_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas =  TimeSpan.Parse(this.dtpHoraSalida.Value.ToString("HH:mm"))- TimeSpan.Parse(this.dtpHoraEntrada.Value.ToString("HH:mm")) ;
            this.txtHorasOrdinarias.Text = horas.Hours.ToString();
        }

        private void cmbDia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbDia.SelectedIndex == 0)
            {
                this.panelFiltro.Visible = false;
            }
            if (this.cmbDia.SelectedIndex == 1)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el codigo del horario: ";
            }
            if (this.cmbDia.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el día del horario: ";
            }

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtDatoABuscar.Text = "";
            //this.cmbEditarHorario.SelectedIndex = -1;
            this.txtEditarId.Text = "";
            this.txtEditarDescripcion.Text = "";
            this.dtpEditarEntrada.Value = DateTime.Now;
            this.dtpEditarSalida.Value = DateTime.Now;
            this.cmbEditarDia.SelectedIndex = -1;
            this.txtEditarHoras.Text = "";

            if (this.cmbEditarHorario.SelectedIndex == 0)
            {
                this.panelFiltro.Visible = false;
                this.txtDatoABuscar.Text = "";
                this.CargarTabla(1,1);
            }
            if (this.cmbEditarHorario.SelectedIndex == 1)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el codigo del horario: ";
            }
            if (this.cmbEditarHorario.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el día del horario: ";
            }
            this.txtDatoABuscar.Text = "";

        }

        private void txtDatoABuscar_KeyDown(object sender, KeyEventArgs e)
        {
            

            if (e.KeyCode == Keys.Enter)
            {
                if(this.cmbEditarHorario.SelectedIndex==1)
                   this.CargarTabla(2,1);
                else
                {
                    this.CargarTabla(3, 1);
                }
            }
        }

        private void panel3_Click(object sender, EventArgs e)
        {

        }

        private void dgvEditar_MouseClick(object sender, MouseEventArgs e)
        {
            
            int fila = this.dgvEditar.CurrentRow.Index;
            this.txtEditarId.Text = this.dgvEditar.Rows[fila].Cells[0].Value.ToString();
            this.txtEditarDescripcion.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            this.cmbEditarDia.SelectedItem = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
           
            this.dtpEditarEntrada.Value =  DateTime.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString());
            this.dtpEditarSalida.Value = DateTime.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn5"].Value.ToString());
            this.txtEditarHoras.Text= this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn6"].Value.ToString();
            this.chbEditarActivo.Checked= Boolean.Parse(this.dgvEditar.Rows[fila].Cells[10].Value.ToString());
            //this.txtCodigoDepartamentoActualizar.Text = this.grdActualizar.Rows[fila].Cells[0].Value.ToString();
            //this.txtNombreDepartamentoActualizar.Text = this.grdActualizar.Rows[fila].Cells[1].Value.ToString();
        }

        private void dtpEditarEntrada_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas = TimeSpan.Parse(this.dtpEditarSalida.Value.ToString("HH:mm")) - TimeSpan.Parse(this.dtpEditarEntrada.Value.ToString("HH:mm"));
            this.txtEditarHoras.Text = horas.Hours.ToString();
        }

        private void dtpEditarSalida_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas = TimeSpan.Parse(this.dtpEditarSalida.Value.ToString("HH:mm")) - TimeSpan.Parse(this.dtpEditarEntrada.Value.ToString("HH:mm"));
            this.txtEditarHoras.Text = horas.Hours.ToString();
        }

        private void txtDatoABuscar_TextChanged(object sender, EventArgs e)
        {
            //this.txtDatoABuscar.Text = "";
            //this.cmbEditarHorario.SelectedIndex = -1;
            this.txtEditarId.Text = "";
            this.txtEditarDescripcion.Text = "";
            this.dtpEditarEntrada.Value = DateTime.Now;
            this.dtpEditarSalida.Value = DateTime.Now;
            this.cmbEditarDia.SelectedIndex = -1;
            this.txtEditarHoras.Text = "";
            if (this.txtDatoABuscar.Text == "")
            {
                this.CargarTabla(1, 1);
            }
            else if (this.cmbEditarHorario.SelectedIndex == 1)
            {

                this.CargarTabla(2, 1);
            }
            else if (this.cmbEditarHorario.SelectedIndex == 2)
            {
                this.CargarTabla(3, 1);
            }
        }

        private void button3_MouseHover(object sender, EventArgs e)
        {
            this.button3.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveBig.png");
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            this.button3.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveMedium1.png");
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveBig.png");
        
            
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            this.button1.Image = new Bitmap(Application.StartupPath + @"\IMG\SaveMedium1.png");
        }

        private void button1_MouseClick(object sender, MouseEventArgs e)
        {
            if (this.dtpEditarEntrada.Value.ToString() != "" && this.dtpEditarSalida.Value.ToString() != "" && this.cmbEditarDia.SelectedItem != null && this.txtEditarDescripcion.Text != "" && Int32.Parse(this.txtEditarHoras.Text) > 0)
            {
                this.HorarioENT = new HorarioENT(Int32.Parse(this.txtEditarId.Text), this.dtpEditarEntrada.Value, this.dtpEditarSalida.Value, this.cmbEditarDia.SelectedItem.ToString(), this.txtEditarDescripcion.Text, Int32.Parse(this.txtEditarHoras.Text), DateTime.Now.Date, "Pablo", DateTime.Now.Date, "Carlos", this.chbEditarActivo.Checked);
                HorarioDAL horarioDAL = new HorarioDAL();
                horarioDAL.ActualizarHorario(this.HorarioENT);
                this.txtDatoABuscar.Text = "";
                this.cmbEditarHorario.SelectedIndex = -1;
                this.txtEditarId.Text = "";
                this.txtEditarDescripcion.Text = "";
                this.dtpEditarEntrada.Value = DateTime.Now;
                this.dtpEditarSalida.Value = DateTime.Now;
                this.cmbEditarDia.SelectedIndex = -1;
                this.txtEditarHoras.Text = "";
                this.panelFiltro.Visible = false;
                MessageBox.Show("El horario fue actualizado exitosamente", "Actualizacion Horarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.CargarTabla(1, 1);
            }
            else
            {
             MessageBox.Show("Datos erroneos, la hora inicial debe de ser menor que la final", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dtpEliminarEntrada_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas = TimeSpan.Parse(this.dtpEliminarSalida.Value.ToString("HH:mm")) - TimeSpan.Parse(this.dtpEliminarEntrada.Value.ToString("HH:mm"));
            this.txtEliminarHoras.Text = horas.Hours.ToString();
        }

        private void dtpEliminarSalida_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan horas = TimeSpan.Parse(this.dtpEliminarSalida.Value.ToString("HH:mm")) - TimeSpan.Parse(this.dtpEliminarEntrada.Value.ToString("HH:mm"));
            this.txtEliminarHoras.Text = horas.Hours.ToString();
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.txtBuscarEliminar.Text = "";
            //this.cmbEliminarHorario.SelectedIndex = -1;
            this.txtEliminarId.Text = "";
            this.txtEliminarDescripcion.Text = "";
            this.dtpEliminarEntrada.Value = DateTime.Now;
            this.dtpEliminarSalida.Value = DateTime.Now;
            this.cmbEliminarDia.SelectedIndex = -1;
            this.txtEliminarHoras.Text = "";
            if (this.cmbEliminarHorario.SelectedIndex == 0)
            {
                this.panelEliminarFiltro.Visible = false;
                this.txtBuscarEliminar.Text = "";
                this.CargarTabla(1, 2);
            }
            if (this.cmbEliminarHorario.SelectedIndex == 1)
            {
                this.panelEliminarFiltro.Visible = true;
                this.lblValorEliminar.Text = "Digite el codigo del horario: ";
            }
            if (this.cmbEliminarHorario.SelectedIndex == 2)
            {
                this.panelEliminarFiltro.Visible = true;
                this.lblValorEliminar.Text = "Digite el día del horario: ";
            }
            this.txtDatoABuscar.Text = "";

        }

        private void txtBuscarEliminar_TextChanged(object sender, EventArgs e)
        {
            //this.txtBuscarEliminar.Text = "";
            //this.cmbEliminarHorario.SelectedIndex = -1;
            this.txtEliminarId.Text = "";
            this.txtEliminarDescripcion.Text = "";
            this.dtpEliminarEntrada.Value = DateTime.Now;
            this.dtpEliminarSalida.Value = DateTime.Now;
            this.cmbEliminarDia.SelectedIndex = -1;
            this.txtEliminarHoras.Text = "";
            if (this.txtBuscarEliminar.Text == "")
            {
                this.CargarTabla(1, 2);
            }
            else if (this.cmbEliminarHorario.SelectedIndex == 1)
            {

                this.CargarTabla(2, 2);
            }
            else if (this.cmbEliminarHorario.SelectedIndex == 2)
            {
                this.CargarTabla(3, 2);
            }
        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEliminar.CurrentRow.Index;
            this.txtEliminarId.Text = this.dgvEliminar.Rows[fila].Cells[0].Value.ToString();
            this.txtEliminarDescripcion.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            this.cmbEliminarDia.SelectedItem = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();

            this.dtpEliminarEntrada.Value = DateTime.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn10"].Value.ToString());
            this.dtpEliminarSalida.Value = DateTime.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn11"].Value.ToString());
            this.txtEliminarHoras.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
            this.chbEliminarActivo.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells[10].Value.ToString());
        }

        private void button2_MouseHover(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentBig.png");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentMedium.png");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.button2.Image = new Bitmap(Application.StartupPath + @"\IMG\deletedepartamentSmall.png");
            if(this.txtEliminarId.Text != "")
            {
                HorarioDAL horarioDAL = new HorarioDAL();
                try
                {
                    horarioDAL.EliminarHorario(Int32.Parse(this.txtEliminarId.Text));
                    MessageBox.Show("El horario fue eliminado correctamente", "Proceso de borrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtBuscarEliminar.Text = "";
                    this.cmbEliminarHorario.SelectedIndex = -1;
                    this.txtEliminarId.Text = "";
                    this.txtEliminarDescripcion.Text = "";
                    this.dtpEliminarEntrada.Value = DateTime.Now;
                    this.dtpEliminarSalida.Value = DateTime.Now;
                    this.cmbEliminarDia.SelectedIndex = -1;
                    this.txtEliminarHoras.Text = "";
                    this.CargarTabla(1, 2);
                }
                catch(Exception ex)
                {
                    MessageBox.Show("El horario no se puede eliminar", "Error de borrado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               
                
            }
            else
            {
                MessageBox.Show("Debe de existir un horario seleccionado para eliminar", "Datos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
