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
                        new PanelBusqueda(3,null,null,this).Visible=true;
            else
                        new PanelBusqueda(1, null, null, this).Visible = true;
        }

        private void linkEmpleado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PanelBusqueda(3, null, null, this).Visible = true;
        }

        private void linkDepartamento_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PanelBusqueda(1, null, null, this).Visible = true;
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
    }
}
