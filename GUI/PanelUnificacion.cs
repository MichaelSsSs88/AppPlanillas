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
    public partial class PanelUnificacion : Form
    {
        public PanelUnificacion()
        {
            InitializeComponent();
            this.OrdenaLink(false);
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
    }
}
