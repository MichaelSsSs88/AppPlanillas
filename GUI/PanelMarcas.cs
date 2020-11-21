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
    public partial class PanelMarcas : Form
    {
        public PanelMarcas()
        {
            InitializeComponent();
            this.ckbFecha_Click(null, null);
            this.ckbFechaFin_CheckedChanged(null, null);
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
            }


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
            }
        }
    }
}
