using AppPlanillas.ENT;
using AppPlanillas.GUI;
using DAL;
using ProyectoIIIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class PanelEmpleados : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private UsuarioENT UsuarioENT;
        public PanelEmpleados(int pestaña, UsuarioENT usuario)
        {
            this.UsuarioENT = usuario;
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.dgvInsertar.DataSource = new EmpleadoDAL().ObtenerEmpleados("Todos","");
            this.CargarTabla(pestaña,"Todos","");
            if (this.cmbEditarBusqueda.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
            }
        }

        private void CargarTabla(int pestaña, string filtro, string dato)
        {
           
            if (pestaña == 0)
            {
                Console.WriteLine("***************************");
                this.dgvInsertar.DataSource = new EmpleadoDAL().ObtenerEmpleados(filtro, dato); //new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 1)
            {
                this.dgvEditar.DataSource = new EmpleadoDAL().ObtenerEmpleados(filtro, dato);//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 2)
            {
                this.dgvEliminar.DataSource = new EmpleadoDAL().ObtenerEmpleados(filtro, dato);//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }

        }

        public void Clic(object emisor, int pestaña, int panel)
        {
            if (panel == 1)
            {
                PanelBusqueda entrada = (PanelBusqueda)emisor;
                if (pestaña == 2)
                {
                    this.txtInsetarPuesto.Text = entrada.idPuesto.ToString();
                    this.txtEditarPuesto.Text= entrada.idPuesto.ToString();
                }
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
                this.tabInsertEmployed.Parent = null;
                this.tabEditEmployed.Parent = null;
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


        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnEditarEmpleado_MouseHover(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void LimpiarEditar()
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

        private void LimpiarEliminar()
        {
            this.txtEliminarCedula.Text = "";
            this.txtEliminarNombre.Text = "";
            this.txtEliminarApellido1.Text = "";
            this.txtEliminarApellido2.Text = "";
            this.dtpEliminarNacimiento.Value = DateTime.Today;
            this.txtEliminarPuesto.Text = "";
            this.txtEliminarSalarioHora.Text = "";
            this.picEliminarImg.Image = null;
            this.ckbEliminarActivo.Checked = false;

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
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

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {
           /* if (this.comboBox3.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
                if (this.comboBox3.SelectedIndex == 0)
                {
                    this.lblValorABuscar.Text = "Digiten el numero de cédula: ";
                }
                else
                {
                    this.lblValorABuscar.Text = "Digite el nombre: ";
                }
                
            }*/
        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void PanelEmpleados_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                picImg.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private byte[] conv_photo()
        {
            byte[] photo_aray = null;
            if (picImg.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picImg.Image.Save(ms, ImageFormat.Jpeg);
                photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                //cmd.Parameters.AddWithValue("@photo", photo_aray);
            }
            return photo_aray;
        }

        private byte[] conv_photo_edit()
        {
            byte[] photo_aray = null;
            if (picEditarImg.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                picEditarImg.Image.Save(ms, ImageFormat.Jpeg);
                photo_aray = new byte[ms.Length];
                ms.Position = 0;
                ms.Read(photo_aray, 0, photo_aray.Length);
                //cmd.Parameters.AddWithValue("@photo", photo_aray);
            }
            return photo_aray;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.txtInsertarCedula.Text != "")
            {
                if (this.txtInsertarNombre.Text.Trim() != "")
                {
                    if (this.txtInsertarApellido1.Text.Trim() != "")
                    {
                        if (this.txtInsertarApellido2.Text.Trim() != "")
                        {
                            if (dtpInsertarNacimiento.Value.CompareTo(DateTime.Now) < 0)
                            {
                                if (this.txtInsetarPuesto.Text.Trim() != "")
                                {
                                    if (this.txtInsertarSalarioHora.Text.Trim() != "")
                                    {
                                        if (this.picImg.Image != null)
                                        {
                                            try
                                            {
                                                new EmpleadoDAL().AgregarEmpleado(new EmpleadoENT(Int32.Parse(this.txtInsertarCedula.Text), this.txtInsertarNombre.Text, this.txtInsertarApellido1.Text, this.txtInsertarApellido2.Text, dtpInsertarNacimiento.Value, Int32.Parse(this.txtInsetarPuesto.Text), this.conv_photo(), Double.Parse(this.txtInsertarSalarioHora.Text), DateTime.Now, this.UsuarioENT.Nombre, DateTime.Now, this.UsuarioENT.Nombre, this.ckbInsertarActivo.Checked));
                                                MessageBox.Show("El empleado fue ingresado correctamente", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                this.CargarTabla(0, "Todos", "");
                                                //this.CargarTabla(1, "Todos", "");

                                            }
                                            catch (Exception Ex)
                                            {
                                                Console.WriteLine(Ex.Message);
                                                if(Ex.Message.CompareTo("ERROR: 23505: llave duplicada viola restricción de unicidad «empleado_pkey»") == 0)
                                                {
                                                    MessageBox.Show("Ya existe un empleado con esa cédula", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }
                                                else
                                                {
                                                    MessageBox.Show("El empleado no se pudo guardar", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                                }

                                            }


                                        }
                                        else
                                        {
                                            MessageBox.Show("Debe de insertar la foto del empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        }

                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe de insertar el salario del empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe de seleccionar el puesto, del empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La fecha de nacimiento debe de ser menor de la fecha actual ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Debe de insertar el segundo apellido del empleado ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de insertar el primer apellido del empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Debe de insertar el nombre del empleado ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe de insertar la cedula del empleado ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tabDepartamentos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(2, null, this,null);
            panelBusqueda.ShowDialog();
        }

        private void txtInsetarPuesto_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtInsertarSalario_Click(object sender, EventArgs e)
        {

        }

        private void txtInsertarSalarioHora_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void picImg_Click(object sender, EventArgs e)
        {

        }

        private void ckbInsertarActivo_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregarFoto_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "jpeg|*.jpg|bmp|*.bmp|all files|*.*";
            DialogResult res = openFileDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                picEditarImg.Image = Image.FromFile(openFileDialog1.FileName);
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.txtEditarBusqueda.Text == "")
            {
                this.CargarTabla(1, "Todos", "");
            }
            else
            {
                this.CargarTabla(1, this.cmbEditarBusqueda.SelectedItem.ToString(), this.txtEditarBusqueda.Text);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if(this.txtEditarCedula.Text!="")
            {
                if (this.txtEditarNombre.Text.Trim() != "")
                {
                    if (this.txtEditarApellido1.Text.Trim() != "")
                    {
                        if (this.txtEditarApellido2.Text.Trim() != "")
                        {
                            if (dtpEditarFechaNacimiento.Value.CompareTo(DateTime.Now) < 0)
                            {
                                if (this.txtEditarPuesto.Text.Trim() != "")
                                {
                                    if (this.txtEditarSalarioHora.Text.Trim() != "")
                                    {
                                        new EmpleadoDAL().EditarEmpleado(new EmpleadoENT(Int32.Parse(this.txtEditarCedula.Text), this.txtEditarNombre.Text, this.txtEditarApellido1.Text, this.txtEditarApellido2.Text, dtpEditarFechaNacimiento.Value, Int32.Parse(this.txtEditarPuesto.Text), this.conv_photo_edit(), Double.Parse(this.txtEditarSalarioHora.Text), DateTime.Now, "", DateTime.Now, this.UsuarioENT.Nombre, this.ckbEditarActivo.Checked));
                                        MessageBox.Show("El empleado fue actualizado correctamente", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        this.LimpiarEditar();
                                        this.txtEditarBusqueda.Text = "";
                                        this.cmbEditarBusqueda.SelectedIndex = 0;
                                        this.CargarTabla(1, "Todos", "");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Debe de insertar el salario del empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Debe de seleccionar el puesto, del empleado", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("La fecha de nacimiento debe de ser menor de la fecha actual ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Debe de insertar el segundo apellido del empleado a modificar ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de insertar el primer apellido del empleado a modificar ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Debe de insertar el nombre del empleado a modificar ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Debe de seleccionar el empleado a modificar ", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            this.txtEliminarBusqueda.Text = "";
            if (this.cmbEliminarBusqueda.SelectedIndex >= 0)
            {
                this.panelEliminarFiltrar.Visible = true;
                if (this.cmbEliminarBusqueda.SelectedIndex == 1)
                {
                    this.lblBuscar.Text = "Digite el numero de cédula: ";
                }
                else
                {
                    this.lblBuscar.Text = "Digite el nombre completo: ";
                }

            }
            else
            {
                this.panelEliminarFiltrar.Visible = false;

            }
        }

        private void txtEliminarBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEliminar();
            if (this.txtEliminarBusqueda.Text == "")
            {
                this.CargarTabla(2, "Todos", "");
            }
            else
            {
                this.CargarTabla(2, this.cmbEliminarBusqueda.SelectedItem.ToString(), this.txtEliminarBusqueda.Text);
            }
        }

        private void dgvEliminar_DoubleClick(object sender, EventArgs e)
        {
            int fila = this.dgvEliminar.CurrentRow.Index;
            this.txtEliminarCedula.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            this.txtEliminarNombre.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            this.txtEliminarApellido1.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            this.txtEliminarApellido2.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
            this.dtpEliminarNacimiento.Value = DateTime.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn11"].Value.ToString()).Date;
            this.txtEliminarPuesto.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
            this.txtEliminarSalarioHora.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn20"].Value.ToString();
            this.picEliminarImg.Image = (Image)this.dgvEditar.Rows[fila].Cells["dataGridViewImageColumn2"].Value;


            this.ckbEditarActivo.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn26"].Value.ToString());

        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEliminar.CurrentRow.Index;
            this.txtEliminarCedula.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            this.txtEliminarNombre.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            this.txtEliminarApellido1.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            this.txtEliminarApellido2.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
            this.dtpEliminarNacimiento.Value = DateTime.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn11"].Value.ToString()).Date;
            this.txtEliminarPuesto.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn12"].Value.ToString();
            this.txtEliminarSalarioHora.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn20"].Value.ToString();
            this.picEliminarImg.Image = (Image)this.dgvEliminar.Rows[fila].Cells["dataGridViewImageColumn2"].Value;


            this.ckbEliminarActivo.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn26"].Value.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtEliminarCedula.Text != "")
            {
                try
                {
                    new EmpleadoDAL().EliminarEmpleado(Int32.Parse(this.txtEliminarCedula.Text));
                    MessageBox.Show("El empleado fue eliminado correctamente", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.CargarTabla(2, "Todos", "");

                }
                catch(Exception ex)
                {
                    MessageBox.Show("El empleado no se puede eliminar", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
            else
            {
                MessageBox.Show("No existe empleado para eliminar", "Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PanelBusqueda panelBusqueda = new PanelBusqueda(2, null, this, null);
            panelBusqueda.ShowDialog();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerarCSV generarCSV = new GenerarCSV(this.dgvInsertar);
            generarCSV.ExportarDatos(this.dgvInsertar);
        }
    }

    
}
