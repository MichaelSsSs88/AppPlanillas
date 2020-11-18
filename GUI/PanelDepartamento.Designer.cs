namespace AppPlanillas.GUI
{
    partial class PanelDepartamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PanelDepartamento));
            this.tabDepartamentos = new System.Windows.Forms.TabControl();
            this.tabInsertDepartment = new System.Windows.Forms.TabPage();
            this.grdInsertar = new System.Windows.Forms.DataGridView();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.gbxCompletarDatos = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cbxActivoIngresar = new System.Windows.Forms.CheckBox();
            this.txtNombreDepartamento = new System.Windows.Forms.TextBox();
            this.lblIngresarNombre = new System.Windows.Forms.Label();
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
            this.cbxActivoActualizar = new System.Windows.Forms.CheckBox();
            this.btnGuardarActualizar = new System.Windows.Forms.Button();
            this.txtNombreDepartamentoActualizar = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCodigoDepartamentoActualizar = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabDeleteDepartment = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.grdEliminar = new System.Windows.Forms.DataGridView();
            this.colIdEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNombreEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCreadorEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaCreacionEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colModificadorEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFechaModificacionEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActivoEliminar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblSeleccionarEliminar = new System.Windows.Forms.Label();
            this.pnlFiltroEliminar = new System.Windows.Forms.Panel();
            this.txtBuscarEliminar = new System.Windows.Forms.TextBox();
            this.lblDigiteEliminar = new System.Windows.Forms.Label();
            this.cmbTipoBusquedaEliminar = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbxDatosEliminar = new System.Windows.Forms.GroupBox();
            this.btnEliminarDepartamento = new System.Windows.Forms.Button();
            this.txtDescripcionEliminar = new System.Windows.Forms.TextBox();
            this.lblDescripcionEliminar = new System.Windows.Forms.Label();
            this.txtCodigoEliminar = new System.Windows.Forms.TextBox();
            this.lblCodigoEliminar = new System.Windows.Forms.Label();
            this.tabDepartamentos.SuspendLayout();
            this.tabInsertDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdInsertar)).BeginInit();
            this.panel4.SuspendLayout();
            this.gbxCompletarDatos.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabEditDepartment.SuspendLayout();
            this.gbxFiltroActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdActualizar)).BeginInit();
            this.pnlFiltroActualizar.SuspendLayout();
            this.gbxActualizar.SuspendLayout();
            this.tabDeleteDepartment.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdEliminar)).BeginInit();
            this.pnlFiltroEliminar.SuspendLayout();
            this.gbxDatosEliminar.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabDepartamentos
            // 
            this.tabDepartamentos.Controls.Add(this.tabInsertDepartment);
            this.tabDepartamentos.Controls.Add(this.tabEditDepartment);
            this.tabDepartamentos.Controls.Add(this.tabDeleteDepartment);
            this.tabDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDepartamentos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.tabDepartamentos.Location = new System.Drawing.Point(0, 0);
            this.tabDepartamentos.Name = "tabDepartamentos";
            this.tabDepartamentos.SelectedIndex = 0;
            this.tabDepartamentos.Size = new System.Drawing.Size(1034, 669);
            this.tabDepartamentos.TabIndex = 0;
            // 
            // tabInsertDepartment
            // 
            this.tabInsertDepartment.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabInsertDepartment.Controls.Add(this.grdInsertar);
            this.tabInsertDepartment.Controls.Add(this.panel4);
            this.tabInsertDepartment.Controls.Add(this.gbxCompletarDatos);
            this.tabInsertDepartment.Location = new System.Drawing.Point(4, 25);
            this.tabInsertDepartment.Name = "tabInsertDepartment";
            this.tabInsertDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsertDepartment.Size = new System.Drawing.Size(1026, 640);
            this.tabInsertDepartment.TabIndex = 0;
            this.tabInsertDepartment.Text = "Insertar Departamento";
            this.tabInsertDepartment.UseVisualStyleBackColor = true;
            // 
            // grdInsertar
            // 
            this.grdInsertar.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.grdInsertar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdInsertar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Identificador,
            this.Nombre,
            this.Creador,
            this.FechaCreacion,
            this.Modificador,
            this.FechaModificacion,
            this.colActivo});
            this.grdInsertar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdInsertar.GridColor = System.Drawing.SystemColors.Control;
            this.grdInsertar.Location = new System.Drawing.Point(3, 350);
            this.grdInsertar.Name = "grdInsertar";
            this.grdInsertar.Size = new System.Drawing.Size(1020, 287);
            this.grdInsertar.TabIndex = 3;
            // 
            // Identificador
            // 
            this.Identificador.DataPropertyName = "getId";
            this.Identificador.HeaderText = "Identificador";
            this.Identificador.Name = "Identificador";
            // 
            // Nombre
            // 
            this.Nombre.DataPropertyName = "getNombre";
            this.Nombre.HeaderText = "Departamento";
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 200;
            // 
            // Creador
            // 
            this.Creador.DataPropertyName = "getCreador";
            this.Creador.HeaderText = "Creardor";
            this.Creador.Name = "Creador";
            this.Creador.Width = 200;
            // 
            // FechaCreacion
            // 
            this.FechaCreacion.DataPropertyName = "getFechaCreacion";
            this.FechaCreacion.HeaderText = "Fecha Creación";
            this.FechaCreacion.Name = "FechaCreacion";
            this.FechaCreacion.Width = 150;
            // 
            // Modificador
            // 
            this.Modificador.DataPropertyName = "getModificador";
            this.Modificador.HeaderText = "Modificador";
            this.Modificador.Name = "Modificador";
            this.Modificador.Width = 200;
            // 
            // FechaModificacion
            // 
            this.FechaModificacion.DataPropertyName = "getFechaModificacion";
            this.FechaModificacion.HeaderText = "Fecha Modificacion";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.Width = 150;
            // 
            // colActivo
            // 
            this.colActivo.DataPropertyName = "getActivo";
            this.colActivo.HeaderText = "Activo";
            this.colActivo.Name = "colActivo";
            this.colActivo.ReadOnly = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btnReporte);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 253);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1020, 97);
            this.panel4.TabIndex = 2;
            // 
            // btnReporte
            // 
            this.btnReporte.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnReporte.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnReporte.FlatAppearance.BorderSize = 0;
            this.btnReporte.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReporte.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnReporte.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnReporte.Image = ((System.Drawing.Image)(resources.GetObject("btnReporte.Image")));
            this.btnReporte.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnReporte.Location = new System.Drawing.Point(814, 0);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(206, 97);
            this.btnReporte.TabIndex = 8;
            this.btnReporte.Text = "Generar reporte";
            this.btnReporte.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            this.btnReporte.MouseEnter += new System.EventHandler(this.btnReporte_MouseEnter);
            this.btnReporte.MouseLeave += new System.EventHandler(this.btnReporte_MouseLeave);
            // 
            // gbxCompletarDatos
            // 
            this.gbxCompletarDatos.Controls.Add(this.panel3);
            this.gbxCompletarDatos.Controls.Add(this.panel2);
            this.gbxCompletarDatos.Controls.Add(this.panel1);
            this.gbxCompletarDatos.Controls.Add(this.cbxActivoIngresar);
            this.gbxCompletarDatos.Controls.Add(this.txtNombreDepartamento);
            this.gbxCompletarDatos.Controls.Add(this.lblIngresarNombre);
            this.gbxCompletarDatos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxCompletarDatos.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbxCompletarDatos.Location = new System.Drawing.Point(3, 3);
            this.gbxCompletarDatos.Name = "gbxCompletarDatos";
            this.gbxCompletarDatos.Size = new System.Drawing.Size(1020, 250);
            this.gbxCompletarDatos.TabIndex = 1;
            this.gbxCompletarDatos.TabStop = false;
            this.gbxCompletarDatos.Text = "Completar datos";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnGuardar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(338, 90);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(344, 157);
            this.panel3.TabIndex = 37;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGuardar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(0, 0);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(344, 157);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar Departamento";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            this.btnGuardar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            this.btnGuardar.MouseHover += new System.EventHandler(this.btnGuardar_MouseHover);
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(682, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(335, 157);
            this.panel2.TabIndex = 36;
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 90);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(335, 157);
            this.panel1.TabIndex = 35;
            // 
            // cbxActivoIngresar
            // 
            this.cbxActivoIngresar.AutoSize = true;
            this.cbxActivoIngresar.Checked = true;
            this.cbxActivoIngresar.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbxActivoIngresar.Dock = System.Windows.Forms.DockStyle.Top;
            this.cbxActivoIngresar.Location = new System.Drawing.Point(3, 59);
            this.cbxActivoIngresar.Name = "cbxActivoIngresar";
            this.cbxActivoIngresar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.cbxActivoIngresar.Size = new System.Drawing.Size(1014, 31);
            this.cbxActivoIngresar.TabIndex = 34;
            this.cbxActivoIngresar.Text = "Activo";
            this.cbxActivoIngresar.UseVisualStyleBackColor = true;
            // 
            // txtNombreDepartamento
            // 
            this.txtNombreDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNombreDepartamento.Location = new System.Drawing.Point(3, 36);
            this.txtNombreDepartamento.Name = "txtNombreDepartamento";
            this.txtNombreDepartamento.Size = new System.Drawing.Size(1014, 23);
            this.txtNombreDepartamento.TabIndex = 3;
            // 
            // lblIngresarNombre
            // 
            this.lblIngresarNombre.AutoSize = true;
            this.lblIngresarNombre.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblIngresarNombre.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblIngresarNombre.Location = new System.Drawing.Point(3, 19);
            this.lblIngresarNombre.Name = "lblIngresarNombre";
            this.lblIngresarNombre.Size = new System.Drawing.Size(241, 17);
            this.lblIngresarNombre.TabIndex = 2;
            this.lblIngresarNombre.Text = "Ingrese el nombre del departamento:";
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
            this.grdActualizar.Click += new System.EventHandler(this.dataGridView2_Click);
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
            this.txtBuscarActualizar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox9_KeyDown);
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
            this.cmbTipoBusquedaActualizar.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
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
            this.gbxActualizar.Controls.Add(this.cbxActivoActualizar);
            this.gbxActualizar.Controls.Add(this.btnGuardarActualizar);
            this.gbxActualizar.Controls.Add(this.txtNombreDepartamentoActualizar);
            this.gbxActualizar.Controls.Add(this.label11);
            this.gbxActualizar.Controls.Add(this.txtCodigoDepartamentoActualizar);
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
            this.gbxActualizar.Text = "Completar datos del departamento";
            // 
            // cbxActivoActualizar
            // 
            this.cbxActivoActualizar.AutoSize = true;
            this.cbxActivoActualizar.Location = new System.Drawing.Point(13, 140);
            this.cbxActivoActualizar.Name = "cbxActivoActualizar";
            this.cbxActivoActualizar.Size = new System.Drawing.Size(65, 21);
            this.cbxActivoActualizar.TabIndex = 37;
            this.cbxActivoActualizar.Text = "Activo";
            this.cbxActivoActualizar.UseVisualStyleBackColor = true;
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
            this.btnGuardarActualizar.Location = new System.Drawing.Point(10, 130);
            this.btnGuardarActualizar.Name = "btnGuardarActualizar";
            this.btnGuardarActualizar.Size = new System.Drawing.Size(489, 83);
            this.btnGuardarActualizar.TabIndex = 36;
            this.btnGuardarActualizar.Text = "Editar Departamento";
            this.btnGuardarActualizar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarActualizar.UseVisualStyleBackColor = true;
            this.btnGuardarActualizar.Click += new System.EventHandler(this.btnGuardarEditar_Click);
            this.btnGuardarActualizar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            this.btnGuardarActualizar.MouseHover += new System.EventHandler(this.btnGuardar_MouseHover);
            // 
            // txtNombreDepartamentoActualizar
            // 
            this.txtNombreDepartamentoActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtNombreDepartamentoActualizar.Location = new System.Drawing.Point(10, 107);
            this.txtNombreDepartamentoActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreDepartamentoActualizar.Name = "txtNombreDepartamentoActualizar";
            this.txtNombreDepartamentoActualizar.Size = new System.Drawing.Size(489, 23);
            this.txtNombreDepartamentoActualizar.TabIndex = 17;
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
            // txtCodigoDepartamentoActualizar
            // 
            this.txtCodigoDepartamentoActualizar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCodigoDepartamentoActualizar.Location = new System.Drawing.Point(10, 54);
            this.txtCodigoDepartamentoActualizar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoDepartamentoActualizar.Name = "txtCodigoDepartamentoActualizar";
            this.txtCodigoDepartamentoActualizar.ReadOnly = true;
            this.txtCodigoDepartamentoActualizar.Size = new System.Drawing.Size(489, 23);
            this.txtCodigoDepartamentoActualizar.TabIndex = 1;
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
            // tabDeleteDepartment
            // 
            this.tabDeleteDepartment.Controls.Add(this.groupBox4);
            this.tabDeleteDepartment.Controls.Add(this.gbxDatosEliminar);
            this.tabDeleteDepartment.Location = new System.Drawing.Point(4, 25);
            this.tabDeleteDepartment.Name = "tabDeleteDepartment";
            this.tabDeleteDepartment.Size = new System.Drawing.Size(1026, 640);
            this.tabDeleteDepartment.TabIndex = 2;
            this.tabDeleteDepartment.Text = "Eliminar Departamento";
            this.tabDeleteDepartment.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.grdEliminar);
            this.groupBox4.Controls.Add(this.lblSeleccionarEliminar);
            this.groupBox4.Controls.Add(this.pnlFiltroEliminar);
            this.groupBox4.Controls.Add(this.cmbTipoBusquedaEliminar);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox4.Size = new System.Drawing.Size(517, 640);
            this.groupBox4.TabIndex = 7;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Filtrar Departamento:";
            // 
            // grdEliminar
            // 
            this.grdEliminar.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.grdEliminar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdEliminar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdEliminar,
            this.colNombreEliminar,
            this.colCreadorEliminar,
            this.colFechaCreacionEliminar,
            this.colModificadorEliminar,
            this.colFechaModificacionEliminar,
            this.colActivoEliminar});
            this.grdEliminar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdEliminar.GridColor = System.Drawing.SystemColors.Control;
            this.grdEliminar.Location = new System.Drawing.Point(10, 176);
            this.grdEliminar.Name = "grdEliminar";
            this.grdEliminar.Size = new System.Drawing.Size(497, 454);
            this.grdEliminar.TabIndex = 5;
            this.grdEliminar.Click += new System.EventHandler(this.grdEliminar_Click);
            // 
            // colIdEliminar
            // 
            this.colIdEliminar.DataPropertyName = "getId";
            this.colIdEliminar.HeaderText = "ID";
            this.colIdEliminar.Name = "colIdEliminar";
            this.colIdEliminar.ReadOnly = true;
            // 
            // colNombreEliminar
            // 
            this.colNombreEliminar.DataPropertyName = "getNombre";
            this.colNombreEliminar.HeaderText = "Nombre";
            this.colNombreEliminar.Name = "colNombreEliminar";
            this.colNombreEliminar.ReadOnly = true;
            // 
            // colCreadorEliminar
            // 
            this.colCreadorEliminar.DataPropertyName = "getCreador";
            this.colCreadorEliminar.HeaderText = "Creador";
            this.colCreadorEliminar.Name = "colCreadorEliminar";
            this.colCreadorEliminar.ReadOnly = true;
            // 
            // colFechaCreacionEliminar
            // 
            this.colFechaCreacionEliminar.DataPropertyName = "getFechaCreacion";
            this.colFechaCreacionEliminar.HeaderText = "Fecha creación";
            this.colFechaCreacionEliminar.Name = "colFechaCreacionEliminar";
            this.colFechaCreacionEliminar.ReadOnly = true;
            // 
            // colModificadorEliminar
            // 
            this.colModificadorEliminar.DataPropertyName = "getModificador";
            this.colModificadorEliminar.HeaderText = "Modificador";
            this.colModificadorEliminar.Name = "colModificadorEliminar";
            this.colModificadorEliminar.ReadOnly = true;
            // 
            // colFechaModificacionEliminar
            // 
            this.colFechaModificacionEliminar.DataPropertyName = "getFechaModificacion";
            this.colFechaModificacionEliminar.HeaderText = "Fecha modificación";
            this.colFechaModificacionEliminar.Name = "colFechaModificacionEliminar";
            this.colFechaModificacionEliminar.ReadOnly = true;
            // 
            // colActivoEliminar
            // 
            this.colActivoEliminar.DataPropertyName = "getActivo";
            this.colActivoEliminar.HeaderText = "Activo";
            this.colActivoEliminar.Name = "colActivoEliminar";
            this.colActivoEliminar.ReadOnly = true;
            // 
            // lblSeleccionarEliminar
            // 
            this.lblSeleccionarEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSeleccionarEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblSeleccionarEliminar.Location = new System.Drawing.Point(10, 146);
            this.lblSeleccionarEliminar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSeleccionarEliminar.Name = "lblSeleccionarEliminar";
            this.lblSeleccionarEliminar.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblSeleccionarEliminar.Size = new System.Drawing.Size(497, 30);
            this.lblSeleccionarEliminar.TabIndex = 4;
            this.lblSeleccionarEliminar.Text = "Seleccione el departamento a eliminar:";
            // 
            // pnlFiltroEliminar
            // 
            this.pnlFiltroEliminar.Controls.Add(this.txtBuscarEliminar);
            this.pnlFiltroEliminar.Controls.Add(this.lblDigiteEliminar);
            this.pnlFiltroEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFiltroEliminar.Location = new System.Drawing.Point(10, 78);
            this.pnlFiltroEliminar.Name = "pnlFiltroEliminar";
            this.pnlFiltroEliminar.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.pnlFiltroEliminar.Size = new System.Drawing.Size(497, 68);
            this.pnlFiltroEliminar.TabIndex = 3;
            // 
            // txtBuscarEliminar
            // 
            this.txtBuscarEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtBuscarEliminar.Location = new System.Drawing.Point(0, 38);
            this.txtBuscarEliminar.Name = "txtBuscarEliminar";
            this.txtBuscarEliminar.Size = new System.Drawing.Size(497, 23);
            this.txtBuscarEliminar.TabIndex = 4;
            this.txtBuscarEliminar.TextChanged += new System.EventHandler(this.txtBuscarEliminar_TextChanged);
            // 
            // lblDigiteEliminar
            // 
            this.lblDigiteEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDigiteEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDigiteEliminar.Location = new System.Drawing.Point(0, 10);
            this.lblDigiteEliminar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDigiteEliminar.Name = "lblDigiteEliminar";
            this.lblDigiteEliminar.Size = new System.Drawing.Size(497, 28);
            this.lblDigiteEliminar.TabIndex = 3;
            this.lblDigiteEliminar.Text = "Digite :";
            // 
            // cmbTipoBusquedaEliminar
            // 
            this.cmbTipoBusquedaEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.cmbTipoBusquedaEliminar.FormattingEnabled = true;
            this.cmbTipoBusquedaEliminar.Items.AddRange(new object[] {
            "Todos",
            "Codigo",
            "Descripción"});
            this.cmbTipoBusquedaEliminar.Location = new System.Drawing.Point(10, 54);
            this.cmbTipoBusquedaEliminar.Name = "cmbTipoBusquedaEliminar";
            this.cmbTipoBusquedaEliminar.Size = new System.Drawing.Size(497, 24);
            this.cmbTipoBusquedaEliminar.TabIndex = 2;
            this.cmbTipoBusquedaEliminar.SelectedIndexChanged += new System.EventHandler(this.cmbTipoBusquedaEliminar_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.Location = new System.Drawing.Point(10, 26);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(497, 28);
            this.label5.TabIndex = 1;
            this.label5.Text = "Seleccione el tipo de busqueda:";
            // 
            // gbxDatosEliminar
            // 
            this.gbxDatosEliminar.Controls.Add(this.btnEliminarDepartamento);
            this.gbxDatosEliminar.Controls.Add(this.txtDescripcionEliminar);
            this.gbxDatosEliminar.Controls.Add(this.lblDescripcionEliminar);
            this.gbxDatosEliminar.Controls.Add(this.txtCodigoEliminar);
            this.gbxDatosEliminar.Controls.Add(this.lblCodigoEliminar);
            this.gbxDatosEliminar.Dock = System.Windows.Forms.DockStyle.Right;
            this.gbxDatosEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.gbxDatosEliminar.Location = new System.Drawing.Point(517, 0);
            this.gbxDatosEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.gbxDatosEliminar.Name = "gbxDatosEliminar";
            this.gbxDatosEliminar.Padding = new System.Windows.Forms.Padding(10, 10, 10, 4);
            this.gbxDatosEliminar.Size = new System.Drawing.Size(509, 640);
            this.gbxDatosEliminar.TabIndex = 6;
            this.gbxDatosEliminar.TabStop = false;
            this.gbxDatosEliminar.Text = "Verificar datos del departamentoa eliminar";
            // 
            // btnEliminarDepartamento
            // 
            this.btnEliminarDepartamento.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEliminarDepartamento.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminarDepartamento.FlatAppearance.BorderSize = 0;
            this.btnEliminarDepartamento.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarDepartamento.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarDepartamento.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarDepartamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEliminarDepartamento.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarDepartamento.Image")));
            this.btnEliminarDepartamento.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarDepartamento.Location = new System.Drawing.Point(10, 130);
            this.btnEliminarDepartamento.Name = "btnEliminarDepartamento";
            this.btnEliminarDepartamento.Size = new System.Drawing.Size(489, 83);
            this.btnEliminarDepartamento.TabIndex = 37;
            this.btnEliminarDepartamento.Text = "Eliminar Departamento";
            this.btnEliminarDepartamento.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarDepartamento.UseVisualStyleBackColor = true;
            this.btnEliminarDepartamento.Click += new System.EventHandler(this.btnEliminarDepartamento_Click);
            // 
            // txtDescripcionEliminar
            // 
            this.txtDescripcionEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtDescripcionEliminar.Location = new System.Drawing.Point(10, 107);
            this.txtDescripcionEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcionEliminar.Name = "txtDescripcionEliminar";
            this.txtDescripcionEliminar.ReadOnly = true;
            this.txtDescripcionEliminar.Size = new System.Drawing.Size(489, 23);
            this.txtDescripcionEliminar.TabIndex = 17;
            // 
            // lblDescripcionEliminar
            // 
            this.lblDescripcionEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDescripcionEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblDescripcionEliminar.Location = new System.Drawing.Point(10, 77);
            this.lblDescripcionEliminar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcionEliminar.Name = "lblDescripcionEliminar";
            this.lblDescripcionEliminar.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblDescripcionEliminar.Size = new System.Drawing.Size(489, 30);
            this.lblDescripcionEliminar.TabIndex = 16;
            this.lblDescripcionEliminar.Text = "Descripción del departamento:";
            // 
            // txtCodigoEliminar
            // 
            this.txtCodigoEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtCodigoEliminar.Location = new System.Drawing.Point(10, 54);
            this.txtCodigoEliminar.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoEliminar.Name = "txtCodigoEliminar";
            this.txtCodigoEliminar.ReadOnly = true;
            this.txtCodigoEliminar.Size = new System.Drawing.Size(489, 23);
            this.txtCodigoEliminar.TabIndex = 1;
            // 
            // lblCodigoEliminar
            // 
            this.lblCodigoEliminar.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCodigoEliminar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lblCodigoEliminar.Location = new System.Drawing.Point(10, 26);
            this.lblCodigoEliminar.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoEliminar.Name = "lblCodigoEliminar";
            this.lblCodigoEliminar.Size = new System.Drawing.Size(489, 28);
            this.lblCodigoEliminar.TabIndex = 0;
            this.lblCodigoEliminar.Text = "Código del departamento:";
            // 
            // PanelDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 669);
            this.Controls.Add(this.tabDepartamentos);
            this.Name = "PanelDepartamento";
            this.Text = "PanelDepartamento";
            this.tabDepartamentos.ResumeLayout(false);
            this.tabInsertDepartment.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdInsertar)).EndInit();
            this.panel4.ResumeLayout(false);
            this.gbxCompletarDatos.ResumeLayout(false);
            this.gbxCompletarDatos.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabEditDepartment.ResumeLayout(false);
            this.gbxFiltroActualizar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdActualizar)).EndInit();
            this.pnlFiltroActualizar.ResumeLayout(false);
            this.pnlFiltroActualizar.PerformLayout();
            this.gbxActualizar.ResumeLayout(false);
            this.gbxActualizar.PerformLayout();
            this.tabDeleteDepartment.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdEliminar)).EndInit();
            this.pnlFiltroEliminar.ResumeLayout(false);
            this.pnlFiltroEliminar.PerformLayout();
            this.gbxDatosEliminar.ResumeLayout(false);
            this.gbxDatosEliminar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDepartamentos;
        private System.Windows.Forms.TabPage tabInsertDepartment;
        private System.Windows.Forms.TabPage tabEditDepartment;
        private System.Windows.Forms.TabPage tabDeleteDepartment;
        private System.Windows.Forms.GroupBox gbxCompletarDatos;
        private System.Windows.Forms.TextBox txtNombreDepartamento;
        private System.Windows.Forms.Label lblIngresarNombre;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView grdInsertar;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.GroupBox gbxFiltroActualizar;
        private System.Windows.Forms.DataGridView grdActualizar;
        private System.Windows.Forms.Label lblSelecionarActualizar;
        private System.Windows.Forms.Panel pnlFiltroActualizar;
        private System.Windows.Forms.TextBox txtBuscarActualizar;
        private System.Windows.Forms.Label lblValorABuscar;
        private System.Windows.Forms.ComboBox cmbTipoBusquedaActualizar;
        private System.Windows.Forms.Label lblTipoBusquedaActualizar;
        private System.Windows.Forms.GroupBox gbxActualizar;
        private System.Windows.Forms.TextBox txtNombreDepartamentoActualizar;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCodigoDepartamentoActualizar;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView grdEliminar;
        private System.Windows.Forms.Label lblSeleccionarEliminar;
        private System.Windows.Forms.Panel pnlFiltroEliminar;
        private System.Windows.Forms.TextBox txtBuscarEliminar;
        private System.Windows.Forms.Label lblDigiteEliminar;
        private System.Windows.Forms.ComboBox cmbTipoBusquedaEliminar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbxDatosEliminar;
        private System.Windows.Forms.TextBox txtDescripcionEliminar;
        private System.Windows.Forms.Label lblDescripcionEliminar;
        private System.Windows.Forms.TextBox txtCodigoEliminar;
        private System.Windows.Forms.Label lblCodigoEliminar;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox cbxActivoIngresar;
        private System.Windows.Forms.Button btnGuardarActualizar;
        private System.Windows.Forms.Button btnEliminarDepartamento;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaModificacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActiv;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNombreEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreadorEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaCreacionEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colModificadorEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFechaModificacionEliminar;
        private System.Windows.Forms.DataGridViewTextBoxColumn colActivoEliminar;
        private System.Windows.Forms.CheckBox cbxActivoActualizar;
    }
}