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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnReporte = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabEditDepartment = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.label14 = new System.Windows.Forms.Label();
            this.panelFiltro = new System.Windows.Forms.Panel();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.lblValorABuscar = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnGuardarEditar = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tabDeleteDepartment = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Identificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Creador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Modificador = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaModificacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabDepartamentos.SuspendLayout();
            this.tabInsertDepartment.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tabEditDepartment.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.panelFiltro.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabDeleteDepartment.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox5.SuspendLayout();
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
            this.tabInsertDepartment.Controls.Add(this.dataGridView1);
            this.tabInsertDepartment.Controls.Add(this.panel4);
            this.tabInsertDepartment.Controls.Add(this.groupBox1);
            this.tabInsertDepartment.Location = new System.Drawing.Point(4, 25);
            this.tabInsertDepartment.Name = "tabInsertDepartment";
            this.tabInsertDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsertDepartment.Size = new System.Drawing.Size(1026, 640);
            this.tabInsertDepartment.TabIndex = 0;
            this.tabInsertDepartment.Text = "Insertar Departamento";
            this.tabInsertDepartment.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Identificador,
            this.Nombre,
            this.Creador,
            this.FechaCreacion,
            this.Modificador,
            this.FechaModificacion});
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(3, 350);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1020, 287);
            this.dataGridView1.TabIndex = 3;
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.checkBox3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 250);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Completar datos";
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
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Checked = true;
            this.checkBox3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox3.Location = new System.Drawing.Point(3, 59);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.checkBox3.Size = new System.Drawing.Size(1014, 31);
            this.checkBox3.TabIndex = 34;
            this.checkBox3.Text = "Activo";
            this.checkBox3.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Location = new System.Drawing.Point(3, 36);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1014, 23);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(3, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ingrese el nombre del departamento:";
            // 
            // tabEditDepartment
            // 
            this.tabEditDepartment.Controls.Add(this.groupBox3);
            this.tabEditDepartment.Controls.Add(this.groupBox2);
            this.tabEditDepartment.Location = new System.Drawing.Point(4, 25);
            this.tabEditDepartment.Name = "tabEditDepartment";
            this.tabEditDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditDepartment.Size = new System.Drawing.Size(1026, 640);
            this.tabEditDepartment.TabIndex = 1;
            this.tabEditDepartment.Text = "Editar Departamento";
            this.tabEditDepartment.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView2);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.panelFiltro);
            this.groupBox3.Controls.Add(this.comboBox3);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox3.Size = new System.Drawing.Size(511, 634);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar Departamento:";
            // 
            // dataGridView2
            // 
            this.dataGridView2.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView2.Location = new System.Drawing.Point(10, 174);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(491, 450);
            this.dataGridView2.TabIndex = 5;
            // 
            // label14
            // 
            this.label14.Dock = System.Windows.Forms.DockStyle.Top;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label14.Location = new System.Drawing.Point(10, 146);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(491, 28);
            this.label14.TabIndex = 4;
            this.label14.Text = "Seleccione el departamento a modificar::";
            // 
            // panelFiltro
            // 
            this.panelFiltro.Controls.Add(this.textBox9);
            this.panelFiltro.Controls.Add(this.lblValorABuscar);
            this.panelFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelFiltro.Location = new System.Drawing.Point(10, 78);
            this.panelFiltro.Name = "panelFiltro";
            this.panelFiltro.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panelFiltro.Size = new System.Drawing.Size(491, 68);
            this.panelFiltro.TabIndex = 3;
            // 
            // textBox9
            // 
            this.textBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox9.Location = new System.Drawing.Point(0, 38);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(491, 23);
            this.textBox9.TabIndex = 4;
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
            // comboBox3
            // 
            this.comboBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Todos",
            "Codigo",
            "Descripción"});
            this.comboBox3.Location = new System.Drawing.Point(10, 54);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(491, 24);
            this.comboBox3.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.Dock = System.Windows.Forms.DockStyle.Top;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label13.Location = new System.Drawing.Point(10, 26);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(491, 28);
            this.label13.TabIndex = 1;
            this.label13.Text = "Seleccione el tipo de busqueda:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnGuardarEditar);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.textBox7);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.textBox8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox2.Location = new System.Drawing.Point(514, 3);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10, 10, 10, 4);
            this.groupBox2.Size = new System.Drawing.Size(509, 634);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Completar datos del departamento";
            // 
            // btnGuardarEditar
            // 
            this.btnGuardarEditar.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGuardarEditar.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnGuardarEditar.FlatAppearance.BorderSize = 0;
            this.btnGuardarEditar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarEditar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnGuardarEditar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEditar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnGuardarEditar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardarEditar.Image")));
            this.btnGuardarEditar.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGuardarEditar.Location = new System.Drawing.Point(10, 161);
            this.btnGuardarEditar.Name = "btnGuardarEditar";
            this.btnGuardarEditar.Size = new System.Drawing.Size(489, 83);
            this.btnGuardarEditar.TabIndex = 36;
            this.btnGuardarEditar.Text = "Guardar Departamento";
            this.btnGuardarEditar.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnGuardarEditar.UseVisualStyleBackColor = true;
            this.btnGuardarEditar.Click += new System.EventHandler(this.btnGuardarEditar_Click);
            this.btnGuardarEditar.MouseLeave += new System.EventHandler(this.btnGuardar_MouseLeave);
            this.btnGuardarEditar.MouseHover += new System.EventHandler(this.btnGuardar_MouseHover);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox1.Location = new System.Drawing.Point(10, 130);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.checkBox1.Size = new System.Drawing.Size(489, 31);
            this.checkBox1.TabIndex = 35;
            this.checkBox1.Text = "Activo";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            this.textBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox7.Location = new System.Drawing.Point(10, 107);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(489, 23);
            this.textBox7.TabIndex = 17;
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
            // textBox8
            // 
            this.textBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox8.Location = new System.Drawing.Point(10, 54);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(489, 23);
            this.textBox8.TabIndex = 1;
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
            this.tabDeleteDepartment.Controls.Add(this.groupBox5);
            this.tabDeleteDepartment.Location = new System.Drawing.Point(4, 25);
            this.tabDeleteDepartment.Name = "tabDeleteDepartment";
            this.tabDeleteDepartment.Size = new System.Drawing.Size(1026, 640);
            this.tabDeleteDepartment.TabIndex = 2;
            this.tabDeleteDepartment.Text = "Eliminar Departamento";
            this.tabDeleteDepartment.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dataGridView3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.panel5);
            this.groupBox4.Controls.Add(this.comboBox1);
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
            // dataGridView3
            // 
            this.dataGridView3.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView3.Location = new System.Drawing.Point(10, 176);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.Size = new System.Drawing.Size(497, 454);
            this.dataGridView3.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.Location = new System.Drawing.Point(10, 146);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(497, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Seleccione el departamento a eliminar:";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.textBox3);
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(10, 78);
            this.panel5.Name = "panel5";
            this.panel5.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.panel5.Size = new System.Drawing.Size(497, 68);
            this.panel5.TabIndex = 3;
            // 
            // textBox3
            // 
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox3.Location = new System.Drawing.Point(0, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(497, 23);
            this.textBox3.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.Location = new System.Drawing.Point(0, 10);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(497, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Digite :";
            // 
            // comboBox1
            // 
            this.comboBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Todos",
            "Codigo",
            "Descripción"});
            this.comboBox1.Location = new System.Drawing.Point(10, 54);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(497, 24);
            this.comboBox1.TabIndex = 2;
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
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button3);
            this.groupBox5.Controls.Add(this.checkBox2);
            this.groupBox5.Controls.Add(this.textBox4);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox5.Location = new System.Drawing.Point(517, 0);
            this.groupBox5.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Padding = new System.Windows.Forms.Padding(10, 10, 10, 4);
            this.groupBox5.Size = new System.Drawing.Size(509, 640);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Verificar datos del departamentoa eliminar";
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button3.Location = new System.Drawing.Point(10, 161);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(489, 83);
            this.button3.TabIndex = 37;
            this.button3.Text = "Editar Empleado";
            this.button3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button3.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Checked = true;
            this.checkBox2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.checkBox2.Location = new System.Drawing.Point(10, 130);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.checkBox2.Size = new System.Drawing.Size(489, 31);
            this.checkBox2.TabIndex = 36;
            this.checkBox2.Text = "Activo";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox4.Location = new System.Drawing.Point(10, 107);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(489, 23);
            this.textBox4.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.Location = new System.Drawing.Point(10, 77);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label6.Size = new System.Drawing.Size(489, 30);
            this.label6.TabIndex = 16;
            this.label6.Text = "Descripción del departamento:";
            // 
            // textBox5
            // 
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox5.Location = new System.Drawing.Point(10, 54);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(489, 23);
            this.textBox5.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.Dock = System.Windows.Forms.DockStyle.Top;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label7.Location = new System.Drawing.Point(10, 26);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(489, 28);
            this.label7.TabIndex = 0;
            this.label7.Text = "Código del departamento:";
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
            this.FechaModificacion.HeaderText = "FechaModificacion";
            this.FechaModificacion.Name = "FechaModificacion";
            this.FechaModificacion.Width = 150;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel4.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tabEditDepartment.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.panelFiltro.ResumeLayout(false);
            this.panelFiltro.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabDeleteDepartment.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDepartamentos;
        private System.Windows.Forms.TabPage tabInsertDepartment;
        private System.Windows.Forms.TabPage tabEditDepartment;
        private System.Windows.Forms.TabPage tabDeleteDepartment;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panelFiltro;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label lblValorABuscar;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.Button btnGuardarEditar;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Identificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Creador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Modificador;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaModificacion;
    }
}