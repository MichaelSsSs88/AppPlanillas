using AppPlanillas.DAL;
using AppPlanillas.ENT;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppPlanillas.GUI
{
    public partial class PanelUsuario : Form
    {
        private List<System.Windows.Forms.TabPage> objColPages = null;
        private bool[] arrBoolPagesVisible;
        private UsuarioENT UsuarioENT;
        public PanelUsuario(int pestaña, UsuarioENT UsuarioENT)
        {
            this.UsuarioENT = UsuarioENT;
            InitializeComponent();
            this.HideTab(0);
            this.HideTab(1);
            this.HideTab(2);
            this.ShowTab(pestaña);
            this.CargarTabla(pestaña, "Todos","");
        }

        private void InitControl()
        {
            if (objColPages == null)
            { // Inicializa la colección de páginas y elementos visibles
                objColPages = new List<System.Windows.Forms.TabPage>();
                arrBoolPagesVisible = new bool[this.tabUsuarios.TabPages.Count];
                // Añade las páginas de la ficha a la colección e indica que son visibles
                for (int intIndex = 0; intIndex < this.tabUsuarios.TabPages.Count; intIndex++)
                { // Añade la página
                    objColPages.Add(this.tabUsuarios.TabPages[intIndex]);
                    // Indica que es visible
                    arrBoolPagesVisible[intIndex] = true;
                }
                this.tabInsertUser.Parent = null;
                this.tabEditUser.Parent = null;
            }

        }

        private void CargarTabla(int pestaña, string filtro, string dato)
        {
            if (this.cmbEditarUsuario.SelectedIndex < 0)
            {
                this.panelFiltro.Visible = false;
                this.LimpiarEditar();
            }
            if (this.cmbEliminarUsuario.SelectedIndex < 0)
            {
                this.panelFiltroEliminar.Visible = false;
                this.LimpiarEliminar();
            }

            if (pestaña == 0)
            {
                this.dgvInsertar.DataSource = new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 1)
            {
                this.dgvEditar.DataSource = new UsuarioDAL().ObtenerUsuarios(filtro, dato);
            }
            if (pestaña == 2)
            {
                this.dgvEliminar.DataSource = new UsuarioDAL().ObtenerUsuarios(filtro, dato);
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
            this.tabUsuarios.TabPages.Clear();
            // Añade únicamente las fichas visibles
            for (int intIndex = 0; intIndex < objColPages.Count; intIndex++)
                if (arrBoolPagesVisible[intIndex])
                    this.tabUsuarios.TabPages.Add(objColPages[intIndex]);
        }

        private Boolean email_bien_escrito(String email)
        {
            String expresion;
            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (email_bien_escrito(this.txtIngresarCorreo.Text))
            {
                
                    if (this.txtInsertarNombre.Text.Trim() != "")
                    {
                        if (this.cmbInsertarUsuario.SelectedIndex >= 0)
                        {
                            if (this.txtIngresarContraseña.Text.Trim() != "" && (this.txtIngresarContraseña.Text == this.txtIngresarContraseña2.Text))
                            {
                                try
                                {
                                    new UsuarioDAL().AgregarUsuario(new UsuarioENT(-1, this.txtInsertarNombre.Text, this.txtIngresarCorreo.Text, this.cmbInsertarUsuario.SelectedItem.ToString(), this.txtIngresarContraseña.Text, DateTime.Now, this.UsuarioENT.Nombre, DateTime.Now, this.UsuarioENT.Nombre, this.ckbInsertarUsuario.Checked));
                                    MessageBox.Show("Usuario ingresado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.CargarTabla(0, "Todos", "");
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("¡Ha ocurrido un error al insertar, correo dublicado: " + ex.Message + "!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Las contraseñas no coinciden", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                        }
                        else
                        {
                            MessageBox.Show("Debe de seleccionar el tipo de usuario", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Debe de insertar el nombre completo", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                
                
            }
            else
            {
                MessageBox.Show("¡Formato del correo invalido", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }
        private void LimpiarEditar()
        {
            this.txtEditarCedula.Text = "";
            this.txtEditarNombre.Text = "";
            this.txtEditarCorreo.Text = "";
            this.txtEditarContraseña.Text = "";
            this.txtConfirmarContraseña.Text = "";
            this.cmbEditarUser.SelectedIndex = -1;
            this.ckbInsertarUsuario.Checked = false;
          
        }

        private void LimpiarEliminar()
        {
            this.txtEliminarCedula.Text = "";
            this.txtEliminarNombre.Text = "";
            this.txtEliminarCorreo.Text = "";
            this.txtEliminarContraseña.Text = "";
            this.cmbEliminarUser.SelectedIndex = -1;
            this.ckbEliminarActivo.Checked = false;

        }


        private void cmbEditarUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.cmbEditarUsuario.SelectedIndex == 0)
            {
                this.CargarTabla(1, "Todos","");
                this.panelFiltro.Visible = false;
            }
            if (this.cmbEditarUsuario.SelectedIndex == 1)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el nombre del usuario: ";
            }
            if (this.cmbEditarUsuario.SelectedIndex == 2)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el correo del usuario: ";
            }
            if (this.cmbEditarUsuario.SelectedIndex == 3)
            {
                this.panelFiltro.Visible = true;
                this.lblValorABuscar.Text = "Digite el tipo de usuario: ";
            }

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtEditarBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.txtEditarBusqueda.Text == "")
            {
                this.CargarTabla(1, "Todos", "");
            }
            else
            {
                this.CargarTabla(1, this.cmbEditarUsuario.SelectedItem.ToString(), this.txtEditarBusqueda.Text);
            }
        }

        private void dgvEditar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEditar.CurrentRow.Index;
            this.txtEditarCedula.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn1"].Value.ToString();
            this.txtEditarNombre.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn2"].Value.ToString();
            this.txtEditarCorreo.Text= this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn3"].Value.ToString();
           // this.txtEditarContraseña.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
           // this.txtConfirmarContraseña.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            this.cmbEditarUser.SelectedItem= this.dgvEditar.Rows[fila].Cells["Tipo"].Value.ToString();
            this.ckbEditarActivo.Checked = Boolean.Parse(this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn16"].Value.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (email_bien_escrito(this.txtEditarCorreo.Text))
            {

                if (this.txtEditarNombre.Text.Trim() != "")
                {
                    if (this.cmbEditarUser.SelectedIndex >= 0)
                    {
                        if ((this.txtEditarContraseña.Text == "" && this.txtConfirmarContraseña.Text == "") || (this.txtEditarContraseña.Text == this.txtConfirmarContraseña.Text))
                        {
                            try
                            {
                                new UsuarioDAL().ActualizarUsuario(new UsuarioENT(Int32.Parse(this.txtEditarCedula.Text), this.txtEditarNombre.Text, this.txtEditarCorreo.Text, this.cmbEditarUser.SelectedItem.ToString(), this.txtEditarContraseña.Text, DateTime.Now, this.UsuarioENT.Nombre, DateTime.Now, this.UsuarioENT.Nombre, this.ckbEditarActivo.Checked));
                                this.CargarTabla(1, "Todos", "");
                                MessageBox.Show("El usuario fue actualizado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.cmbEditarUsuario.SelectedIndex = -1;
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("¡Ha ocurrido un error al actulizar, correo dublicado: " + ex.Message + "!", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Las contraseñas no coinciden", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Debe de seleccionar el tipo de usuario", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Debe de insertar el nombre completo", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            else
            {
                MessageBox.Show("¡Formato del correo invalido", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        
        }

        private void cmbEliminarUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LimpiarEliminar();
            if (this.cmbEliminarUsuario.SelectedIndex == 0)
            {
                this.CargarTabla(1, "Todos", "");
                this.panelFiltroEliminar.Visible = false;
            }
            if (this.cmbEliminarUsuario.SelectedIndex == 1)
            {
                this.panelFiltroEliminar.Visible = true;
                this.lblBuscador.Text = "Digite el nombre del usuario: ";
            }
            if (this.cmbEliminarUsuario.SelectedIndex == 2)
            {
                this.panelFiltroEliminar.Visible = true;
                this.lblBuscador.Text = "Digite el correo del usuario: ";
            }
            if (this.cmbEliminarUsuario.SelectedIndex == 3)
            {
                this.panelFiltroEliminar.Visible = true;
                this.lblBuscador.Text = "Digite el tipo de usuario: ";
            }

        }

        private void txtEliminarBusqueda_TextChanged(object sender, EventArgs e)
        {
            this.LimpiarEditar();
            if (this.txtEditarBusqueda.Text == "")
            {
                this.CargarTabla(2, "Todos", "");
            }
            else
            {
                this.CargarTabla(2, this.cmbEliminarUsuario.SelectedItem.ToString(), this.txtEliminarBusqueda.Text);
            }

        }

        private void dgvEliminar_MouseClick(object sender, MouseEventArgs e)
        {
            int fila = this.dgvEliminar.CurrentRow.Index;
            this.txtEliminarCedula.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn7"].Value.ToString();
            this.txtEliminarNombre.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn8"].Value.ToString();
            this.txtEliminarCorreo.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn9"].Value.ToString();
            this.txtEliminarContraseña.Text = this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn10"].Value.ToString();
           // this.txtConfirmarContraseña.Text = this.dgvEditar.Rows[fila].Cells["dataGridViewTextBoxColumn4"].Value.ToString();
            this.cmbEliminarUser.SelectedItem = this.dgvEliminar.Rows[fila].Cells["TipoEliminar"].Value.ToString();
            this.ckbEliminarActivo.Checked = Boolean.Parse(this.dgvEliminar.Rows[fila].Cells["dataGridViewTextBoxColumn19"].Value.ToString());

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.txtEliminarCedula.Text != "")
            {
                new UsuarioDAL().EliminarUsuario(Int32.Parse(this.txtEliminarCedula.Text));
                this.txtEliminarBusqueda.Text = "";
                this.cmbEliminarUsuario.SelectedIndex = -1;
                MessageBox.Show("El usuario fue eliminado correctamente", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.LimpiarEliminar();
                this.CargarTabla(2, "Todos", "");
            }
            else
            {
                MessageBox.Show("Debe de seleccionar el usuario a eliminar", "Usuarios", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GenerarCSV generarCSV = new GenerarCSV(this.dgvInsertar);
            generarCSV.ExportarDatos(this.dgvInsertar);
        }
    }
}
