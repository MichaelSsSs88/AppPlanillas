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
            this.gbxFiltroActualizar = new System.Windows.Forms.GroupBox();
            this.grdActualizar = new System.Windows.Forms.DataGridView();
            this.colId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActiv = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSelecionarActualizar = new System.Windows.Forms.Label();
            this.pnlFiltroActualizar = new System.Windows.Forms.Panel();
            this.txtBuscarActualizar = new System.Windows.Forms.TextBox();
            this.lblValorABuscar = new System.Windows.Forms.Label();
            this.cmbTipoBusquedaActualizar = new System.Windows.Forms.ComboBox();
            this.lblTipoBusquedaActualizar = new System.Windows.Forms.Label();
            this.gbxActualizar = new System.Windows.Forms.GroupBox();
            this.btnGuardarActualizar = new System.Windows.Forms.Button();
            this.ckbEditarActivo = new System.Windows.Forms.CheckBox();
            this.txtEditarDescripcion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtEditarCodigo = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabDepartamentos = new System.Windows.Forms.TabControl();
            this.tabFindJob = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dgvEditar = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.txtBuscarEditar = new System.Windows.Forms.TextBox();
            this.lblPuestoABuscar = new System.Windows.Forms.Label();
            this.cmbBusquedaPuestos = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtCodigoPuesto = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtInsertarDescripcion = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.ckbActivo = new System.Windows.Forms.CheckBox();
            this.txtInsertarDepartamento = new System.Windows.Forms.TextBox();
            this.tabEditDepartment.SuspendLayout();
            this.gbxFiltroActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActualizar)).BeginInit();
            this.pnlFiltroActualizar.SuspendLayout();
            this.gbxActualizar.SuspendLayout();
            this.tabDepartamentos.SuspendLayout();
            this.tabFindJob.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditar)).BeginInit();
            this.panelFiltro.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.tabEditDepartment.Text = "Buscar Departamento";
            this.tabEditDepartment.UseVisualStyleBackColor = true;
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
            // colId
            // 
            this.colId.DataPropertyName = "getId";
            this.colId.HeaderText = "ID";
            this.colId.Name = "colId";
            this.colId.ReadOnly = true;
            // 
            // colNombre
            // 
            this.colNombre.DataPropertyName = "getNombre";
            this.colNombre.HeaderText = "Nombre";
            this.colNombre.Name = "colNombre";
            this.colNombre.ReadOnly = true;
            // 
            // colCreador
            // 
            this.colCreador.DataPropertyName = "getCreador";
            this.colCreador.HeaderText = "Creador";
            this.colCreador.Name = "colCreador";
            this.colCreador.ReadOnly = true;
            // 
            // colFechaCreacion
            // 
            this.colFechaCreacion.DataPropertyName = "getFechaCreacion";
            this.colFechaCreacion.HeaderText = "Fecha creación";
            this.colFechaCreacion.Name = "colFechaCreacion";
            this.colFechaCreacion.ReadOnly = true;
            // 
            // colModificador
            // 
            this.colModificador.DataPropertyName = "getModificador";
            this.colModificador.HeaderText = "Modificado por";
            this.colModificador.Name = "colModificador";
            this.colModificador.ReadOnly = true;
            // 
            // colFechaModificacion
            // 
            this.colFechaModificacion.DataPropertyName = "getFechaModificacion";
            this.colFechaModificacion.HeaderText = "Fecha modificación";
            this.colFechaModificacion.Name = "colFechaModificacion";
            this.colFechaModificacion.ReadOnly = true;
            // 
            // colActiv
            // 
            this.colActiv.DataPropertyName = "getActivo";
            this.colActiv.HeaderText = "Activo";
            this.colActiv.Name = "colActiv";
            this.colActiv.ReadOnly = true;
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
            // txtBuscarActualizar
            // 
            this.txtBuscarActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarActualizar.Location = new System.Drawing.Point(0, 38);
            this.txtBuscarActualizar.Name = "txtBuscarActualizar";
            this.txtBuscarActualizar.Size = new System.Drawing.Size(491, 23);
            this.txtBuscarActualizar.TabIndex = 4;
            this.txtBuscarActualizar.TextChanged += new System.EventHandler(this.txtBuscarActualizar_TextChanged);
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
            // tabDepartamentos
            // 
            this.tabDepartamentos.Controls.Add(this.tabEditDepartment);
            this.tabDepartamentos.Controls.Add(this.tabFindJob);
            this.tabDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabDepartamentos.Location = new System.Drawing.Point(0, 0);
            this.tabDepartamentos.Name = "tabDepartamentos";
            this.tabDepartamentos.SelectedIndex = 0;
            this.tabDepartamentos.Size = new System.Drawing.Size(1034, 669);
            this.tabDepartamentos.TabIndex = 1;
            // 
            // tabFindJob
            // 
            this.tabFindJob.Controls.Add(this.groupBox3);
            this.tabFindJob.Controls.Add(this.groupBox2);
            this.tabFindJob.Location = new System.Drawing.Point(4, 25);
            this.tabFindJob.Name = "tabFindJob";
            this.tabFindJob.Size = new System.Drawing.Size(1026, 640);
            this.tabFindJob.TabIndex = 2;
            this.tabFindJob.Text = "Buscar puesto";
            this.tabFindJob.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgvEditar);
            this.groupBox3.Controls.Add(this.panel3);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.panelFiltro);
            this.groupBox3.Controls.Add(this.cmbBusquedaPuestos);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.groupBox3.Size = new System.Drawing.Size(502, 640);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar Puestos:";
            // 
            // dgvEditar
            // 
            this.dgvEditar.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvEditar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEditar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn15,
            this.dataGridViewTextBoxColumn16,
            this.dataGridViewTextBoxColumn17});
            this.dgvEditar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEditar.GridColor = System.Drawing.SystemColors.Control;
            this.dgvEditar.Location = new System.Drawing.Point(13, 250);
            this.dgvEditar.Margin = new System.Windows.Forms.Padding(4);
            this.dgvEditar.Name = "dgvEditar";
            this.dgvEditar.Size = new System.Drawing.Size(476, 378);
            this.dgvEditar.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Id";
            this.dataGridViewTextBoxColumn1.HeaderText = "Código";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Motivo";
            this.dataGridViewTextBoxColumn2.HeaderText = "Motivo";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Dia";
            this.dataGridViewTextBoxColumn3.HeaderText = "Día";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Mes";
            this.dataGridViewTextBoxColumn4.HeaderText = "Mes";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "pagoDoble";
            this.dataGridViewTextBoxColumn5.HeaderText = "Pago Doble";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "getCreador";
            this.dataGridViewTextBoxColumn6.HeaderText = "Creador";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "getFechaCreacion";
            this.dataGridViewTextBoxColumn13.HeaderText = "Fecha creación:";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "getModificador";
            this.dataGridViewTextBoxColumn15.HeaderText = "Modificador";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "getFechaModificacion";
            this.dataGridViewTextBoxColumn16.HeaderText = "FechaModificacion";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "getActivo";
            this.dataGridViewTextBoxColumn17.HeaderText = "Activo";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(13, 204);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(476, 46);
            this.panel3.TabIndex = 7;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(13, 170);
            this.label14.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(476, 34);
            this.label14.TabIndex = 4;
            this.label14.Text = "Seleccione el feriado a modificar::";
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.txtBuscarEditar);
            this.panelFiltro.Controls.Add(this.lblPuestoABuscar);
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Location = new System.Drawing.Point(13, 86);
            this.panelFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.panelFiltro.Size = new System.Drawing.Size(476, 84);
            this.panelFiltro.TabIndex = 3;
            // 
            // txtBuscarEditar
            // 
            this.txtBuscarEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarEditar.Location = new System.Drawing.Point(0, 46);
            this.txtBuscarEditar.Margin = new System.Windows.Forms.Padding(4);
            this.txtBuscarEditar.Name = "txtBuscarEditar";
            this.txtBuscarEditar.Size = new System.Drawing.Size(476, 23);
            this.txtBuscarEditar.TabIndex = 4;
            // 
            // lblPuestoABuscar
            // 
            this.lblPuestoABuscar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblPuestoABuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblPuestoABuscar.Location = new System.Drawing.Point(0, 12);
            this.lblPuestoABuscar.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.lblPuestoABuscar.Name = "lblPuestoABuscar";
            this.lblPuestoABuscar.Size = new System.Drawing.Size(476, 34);
            this.lblPuestoABuscar.TabIndex = 3;
            this.lblPuestoABuscar.Text = "Digite :";
            // 
            // cmbBusquedaPuestos
            // 
            this.cmbBusquedaPuestos.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbBusquedaPuestos.FormattingEnabled = true;
            this.cmbBusquedaPuestos.Items.AddRange(new object[] {
            "Todos",
            "Codigo",
            "Mes",
            "Motivo"});
            this.cmbBusquedaPuestos.Location = new System.Drawing.Point(13, 62);
            this.cmbBusquedaPuestos.Margin = new System.Windows.Forms.Padding(4);
            this.cmbBusquedaPuestos.Name = "cmbBusquedaPuestos";
            this.cmbBusquedaPuestos.Size = new System.Drawing.Size(476, 24);
            this.cmbBusquedaPuestos.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(13, 28);
            this.label13.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(476, 34);
            this.label13.TabIndex = 1;
            this.label13.Text = "Seleccione el tipo de busqueda:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.ckbActivo);
            this.groupBox2.Controls.Add(this.txtInsertarDepartamento);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtInsertarDescripcion);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtCodigoPuesto);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox2.Location = new System.Drawing.Point(502, 0);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.groupBox2.Size = new System.Drawing.Size(524, 640);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Completar datos del puesto";
            // 
            // txtCodigoPuesto
            // 
            this.txtCodigoPuesto.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCodigoPuesto.Location = new System.Drawing.Point(13, 71);
            this.txtCodigoPuesto.Margin = new System.Windows.Forms.Padding(5);
            this.txtCodigoPuesto.Name = "txtCodigoPuesto";
            this.txtCodigoPuesto.ReadOnly = true;
            this.txtCodigoPuesto.Size = new System.Drawing.Size(498, 23);
            this.txtCodigoPuesto.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Top;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.Location = new System.Drawing.Point(13, 28);
            this.label8.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label8.Size = new System.Drawing.Size(498, 43);
            this.label8.TabIndex = 0;
            this.label8.Text = "Código:";
            // 
            // txtInsertarDescripcion
            // 
            this.txtInsertarDescripcion.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInsertarDescripcion.Location = new System.Drawing.Point(13, 124);
            this.txtInsertarDescripcion.Margin = new System.Windows.Forms.Padding(5);
            this.txtInsertarDescripcion.Name = "txtInsertarDescripcion";
            this.txtInsertarDescripcion.Size = new System.Drawing.Size(498, 23);
            this.txtInsertarDescripcion.TabIndex = 69;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(13, 94);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.label4.Size = new System.Drawing.Size(498, 30);
            this.label4.TabIndex = 68;
            this.label4.Text = "Descripción:";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(13, 147);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(498, 30);
            this.label1.TabIndex = 70;
            this.label1.Text = "Departamento:";
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Top;
            this.button4.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button4.Location = new System.Drawing.Point(13, 233);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.button4.Size = new System.Drawing.Size(498, 102);
            this.button4.TabIndex = 76;
            this.button4.Text = "Insertar Puesto";
            this.button4.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button4.UseVisualStyleBackColor = true;
            // 
            // ckbActivo
            // 
            this.ckbActivo.AutoSize = true;
            this.ckbActivo.Checked = true;
            this.ckbActivo.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ckbActivo.Dock = System.Windows.Forms.DockStyle.Top;
            this.ckbActivo.Location = new System.Drawing.Point(13, 200);
            this.ckbActivo.Margin = new System.Windows.Forms.Padding(4);
            this.ckbActivo.Name = "ckbActivo";
            this.ckbActivo.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.ckbActivo.Size = new System.Drawing.Size(498, 33);
            this.ckbActivo.TabIndex = 75;
            this.ckbActivo.Text = "Activo";
            this.ckbActivo.UseVisualStyleBackColor = true;
            // 
            // txtInsertarDepartamento
            // 
            this.txtInsertarDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtInsertarDepartamento.Location = new System.Drawing.Point(13, 177);
            this.txtInsertarDepartamento.Name = "txtInsertarDepartamento";
            this.txtInsertarDepartamento.ReadOnly = true;
            this.txtInsertarDepartamento.Size = new System.Drawing.Size(498, 23);
            this.txtInsertarDepartamento.TabIndex = 74;
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
            this.gbxFiltroActualizar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdActualizar)).EndInit();
            this.pnlFiltroActualizar.ResumeLayout(false);
            this.pnlFiltroActualizar.PerformLayout();
            this.gbxActualizar.ResumeLayout(false);
            this.gbxActualizar.PerformLayout();
            this.tabDepartamentos.ResumeLayout(false);
            this.tabFindJob.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEditar)).EndInit();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
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
        private System.Windows.Forms.TabPage tabFindJob;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dgvEditar;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.TextBox txtBuscarEditar;
        private System.Windows.Forms.Label lblPuestoABuscar;
        private System.Windows.Forms.ComboBox cmbBusquedaPuestos;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtCodigoPuesto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.CheckBox ckbActivo;
        private System.Windows.Forms.TextBox txtInsertarDepartamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtInsertarDescripcion;
        private System.Windows.Forms.Label label4;
    }
}