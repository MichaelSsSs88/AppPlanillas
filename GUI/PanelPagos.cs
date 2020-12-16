using AppPlanillas.DAL;
using AppPlanillas.DLL;
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
    public partial class PanelPagos : Form
    {
        List<UnificacionENT> Unificaciones;
        public PanelPagos()
        {
            
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<int> cedulas = new List<int>();
            this.Unificaciones = new UnificacionDAL().ObtenerUnificacion(this.dtpInsertarFechaEntrada.Value.ToString("dd/MM/yyyy"), this.dtpInsertarFechaSalida.Value.ToString("dd/MM/yyyy"), 0, 0, "aprobado");

            foreach (UnificacionENT unificacion in Unificaciones)
            {
                cedulas.Add(unificacion.idEmpleado);
            }
            new Unificacion().Pagos(cedulas.Distinct(), this.dtpInsertarFechaEntrada.Value, this.dtpInsertarFechaSalida.Value, this.txtDescripcion.Text, Unificaciones,  "creador", "modificaa");
        }
    }

}
