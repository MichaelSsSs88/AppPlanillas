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
    public partial class PanelVistaUnificacionPorPago : Form
    {
        public PanelVistaUnificacionPorPago(List<UnificacionENT> unificacionENTs)
        {
            InitializeComponent();
            this.dgvConsultas.DataSource = unificacionENTs;
        }
    }
}
