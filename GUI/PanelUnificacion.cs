using AppPlanillas.DAL;
using AppPlanillas.DLL;
using AppPlanillas.ENT;
using DAL;
using ENT;
using GUI;
using ProyectoIIIC;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPlanillas.GUI
{
    public partial class PanelUnificacion : Form
    {
        int fila = -1;
        UnificacionENT UnificacionENT = null;
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private UsuarioENT UsuarioENT;
        public PanelUnificacion(int pestaña, UsuarioENT usuarioEnt)
        {
            this.UsuarioENT = usuarioEnt;
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            //this.HideTab(3);
            this.ShowTab(pestaña);
            this.pintarTabla();
            this.OrdenaLink(false);
            this.ckbFecha_Click(null, null);
            this.ckbFechaFin_CheckedChanged(null, null);
            this.cmbEstado.SelectedIndex = 0;

        }

        private void pintarTabla()
        {
            this.dgvInsertar.DataSource = new UnificacionDAL().ObtenerUnificacion("", "", 0, 0, "");
        }

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

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabUnificaciones.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabUnificaciones.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabUnificaciones.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabEditUnificacion.Parent = null;
               // this.tabFindUnificacion.Parent = null;
                this.tabInsertUnificacion.Parent = null;
            }

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
            this.tabUnificaciones.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabUnificaciones.TabPages.Add(objColPages[intIndex]);
        }

        private void OrdenaLink(Boolean estado)
        {
            if (this.checkedListBox1.CheckedItems.Count == 0)
            {
                this.txtInsertarBusqueda.Visible = false;
                this.linkBusqueda.Visible = false;
                this.txtInsertarBusqueda.Text = "0";
            }
            else
            {
                this.txtInsertarBusqueda.Visible = estado;
                this.linkBusqueda.Visible = estado;
                this.txtInsertarBusqueda.Text = "0";
            }
            
            
            
        }
        private void checkedListBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
        public void Clic(object emisor, int pestaña, int panel)
        {
            PanelBusqueda entrada = (PanelBusqueda)emisor;
            Console.WriteLine(pestaña);
            if (pestaña == 1 || pestaña == 3)
            {
                if (entrada.idDepartamento != 0)
                {
                    this.txtInsertarBusqueda.Text = entrada.idDepartamento.ToString();
                    this.txtDepartamento.Text = entrada.idDepartamento.ToString();
                }
                else
                {
                    this.txtInsertarBusqueda.Text = entrada.idEmpleado.ToString();
                    this.txtEmpleado.Text = entrada.idEmpleado.ToString();
                }
            }
            if (pestaña == 4)
            {
                if(entrada.Unificacion.ElementAt(13)=="")
                    this.UnificacionENT = new UnificacionENT(Int32.Parse(entrada.Unificacion.ElementAt(0)), DateTime.Parse(entrada.Unificacion.ElementAt(3)), DateTime.Parse(entrada.Unificacion.ElementAt(4)), Double.Parse(entrada.Unificacion.ElementAt(5)), Double.Parse(entrada.Unificacion.ElementAt(6)), Double.Parse(entrada.Unificacion.ElementAt(7)), Double.Parse(entrada.Unificacion.ElementAt(8)), Double.Parse(entrada.Unificacion.ElementAt(9)), Double.Parse(entrada.Unificacion.ElementAt(10)), Double.Parse(entrada.Unificacion.ElementAt(11)), Int32.Parse(entrada.Unificacion.ElementAt(1)), entrada.Unificacion.ElementAt(12), DateTime.Now, "", DateTime.Now, "pedro", null);
                else
                    this.UnificacionENT = new UnificacionENT(Int32.Parse(entrada.Unificacion.ElementAt(0)), DateTime.Parse(entrada.Unificacion.ElementAt(3)), DateTime.Parse(entrada.Unificacion.ElementAt(4)), Double.Parse(entrada.Unificacion.ElementAt(5)), Double.Parse(entrada.Unificacion.ElementAt(6)), Double.Parse(entrada.Unificacion.ElementAt(7)), Double.Parse(entrada.Unificacion.ElementAt(8)), Double.Parse(entrada.Unificacion.ElementAt(9)), Double.Parse(entrada.Unificacion.ElementAt(10)), Double.Parse(entrada.Unificacion.ElementAt(11)), Int32.Parse(entrada.Unificacion.ElementAt(1)), entrada.Unificacion.ElementAt(12), DateTime.Now, "", DateTime.Now, "pedro", Int32.Parse(entrada.Unificacion.ElementAt(13)));

                this.txtEditarUnificacion.Text = entrada.Unificacion.ElementAt(0);
                this.txtEditarUnificacion.Text = entrada.Unificacion.ElementAt(0);
                this.txtEditarIdEmpleado.Text= entrada.Unificacion.ElementAt(1);
                List<PuestoENT> puestoENT = new PuestoDAL().ObtenerPuestos("Código",(new EmpleadoDAL().ObtenerEmpleados("Cédula",entrada.Unificacion.ElementAt(1)).ElementAt(0).Id_Puesto).ToString());
                List<DepartamentoENT> departamentoENT = new DepartamentoDAL().ObtenerDepartamentos(puestoENT.ElementAt(0).Id_departamento.ToString(), "");
                this.txtEditarDepartamento.Text = departamentoENT.ElementAt(0).getNombre;
                this.txtEditarNombre.Text= entrada.Unificacion.ElementAt(2);
                this.txtEditarInicio.Text = DateTime.Parse(entrada.Unificacion.ElementAt(3)).ToString("dd/MM/yyyy");//.ToString("dd/MM/yyyy");
                this.txtEditarFin.Text = DateTime.Parse(entrada.Unificacion.ElementAt(4)).ToString("dd/MM/yyyy");
                this.txtEditarHora.Text= entrada.Unificacion.ElementAt(5);
                this.txtEditarExtra.Text= entrada.Unificacion.ElementAt(6);
                this.txtEditarFeriado.Text= entrada.Unificacion.ElementAt(7);
                this.txtEditarEstado.Text= entrada.Unificacion.ElementAt(12);
                this.txtEditarDeduccion.Text = this.UnificacionENT.total_deduccion.ToString();
                this.txtEditarSalario.Text = this.UnificacionENT.total_regular.ToString();
                this.txtEditarExtras.Text = this.UnificacionENT.total_extra.ToString();
                this.txtEditarDobles.Text = this.UnificacionENT.total_doble.ToString();
                //this.dgvMarca.DataSource = new MarcaDAL().ObtenerMarcas(DateTime.Parse(entrada.Unificacion.ElementAt(3)).ToString("dd/MM/yyyy"), DateTime.Parse(entrada.Unificacion.ElementAt(4)).ToString("dd/MM/yyyy"), "",Int32.Parse(entrada.Unificacion.ElementAt(1).ToString()),0,"aplicado");
                this.dgvMarca.DataSource = new MarcaDAL().ObtenerMarcasUnificadas(Int32.Parse(entrada.Unificacion.ElementAt(0)));
            }
                
            
        }

    

            private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.checkedListBox1.SelectedItem.ToString()== "Empleado")
            {
                this.checkedListBox1.SetItemChecked(1, false);
                this.linkBusqueda.Text = "Seleccione el empleado:";
                this.OrdenaLink(true);
                //this.checkedListBox1.SelectedIndex = 0;
            }
            else if(this.checkedListBox1.SelectedItem.ToString() == "Departamento")
            {
                this.checkedListBox1.SetItemChecked(0, false);
                this.linkBusqueda.Text = "Seleccione el departamento:";
                this.OrdenaLink(true);
            }
        }

        private void linkBusqueda_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if(this.linkBusqueda.Text== "Seleccione el empleado:")
                        new PanelBusqueda(3,null,null,this).ShowDialog();
            else
                        new PanelBusqueda(1, null, null, this).ShowDialog();
        }

        private void linkEmpleado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PanelBusqueda(3, null, null, this).ShowDialog();
        }

        private void linkDepartamento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PanelBusqueda(1, null, null, this).ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (this.checkedListBox1.SelectedItem != null)
            {
                List<MarcaENT> marcas = null;
                switch (this.checkedListBox1.SelectedItem.ToString())
                {

                    case "Empleado":
                        marcas = new MarcaDAL().ObtenerMarcas(this.dtpInsertarFechaEntrada.Value.ToString("dd/MM/yyyy"), this.dtpInsertarFechaSalida.Value.ToString("dd/MM/yyyy"), "", Int32.Parse(this.txtInsertarBusqueda.Text), 0, "generado");
                        break;
                    case "Departamento":
                        marcas = new MarcaDAL().ObtenerMarcas(this.dtpInsertarFechaEntrada.Value.ToString("dd/MM/yyyy"), this.dtpInsertarFechaSalida.Value.ToString("dd/MM/yyyy"), "", 0, Int32.Parse(this.txtInsertarBusqueda.Text), "generado");
                        break;
                }
                this.dgvInsertar.DataSource = marcas;

                List<DeduccionENT> Deducciones = new DeduccionDAL().ObtenerDeducciones(-1, "");
                List<HorarioENT> Horarios = new HorarioDAL().ObtenerHorarios(-1, "");
                List<Dia_feriadoENT> Feriados = new Dia_feriadoDAL().ObtenerFeriados("Todos", "");
                List<int> cedulas = new List<int>();
                List<UnificacionENT> unificaciones = new List<UnificacionENT>();

                foreach (MarcaENT marca in marcas)
                {
                    cedulas.Add(marca.IdEmpleado);
                }
                Console.WriteLine(cedulas.Count());
                //if(this.UnificacionENT!= null)
                    this.dgvInsertar.DataSource = new Unificacion().Unificacione(cedulas.Distinct(), this.dtpInsertarFechaEntrada.Value, this.dtpInsertarFechaSalida.Value, marcas, this.UsuarioENT.Nombre, this.UsuarioENT.Nombre);
                //else
                    MessageBox.Show("Unificacion agregada correctamente", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                IEnumerable<int> DiferentesEmpleados = cedulas.Distinct();
            }
            else
            {
                MessageBox.Show("Debe de seleccionar el tipo de unificacion a utilizar", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string DiaSemana(DayOfWeek dow) 
            { switch (dow) {
                case (DayOfWeek.Monday):
                    return "Lunes";
                case (DayOfWeek.Tuesday):
                    return "Martes";
                case (DayOfWeek.Wednesday):
                    return "Miercoles";
                case (DayOfWeek.Thursday):
                    return "Jueves";
                case (DayOfWeek.Friday):
                    return "Viernes";
                case (DayOfWeek.Saturday):
                    return "Sábado";
                case (DayOfWeek.Sunday): 
                    return "Domingo";
            }
            return "";
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
                    this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEstado.SelectedItem != null)
                        this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

                }
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

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
                    this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
                else
                {
                    if (this.cmbEstado.SelectedItem != null)
                        this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

                }
            }

            
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", "",  Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void txtDepartamento_TextChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked && this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFecha.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion(this.dtpFechaInicio.Value.ToString("dd/MM/yyyy"), "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else if (this.ckbFechaFin.Checked)
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", this.dtpFechaFin.Value.ToString("dd/MM/yyyy"), Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());
            else
                this.dgvConsultas.DataSource = new UnificacionDAL().ObtenerUnificacion("", "", Int32.Parse(this.txtEmpleado.Text), Int32.Parse(this.txtDepartamento.Text), this.cmbEstado.SelectedItem.ToString());

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PanelBusqueda(4, null, null, this).ShowDialog();
        }

        private void txtEditarUnificacion_TextChanged(object sender, EventArgs e)
        {
           /* int x = Int32.Parse(this.txtEditarUnificacion.Text);
            
            List<MarcaENT> ListaMarcas = new MarcaDAL().ObtenerMarcasUnificadas(x);
            Console.WriteLine(ListaMarcas.Count) ;
            //Console.WriteLine("Estoy Aqui", ListaMarcas.Count);
            //this.dgvMarca.DataSource = ListaMarcas;*/
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (this.txtEditarEstado.Text.CompareTo("generado") == 0 && this.txtEditarEstado.Text!="" && fila>-1)
            {
                int id = Int32.Parse(this.dgvMarca.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString());
                string fecha_inicio = DateTime.Parse(this.dgvMarca.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString()).ToString("dd/MM/yyyy");
                string fecha_fin = DateTime.Parse(this.dgvMarca.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString()).AddDays(1).ToString("dd/MM/yyyy");
                int cedula = Int32.Parse(this.dgvMarca.Rows[fila].Cells["dataGridViewTextBoxColumn5"].Value.ToString());
                List<MarcaENT> marca = new MarcaDAL().ObtenerMarcas(fecha_inicio, fecha_fin, "", cedula, 0, "aplicado");
                this.UnificacionENT = new Unificacion().EditarUnificacion(this.UnificacionENT, marca.ElementAt(0));
                this.txtEditarUnificacion.Text = this.UnificacionENT.idUnificacion.ToString();
                this.txtEditarIdEmpleado.Text = this.UnificacionENT.idEmpleado.ToString();
                this.txtEditarNombre.Text = this.UnificacionENT.Nombre;
                this.txtEditarInicio.Text = this.UnificacionENT.fecha_inicio.ToString("dd/MM/yyyy");//.ToString("dd/MM/yyyy");
                this.txtEditarFin.Text = this.UnificacionENT.fecha_fin.ToString("dd/MM/yyyy");
                this.txtEditarHora.Text = this.UnificacionENT.hora_regular.ToString();
                this.txtEditarExtra.Text = this.UnificacionENT.hora_extra.ToString();
                this.txtEditarFeriado.Text = this.UnificacionENT.hora_doble.ToString();
                this.txtEditarEstado.Text = this.UnificacionENT.estado;
                this.txtEditarDeduccion.Text = this.UnificacionENT.total_deduccion.ToString();
                this.txtEditarSalario.Text = this.UnificacionENT.total_regular.ToString();
                this.txtEditarExtras.Text = this.UnificacionENT.total_extra.ToString();
                this.txtEditarDobles.Text = this.UnificacionENT.total_doble.ToString();


                //this.dgvMarca.DataSource = new MarcaDAL().ObtenerMarcas(DateTime.Parse(entrada.Unificacion.ElementAt(3)).ToString("dd/MM/yyyy"), DateTime.Parse(entrada.Unificacion.ElementAt(4)).ToString("dd/MM/yyyy"), "",Int32.Parse(entrada.Unificacion.ElementAt(1).ToString()),0,"aplicado");
                this.dgvMarca.DataSource = new MarcaDAL().ObtenerMarcasUnificadas(Int32.Parse(this.txtEditarUnificacion.Text));
                MessageBox.Show("Marca liberadad satisfactoriamente", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Debe de seleccionar una unificacion en estado generado, para liberar marcas", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //Console.WriteLine(marca.ElementAt(0).idMarca + " " + marca.ElementAt(0).marcar_inicio + "  " + marca.ElementAt(0).creadoPor);
        }

        private void dgvMarca_MouseClick(object sender, MouseEventArgs e)
        {
            this.fila = this.dgvMarca.CurrentRow.Index;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(this.UnificacionENT!= null)
            {
                if (this.UnificacionENT.estado == "generado")
                {
                    if (this.UnificacionENT.hora_extra > 0 || this.UnificacionENT.hora_doble > 0)
                    {
                        Usuario usuario = new Usuario(this.UnificacionENT, true);
                        usuario.ShowDialog();
                        if (usuario.Update)
                        {
                            this.UnificacionENT.estado = "aprobado";
                            this.UnificacionENT.fechaModificacion = DateTime.Now;
                            this.UnificacionENT.modificadoPor = this.UsuarioENT.Nombre;
                           // MessageBox.Show("Unificacion aprobada, ya se encuentra lista para proceder con el pago", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            this.txtEditarEstado.Text = this.UnificacionENT.estado;
                        }
                    }
                    else
                    {
                        this.UnificacionENT.estado = "aprobado";
                        this.UnificacionENT.fechaModificacion = DateTime.Now;
                        this.UnificacionENT.modificadoPor = this.UsuarioENT.Nombre;
                        new UnificacionDAL().EditarUnificacionQuitarMarca(this.UnificacionENT);
                        MessageBox.Show("Unificacion aprobada, ya se encuentra lista para proceder con el pago", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.UnificacionENT.estado = "aprobado";
                        this.txtEditarEstado.Text = this.UnificacionENT.estado;
                    }
                }
                else
                    MessageBox.Show("Para aprobar unificaciones deben de estar en estado generado", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una unificacion para poder procesar", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (this.UnificacionENT != null)
            {
                if (this.UnificacionENT.estado == "aprobado")
                {
                    if (this.UnificacionENT.hora_extra > 0 || this.UnificacionENT.hora_doble > 0)
                    {
                        Usuario usuario = new Usuario(this.UnificacionENT, false);
                        usuario.ShowDialog();
                        if (usuario.Update)
                        {
                            this.UnificacionENT.estado = "generado";
                            this.UnificacionENT.fechaModificacion = DateTime.Now;
                            this.UnificacionENT.modificadoPor = this.UsuarioENT.Nombre;
                            this.txtEditarEstado.Text = this.UnificacionENT.estado;
                        }
                    }
                    else
                    {
                        this.UnificacionENT.estado = "generado";
                        this.UnificacionENT.fechaModificacion = DateTime.Now;
                        this.UnificacionENT.modificadoPor = this.UsuarioENT.Nombre;
                        new UnificacionDAL().EditarUnificacionQuitarMarca(this.UnificacionENT);
                        MessageBox.Show("Unificacion reversada, ya se encuentra lista para proceder con modificaciones", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.UnificacionENT.estado = "generado";
                        this.txtEditarEstado.Text = this.UnificacionENT.estado;
                    }
                }
                else
                    MessageBox.Show("Para reversar unificaciones deben de estar en estado generado", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Debe de seleccionar una unificacion para poder reversar", "Unificacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
