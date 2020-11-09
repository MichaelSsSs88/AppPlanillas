namespace AppPlanillas.GUI
{
    partial class PanelBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelBusqueda));
            this.tabEditDepartment = new System.Windows.Forms.TabPage();
            this.gbxActualizar = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtEditarCodigo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEditarDescripcion = new System.Windows.Forms.TextBox();
            this.ckbEditarActivo = new System.Windows.Forms.CheckBox();
            this.gbxFiltroActualizar = new System.Windows.Forms.GroupBox();
            this.lblTipoBusquedaActualizar = new System.Windows.Forms.Label();
            this.cmbTipoBusquedaActualizar = new System.Windows.Forms.ComboBox();
            this.pnlFiltroActualizar = new System.Windows.Forms.Panel();
            this.lblValorABuscar = new System.Windows.Forms.Label();
            this.txtBuscarActualizar = new System.Windows.Forms.TextBox();
            this.lblSelecionarActualizar = new System.Windows.Forms.Label();
            this.grdActualizar = new System.Windows.Forms.DataGridView();
            this.colActiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDepartamentos = new System.Windows.Forms.TabControl();
            this.btnGuardarActualizar = new System.Windows.Forms.Button();
            this.tabEditDepartment.SuspendLayout();
            this.gbxActualizar.SuspendLayout();
            this.gbxFiltroActualizar.SuspendLayout();
            this.pnlFiltroActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActualizar)).BeginInit();
            this.tabDepartamentos.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabEditDepartment
            // 
            this.tabEditDepartment.Controls.Add(this.gbxFiltroActualizar);
            this.tabEditDepartment.Controls.Add(this.gbxActualizar);
            this.tabEditDepartment.Location = new System.Drawing.Point(4, 25);
            this.tabEditDepartment.Name = "tabEditDepartment";
            this.tabEditDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditDepartment.Size = new System.Drawing.Size(1026, 640);
            this.tabEditDepartment.TabIndex = 1;
            this.tabEditDepartment.Text = "Editar Departamento";
            this.tabEditDepartment.UseVisualStyleBackColor = true;
            // 
            // gbxActualizar
            // 
            this.gbxActualizar.Controls.Add(this.btnGuardarActualizar);
            this.gbxActualizar.Controls.Add(this.ckbEditarActivo);
            this.gbxActualizar.Controls.Add(this.txtEditarDescripcion);
            this.gbxActualizar.Controls.Add(this.label11);
            this.gbxActualizar.Controls.Add(this.txtEditarCodigo);
            this.gbxActualizar.Controls.Add(this.label12);
            this.gbxActualizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbxActualizar.Location = new System.Drawing.Point(514, 3);
            this.gbxActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.gbxActualizar.Name = "gbxActualizar";
            this.gbxActualizar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 4);
            this.gbxActualizar.Size = new System.Drawing.Size(509, 634);
            this.gbxActualizar.TabIndex = 4;
            this.gbxActualizar.TabStop = false;
            this.gbxActualizar.Text = "Departamento seleccionado:";
            // 
            // label12
            // 
            this.label12.Dock = System.Windows.Forms.DockStyle.Top;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label12.Location = new System.Drawing.Point(10, 26);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(489, 28);
            this.label12.TabIndex = 0;
            this.label12.Text = "Código del departamento:";
            // 
            // txtEditarCodigo
            // 
            this.txtEditarCodigo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEditarCodigo.Location = new System.Drawing.Point(10, 54);
            this.txtEditarCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.txtEditarCodigo.Name = "txtEditarCodigo";
            this.txtEditarCodigo.ReadOnly = true;
            this.txtEditarCodigo.Size = new System.Drawing.Size(489, 23);
            this.txtEditarCodigo.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.Dock = System.Windows.Forms.DockStyle.Top;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label11.Location = new System.Drawing.Point(10, 77);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label11.Size = new System.Drawing.Size(489, 30);
            this.label11.TabIndex = 16;
            this.label11.Text = "Descripción del departamento:";
            // 
            // txtEditarDescripcion
            // 
            this.txtEditarDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtEditarDescripcion.Location = new System.Drawing.Point(10, 107);
            this.txtEditarDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtEditarDescripcion.Name = "txtEditarDescripcion";
            this.txtEditarDescripcion.ReadOnly = true;
            this.txtEditarDescripcion.Size = new System.Drawing.Size(489, 23);
            this.txtEditarDescripcion.TabIndex = 17;
            // 
            // ckbEditarActivo
            // 
            this.ckbEditarActivo.AutoSize = true;
            this.ckbEditarActivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckbEditarActivo.Location = new System.Drawing.Point(10, 130);
            this.ckbEditarActivo.Name = "ckbEditarActivo";
            this.ckbEditarActivo.Size = new System.Drawing.Size(489, 21);
            this.ckbEditarActivo.TabIndex = 37;
            this.ckbEditarActivo.Text = "Activo";
            this.ckbEditarActivo.UseVisualStyleBackColor = true;
            // 
            // gbxFiltroActualizar
            // 
            this.gbxFiltroActualizar.Controls.Add(this.grdActualizar);
            this.gbxFiltroActualizar.Controls.Add(this.lblSelecionarActualizar);
            this.gbxFiltroActualizar.Controls.Add(this.pnlFiltroActualizar);
            this.gbxFiltroActualizar.Controls.Add(this.cmbTipoBusquedaActualizar);
            this.gbxFiltroActualizar.Controls.Add(this.lblTipoBusquedaActualizar);
            this.gbxFiltroActualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbxFiltroActualizar.Location = new System.Drawing.Point(3, 3);
            this.gbxFiltroActualizar.Name = "gbxFiltroActualizar";
            this.gbxFiltroActualizar.Padding = new System.Windows.Forms.Padding(10);
            this.gbxFiltroActualizar.Size = new System.Drawing.Size(511, 634);
            this.gbxFiltroActualizar.TabIndex = 5;
            this.gbxFiltroActualizar.TabStop = false;
            this.gbxFiltroActualizar.Text = "Filtrar Departamento:";
            // 
            // lblTipoBusquedaActualizar
            // 
            this.lblTipoBusquedaActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTipoBusquedaActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblTipoBusquedaActualizar.Location = new System.Drawing.Point(10, 26);
            this.lblTipoBusquedaActualizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoBusquedaActualizar.Name = "lblTipoBusquedaActualizar";
            this.lblTipoBusquedaActualizar.Size = new System.Drawing.Size(491, 28);
            this.lblTipoBusquedaActualizar.TabIndex = 1;
            this.lblTipoBusquedaActualizar.Text = "Seleccione el tipo de busqueda:";
            // 
            // cmbTipoBusquedaActualizar
            // 
            this.cmbTipoBusquedaActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTipoBusquedaActualizar.FormattingEnabled = true;
            this.cmbTipoBusquedaActualizar.Items.AddRange(new object[] {
            "Todos",
            "Codigo",
            "Descripción"});
            this.cmbTipoBusquedaActualizar.Location = new System.Drawing.Point(10, 54);
            this.cmbTipoBusquedaActualizar.Name = "cmbTipoBusquedaActualizar";
            this.cmbTipoBusquedaActualizar.Size = new System.Drawing.Size(491, 24);
            this.cmbTipoBusquedaActualizar.TabIndex = 2;
            this.cmbTipoBusquedaActualizar.SelectedIndexChanged += new System.EventHandler(this.cmbTipoBusquedaActualizar_SelectedIndexChanged);
            // 
            // pnlFiltroActualizar
            // 
            this.pnlFiltroActualizar.Controls.Add(this.txtBuscarActualizar);
            this.pnlFiltroActualizar.Controls.Add(this.lblValorABuscar);
            this.pnlFiltroActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroActualizar.Location = new System.Drawing.Point(10, 78);
            this.pnlFiltroActualizar.Name = "pnlFiltroActualizar";
            this.pnlFiltroActualizar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlFiltroActualizar.Size = new System.Drawing.Size(491, 68);
            this.pnlFiltroActualizar.TabIndex = 3;
            // 
            // lblValorABuscar
            // 
            this.lblValorABuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblValorABuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblValorABuscar.Location = new System.Drawing.Point(0, 10);
            this.lblValorABuscar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblValorABuscar.Name = "lblValorABuscar";
            this.lblValorABuscar.Size = new System.Drawing.Size(491, 28);
            this.lblValorABuscar.TabIndex = 3;
            this.lblValorABuscar.Text = "Digite :";
            // 
            // txtBuscarActualizar
            // 
            this.txtBuscarActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarActualizar.Location = new System.Drawing.Point(0, 38);
            this.txtBuscarActualizar.Name = "txtBuscarActualizar";
            this.txtBuscarActualizar.Size = new System.Drawing.Size(491, 23);
            this.txtBuscarActualizar.TabIndex = 4;
            this.txtBuscarActualizar.TextChanged += new System.EventHandler(this.txtBuscarActualizar_TextChanged);
            // 
            // lblSelecionarActualizar
            // 
            this.lblSelecionarActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSelecionarActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSelecionarActualizar.Location = new System.Drawing.Point(10, 146);
            this.lblSelecionarActualizar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSelecionarActualizar.Name = "lblSelecionarActualizar";
            this.lblSelecionarActualizar.Size = new System.Drawing.Size(491, 28);
            this.lblSelecionarActualizar.TabIndex = 4;
            this.lblSelecionarActualizar.Text = "Seleccione el departamento a modificar::";
            // 
            // grdActualizar
            // 
            this.grdActualizar.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.grdActualizar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdActualizar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colId,
            this.colNombre,
            this.colCreador,
            this.colFechaCreacion,
            this.colModificador,
            this.colFechaModificacion,
            this.colActiv});
            this.grdActualizar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdActualizar.GridColor = System.Drawing.SystemColors.Control;
            this.grdActualizar.Location = new System.Drawing.Point(10, 174);
            this.grdActualizar.MultiSelect = false;
            this.grdActualizar.Name = "grdActualizar";
            this.grdActualizar.ReadOnly = true;
            this.grdActualizar.Size = new System.Drawing.Size(491, 450);
            this.grdActualizar.TabIndex = 5;
            this.grdActualizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.grdActualizar_MouseClick);
            // 
            // colActiv
            // 
            this.colActiv.DataPropertyName = "getActivo";
            this.colActiv.HeaderText = "Activo";
            this.colActiv.Name = "colActiv";
            this.colActiv.ReadOnly = true;
            // 
            // colFechaModificacion
            // 
            this.colFechaModificacion.DataPropertyName = "getFechaModificacion";
            this.colFechaModificacion.HeaderText = "Fecha modificación";
            this.colFechaModificacion.Name = "colFechaModificacion";
            this.colFechaModificacion.ReadOnly = true;
            // 
            // colModificador
            // 
            this.colModificador.DataPropertyName = "getModificador";
            this.colModificador.HeaderText = "Modificado por";
            this.colModificador.Name = "colModificador";
            this.colModificador.ReadOnly = true;
            // 
            // colFechaCreacion
            // 
            this.colFechaCreacion.DataPropertyName = "getFechaCreacion";
            this.colFechaCreacion.HeaderText = "Fecha creación";
            this.colFechaCreacion.Name = "colFechaCreacion";
            this.colFechaCreacion.ReadOnly = true;
            // 
            // colCreador
            // 
            this.colCreador.DataPropertyName = "getCreador";
            this.colCreador.HeaderText = "Creador";
            this.colCreador.Name = "colCreador";
            this.colCreador.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "getNombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colId
            // 
            this.colId.DataPropertyName = "getId";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // tabDepartamentos
            // 
            this.tabDepartamentos.Controls.Add(this.tabEditDepartment);
            this.tabDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabDepartamentos.Location = new System.Drawing.Point(0, 0);
            this.tabDepartamentos.Name = "tabDepartamentos";
            this.tabDepartamentos.SelectedIndex = 0;
            this.tabDepartamentos.Size = new System.Drawing.Size(1034, 669);
            this.tabDepartamentos.TabIndex = 1;
            // 
            // btnGuardarActualizar
            // 
            this.btnGuardarActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGuardarActualizar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardarActualizar.FlatAppearance.BorderSize = 0;
            this.btnGuardarActualizar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarActualizar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarActualizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarActualizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGuardarActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarActualizar.Image")));
            this.btnGuardarActualizar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarActualizar.Location = new System.Drawing.Point(10, 151);
            this.btnGuardarActualizar.Name = "btnGuardarActualizar";
            this.btnGuardarActualizar.Size = new System.Drawing.Size(489, 83);
            this.btnGuardarActualizar.TabIndex = 38;
            this.btnGuardarActualizar.Text = "Seleccionar Departamento";
            this.btnGuardarActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarActualizar.UseVisualStyleBackColor = true;
            this.btnGuardarActualizar.Click += new System.EventHandler(this.btnGuardarActualizar_Click);
            // 
            // PanelBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 669);
            this.Controls.Add(this.tabDepartamentos);
            this.Name = "PanelBusqueda";
            this.Text = "PanelBusqueda";
            this.tabEditDepartment.ResumeLayout(false);
            this.gbxActualizar.ResumeLayout(false);
            this.gbxActualizar.PerformLayout();
            this.gbxFiltroActualizar.ResumeLayout(false);
            this.pnlFiltroActualizar.ResumeLayout(false);
            this.pnlFiltroActualizar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActualizar)).EndInit();
            this.tabDepartamentos.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabEditDepartment;
        private System.Windows.Forms.GroupBox gbxFiltroActualizar;
        private System.Windows.Forms.DataGridView grdActualizar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActiv;
        private System.Windows.Forms.Label lblSelecionarActualizar;
        private System.Windows.Forms.Panel pnlFiltroActualizar;
        private System.Windows.Forms.TextBox txtBuscarActualizar;
        private System.Windows.Forms.Label lblValorABuscar;
        private System.Windows.Forms.ComboBox cmbTipoBusquedaActualizar;
        private System.Windows.Forms.Label lblTipoBusquedaActualizar;
        private System.Windows.Forms.GroupBox gbxActualizar;
        private System.Windows.Forms.CheckBox ckbEditarActivo;
        private System.Windows.Forms.TextBox txtEditarDescripcion;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtEditarCodigo;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TabControl tabDepartamentos;
        private System.Windows.Forms.Button btnGuardarActualizar;
    }
}