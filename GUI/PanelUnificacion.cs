using AppPlanillas.DAL;
using AppPlanillas.DLL;
using AppPlanillas.ENT;
using DAL;
using ENT;
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
        public PanelUnificacion()
        {
            InitializeComponent();
            this.OrdenaLink(false);
            this.ckbFecha_Click(null, null);
            this.ckbFechaFin_CheckedChanged(null, null);
            this.cmbEstado.SelectedIndex = 0;

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
                this.UnificacionENT = new UnificacionENT(Int32.Parse(entrada.Unificacion.ElementAt(0)), DateTime.Parse(entrada.Unificacion.ElementAt(3)), DateTime.Parse(entrada.Unificacion.ElementAt(4)), Double.Parse(entrada.Unificacion.ElementAt(5)), Double.Parse(entrada.Unificacion.ElementAt(6)), Double.Parse(entrada.Unificacion.ElementAt(7)), Double.Parse(entrada.Unificacion.ElementAt(8)), Double.Parse(entrada.Unificacion.ElementAt(9)), Double.Parse(entrada.Unificacion.ElementAt(10)), Double.Parse(entrada.Unificacion.ElementAt(11)), Int32.Parse(entrada.Unificacion.ElementAt(1)), entrada.Unificacion.ElementAt(12), DateTime.Now, "", DateTime.Now, "pedro", Int32.Parse(entrada.Unificacion.ElementAt(13)));
                this.txtEditarUnificacion.Text = entrada.Unificacion.ElementAt(0);
                this.txtEditarIdEmpleado.Text= entrada.Unificacion.ElementAt(1);
                this.txtEditarNombre.Text= entrada.Unificacion.ElementAt(2);
                this.txtEditarInicio.Text = DateTime.Parse(entrada.Unificacion.ElementAt(3)).ToString("dd/MM/yyyy");//.ToString("dd/MM/yyyy");
                this.txtEditarFin.Text = DateTime.Parse(entrada.Unificacion.ElementAt(4)).ToString("dd/MM/yyyy");
                this.txtEditarHora.Text= entrada.Unificacion.ElementAt(5);
                this.txtEditarExtra.Text= entrada.Unificacion.ElementAt(6);
                this.txtEditarFeriado.Text= entrada.Unificacion.ElementAt(7);
                this.txtEditarEstado.Text= entrada.Unificacion.ElementAt(8);
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

            List<DeduccionENT> Deducciones = new DeduccionDAL().ObtenerDeducciones(-1,"");
            List<HorarioENT> Horarios = new HorarioDAL().ObtenerHorarios(-1, "");
            List<Dia_feriadoENT> Feriados = new Dia_feriadoDAL().ObtenerFeriados("Todos", "");
            List<int> cedulas= new List<int>();
            List<UnificacionENT> unificaciones = new List<UnificacionENT>();

            foreach (MarcaENT marca in marcas)
            {
                cedulas.Add(marca.IdEmpleado);
            }

            this.dgvInsertar.DataSource=new Unificacion().Unificacione(cedulas.Distinct(), this.dtpInsertarFechaEntrada.Value, this.dtpInsertarFechaSalida.Value, marcas, "creador", "modificaa");
            IEnumerable<int> DiferentesEmpleados = cedulas.Distinct();

           /* foreach(int cedula in DiferentesEmpleados)
            {
                double horas = 0;
                double horas_extras = 0;
                double horas_feriados = 0;
                double salario_horas = 0;
                double salario_horas_extras = 0;
                double salario_horas_feriados = 0;
                double total_deduccion = 0;

                foreach (MarcaENT marca in marcas)
                {
                    

                    if (marca.IdEmpleado== cedula)
                    {
                        foreach(HorarioENT horario in Horarios)
                        {
                            if (this.DiaSemana(marca.marcar_inicio.Value.DayOfWeek).CompareTo(horario.Dia) == 0)
                            {
                                TimeSpan Horas1 = TimeSpan.Parse(marca.marcar_final.Value.ToString("HH:mm"));
                                TimeSpan Horas2= TimeSpan.Parse(marca.marcar_inicio.Value.ToString("HH:mm"));
                                int Horas = Horas1.Hours - Horas2.Hours;
                                Console.WriteLine(Horas1 + " "+ Horas2 +  " Horas: " + Horas);
                                if (Horas >= horario.Horas_Ordinarias)
                                {
                                    horas += horario.Horas_Ordinarias;
                                    horas_extras += (Horas - horario.Horas_Ordinarias);
                                }
                                else
                                {
                                    horas += Horas;
                                }

                                foreach(Dia_feriadoENT feriado in Feriados)
                                {
                                    if(marca.marcar_inicio.Value.Month == feriado.Mes && marca.marcar_inicio.Value.Day == feriado.Dia)
                                    {
                                        horas_feriados += Horas;
                                    }
                                }

                                break;
                            }
                        }

                        
                    }
                }

                double SalarioHora = new EmpleadoDAL().SalarioEmpleado(cedula);
                foreach (DeduccionENT rebajar in Deducciones)
                {
                    if (rebajar.getSistema.CompareTo("Porcentaje")==0)
                    {
                        if(rebajar.getIdEmpleado==0)
                            total_deduccion += ((horas * SalarioHora) + (horas_extras * (SalarioHora * 1.5)) + horas_feriados * SalarioHora)*(rebajar.getValor/100);
                        else
                        {
                            if (rebajar.getIdEmpleado == cedula)
                            {
                                total_deduccion += ((horas * SalarioHora) + (horas_extras * (SalarioHora * 1.5)) + horas_feriados * SalarioHora) * (rebajar.getValor/100);
                            }
                        }
                    }
                    else
                    {
                        if (rebajar.getIdEmpleado == 0)
                            total_deduccion += rebajar.getValor;
                        else
                        {
                            if (rebajar.getIdEmpleado == cedula)
                            {
                                total_deduccion += rebajar.getValor;
                            }
                        }
                    }
                }
                
                unificaciones.Add(new UnificacionENT(1, this.dtpInsertarFechaEntrada.Value, this.dtpInsertarFechaSalida.Value, horas, horas_extras, horas_feriados, (horas * SalarioHora), (horas_extras * (SalarioHora * 1.5)), horas_feriados * SalarioHora, total_deduccion, cedula, "generado", DateTime.Now, "prueba", DateTime.Now, "yoOOOO", 0));

            }*/

            //this.dgvInsertar.DataSource = unificaciones;


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

        }

        private void dgvMarca_MouseClick(object sender, MouseEventArgs e)
        {
            this.fila = this.dgvMarca.CurrentRow.Index;
            int id= Int32.Parse(this.dgvMarca.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString());
        }
    }
}
