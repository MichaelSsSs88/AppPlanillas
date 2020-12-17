using AppPlanillas.DAL;
using AppPlanillas.DLL;
using AppPlanillas.ENT;
using DAL;
using ENT;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPlanillas.GUI
{
    public partial class PanelPagos : Form
    {
        List<UnificacionENT> Unificaciones;
        UsuarioENT usuarioENT;
        public PanelPagos(UsuarioENT usuarioENT)
        {
            this.usuarioENT = usuarioENT;
            InitializeComponent();
            this.ckbFecha_Click(null, null);
            this.ckbFechaFin_Click(null, null);
            this.PintarTabla(1,null, null);
        }

        private void PintarTabla(int ventana,DateTime? fecha_inicio, DateTime? fecha_fin)
        {
            if(ventana==1)
                this.dgvInsertar.DataSource = new PagoDAL().ObtenerPago(fecha_inicio, fecha_fin);
            if(ventana==2)
                this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(fecha_inicio, fecha_fin);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> cedulas = new List<int>();
            this.Unificaciones = new UnificacionDAL().ObtenerUnificacion(this.dtpInsertarFechaEntrada.Value.ToString("dd/MM/yyyy"), this.dtpInsertarFechaSalida.Value.ToString("dd/MM/yyyy"), 0, 0, "aprobado");
            
            foreach (UnificacionENT unificacion in Unificaciones)
            {
                cedulas.Add(unificacion.idEmpleado);
            }
            List<PagoENT> listaPagos= new Unificacion().Pagos(cedulas.Distinct(), this.dtpInsertarFechaEntrada.Value, this.dtpInsertarFechaSalida.Value, this.txtDescripcion.Text, Unificaciones,  this.usuarioENT.Nombre, this.usuarioENT.Nombre);

            if (listaPagos.Count > 0)
            {
                List<xmlENT> xmlLista = new List<xmlENT>();
                foreach(PagoENT pagoENT in listaPagos)
                {
                    List<UnificacionENT> unificacions = new UnificacionDAL().ObtenerUnificacion(pagoENT.idPago);
                    foreach(UnificacionENT unificacionENT in unificacions)
                    {
                        xmlENT xml = new xmlENT(unificacionENT.idEmpleado, unificacionENT.Nombre, pagoENT.total);
                        xmlLista.Add(xml);
                    }
                }
                //this.dgvXml.Visible = true;
                //this.dgvInsertar.DataSource = xmlLista;
                this.dgvXml.DataSource = xmlLista;
                Console.WriteLine(xmlLista.Count);
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "xml|";
                DialogResult res = saveFileDialog1.ShowDialog();
                if (res == DialogResult.OK)
                {
                    var dataSet = XML.GetDataSet(this.dgvXml);
                    dataSet.WriteXml(File.OpenWrite(saveFileDialog1.FileName));
                    //picImg.Image = Image.FromFile(openFileDialog1.FileName):
                }
            }
            else
            {

            }
           

        }

        private void txtDescripcion_TextChanged(object sender, EventArgs e)
        {

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
                    this.PintarTabla(2,null, this.dtpFechaFin.Value);
                else
                {

                    this.PintarTabla(2,null, null);

                }
            }
        }

        private void ckbFechaFin_Click(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked)
            {
                this.dtpFechaFin.Visible = true;
            }
            else
            {
                this.dtpFechaFin.Visible = false;
                if (this.ckbFecha.Checked)
                    this.PintarTabla(2,this.dtpFechaInicio.Value, null);
                else
                {

                    this.PintarTabla(2,null, null); ;

                }
            }
        }

        private void dtpFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            if (this.ckbFechaFin.Checked)
                this.PintarTabla(2,this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            else
                this.PintarTabla(2,this.dtpFechaInicio.Value, null);
        }

        private void dtpFechaFin_ValueChanged(object sender, EventArgs e)
        {

            if (this.ckbFecha.Checked)
                this.PintarTabla(2,this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            else
                this.PintarTabla(2,null,this.dtpFechaFin.Value);

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                this.txtEmpleado.Visible = false;
                this.linkEmpleado.Visible = false;
                
                this.label6.Visible = true;
                if (this.ckbFecha.Checked && this.ckbFechaFin.Checked)
                {
                    this.dgvConsultas.DataSource= new PagoDAL().ObtenerPago(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
                }
                else if (this.ckbFecha.Checked)
                {
                    this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(this.dtpFechaInicio.Value, null);
                }
                else if (this.ckbFechaFin.Checked)
                {
                    this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(null, this.dtpFechaFin.Value);
                }
                else
                {
                    this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(null, null);

                }
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            this.txtEmpleado.Visible = true;
            this.linkEmpleado.Visible = true;
            this.label6.Text = "Seleccione el pago a verificar: ";
            this.label6.Visible = false;

            if (this.ckbFecha.Checked && this.ckbFechaFin.Checked)
            {
                this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            }
            else if (this.ckbFecha.Checked)
            {
                this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(this.dtpFechaInicio.Value, null);
            }
            else if (this.ckbFechaFin.Checked)
            {
                this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(null, this.dtpFechaFin.Value);
            }
            else
            {
                this.dgvConsultas.DataSource = new PagoDAL().ObtenerPago(null, null);

            }
        }
        public void Clic(object emisor, int pestaña, int panel)
        {
            PanelBusqueda entrada = (PanelBusqueda)emisor;
            Console.WriteLine(pestaña);
            if (pestaña == 3)
            {

                this.txtEmpleado.Text = entrada.idEmpleado.ToString();

            }
        }

            private void linkEmpleado_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            new PanelBusqueda(3, null, null, this).ShowDialog();
        }

        private void txtEmpleado_TextChanged(object sender, EventArgs e)
        {
            List<PagoENT> ListaPagos = new List<PagoENT>();
            List<PagoENT> ListaPagosSalida = new List<PagoENT>();
            if (this.ckbFecha.Checked && this.ckbFechaFin.Checked)
            {
                ListaPagos= new PagoDAL().ObtenerPago(this.dtpFechaInicio.Value, this.dtpFechaFin.Value);
            }
            else if (this.ckbFecha.Checked)
            {
                ListaPagos = new PagoDAL().ObtenerPago(this.dtpFechaInicio.Value, null);
            }
            else if (this.ckbFechaFin.Checked)
            {
                ListaPagos = new PagoDAL().ObtenerPago(null, this.dtpFechaFin.Value);
            }
            else
            {
                ListaPagos = new PagoDAL().ObtenerPago(null, null);

            }
            
            foreach(PagoENT pagoENT in ListaPagos)
            {
                
                List<UnificacionENT> unificacions = new UnificacionDAL().ObtenerUnificacion(pagoENT.idPago);
                Console.WriteLine(unificacions.Count+ " "+ pagoENT.idPago + "I'm right 699895");
                foreach (UnificacionENT unificacion in unificacions)
                {
                    if (unificacion.idEmpleado == Int32.Parse(this.txtEmpleado.Text))
                    {
                        ListaPagosSalida.Add(pagoENT);
                        break;
                    }
                    else
                        break;
                }

            }
            this.dgvConsultas.DataSource = ListaPagosSalida;


        }

        private void dgvConsultas_Click(object sender, EventArgs e)
        {
            

            
            if (radioButton1.Checked)
            {
                int fila = this.dgvConsultas.CurrentRow.Index;
                int idPago = Int32.Parse(this.dgvConsultas.Rows[fila].Cells["dataGridViewTextBoxColumn12"].Value.ToString());
                List<UnificacionENT> unificacions = new UnificacionDAL().ObtenerUnificacion(idPago);
                new PanelVistaUnificacionPorPago(unificacions).ShowDialog();
            }
            if (radioButton3.Checked)
            {
                int fila = this.dgvConsultas.CurrentRow.Index;
                int idPago = Int32.Parse(this.dgvConsultas.Rows[fila].Cells["dataGridViewTextBoxColumn12"].Value.ToString());
                DialogResult salida= MessageBox.Show("Desea anular el pago", "Desea anular el pago", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                //Console.WriteLine(salida.ToString());
                if (salida.ToString() == "OK")
                {
                    new Unificacion().AnularPago(idPago, "xxxx");
                }
            }
            

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton3.Checked)
            {
                this.txtEmpleado.Visible = false;
                this.linkEmpleado.Visible = false;
                this.label6.Text = "Seleccione el pago a anular: ";
                this.label6.Visible = true;
            }

        }


        
    }

}
