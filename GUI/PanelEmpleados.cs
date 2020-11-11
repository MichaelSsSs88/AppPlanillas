using AppPlanillas.GUI;
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
        public PanelEmpleados(int pestaña)
        {
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.dgvInsertar.DataSource = new EmpleadoDAL().ObtenerEmpleados();
            this.CargarTabla(pestaña,"","");
            if (this.comboBox3.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
            }
        }

        private void CargarTabla(int pestaña, string filtro, string dato)
        {
           /* if (this.cmbEditarUsuario.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
                this.LimpiarEditar();
            }
            if (this.cmbEliminarUsuario.SelectedIndex < 0)
            {
                this.panelFiltroEliminar.Visible = false;
                this.LimpiarEliminar();
            }*/

            if (pestaña == 0)
            {
                this.dgvInsertar.DataSource = new EmpleadoDAL().ObtenerEmpleados(); //new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 1)
            {
                this.dgvEditar.DataSource = new EmpleadoDAL().ObtenerEmpleados();//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 2)
            {
                this.dgvEliminar.DataSource = new EmpleadoDAL().ObtenerEmpleados();//new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }

        }

        public void Clic(object emisor, int pestaña, int panel)
        {
            if (panel == 1)
            {
                PanelBusqueda entrada = (PanelBusqueda)emisor;
                if (pestaña == 1)
                {
                    this.txtInsetarPuesto.Text = entrada.idDepartamento.ToString();
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

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (this.comboBox3.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
            }*/
            if (this.comboBox3.SelectedIndex >= 0)
            {
                this.panelFiltro.Visible = true;
                if (this.comboBox3.SelectedIndex == 1)
                {
                    this.lblValorABuscar.Text = "Digiten el numero de cédula: ";
                }
                else
                {
                    this.lblValorABuscar.Text = "Digite el nombre: ";
                }

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

        private void button4_Click(object sender, EventArgs e)
        {
            new EmpleadoDAL().AgregarDepartamento(new EmpleadoENT(Int32.Parse(this.txtInsertarCedula.Text), this.txtInsertarNombre.Text, this.txtInsertarApellido1.Text, this.txtInsertarApellido2.Text, dtpInsertarNacimiento.Value, Int32.Parse(this.txtInsetarPuesto.Text), this.conv_photo(), Double.Parse(this.txtInsertarSalarioHora.Text), DateTime.Now, "Pedro", DateTime.Now, "Pedro", this.ckbInsertarActivo.Checked));
            this.CargarTabla(0, "", "");
        }
    }

    
}
