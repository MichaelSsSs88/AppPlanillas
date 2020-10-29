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
            this.tabEditDepartment = new System.Windows.Forms.TabPage();
            this.tabDeleteDepartment = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnEditarEmpleado = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabDepartamentos.SuspendLayout();
            this.tabInsertDepartment.SuspendLayout();
            this.tabEditDepartment.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // tabDepartamentos
            // 
            this.tabDepartamentos.Controls.Add(this.tabInsertDepartment);
            this.tabDepartamentos.Controls.Add(this.tabEditDepartment);
            this.tabDepartamentos.Controls.Add(this.tabDeleteDepartment);
            this.tabDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabDepartamentos.Location = new System.Drawing.Point(0, 0);
            this.tabDepartamentos.Name = "tabDepartamentos";
            this.tabDepartamentos.SelectedIndex = 0;
            this.tabDepartamentos.Size = new System.Drawing.Size(1034, 649);
            this.tabDepartamentos.TabIndex = 0;
            // 
            // tabInsertDepartment
            // 
            this.tabInsertDepartment.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.tabInsertDepartment.Controls.Add(this.dataGridView1);
            this.tabInsertDepartment.Controls.Add(this.panel4);
            this.tabInsertDepartment.Controls.Add(this.groupBox1);
            this.tabInsertDepartment.Location = new System.Drawing.Point(4, 22);
            this.tabInsertDepartment.Name = "tabInsertDepartment";
            this.tabInsertDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabInsertDepartment.Size = new System.Drawing.Size(1026, 623);
            this.tabInsertDepartment.TabIndex = 0;
            this.tabInsertDepartment.Text = "Insertar Departamento";
            this.tabInsertDepartment.UseVisualStyleBackColor = true;
            // 
            // tabEditDepartment
            // 
            this.tabEditDepartment.Controls.Add(this.label2);
            this.tabEditDepartment.Location = new System.Drawing.Point(4, 22);
            this.tabEditDepartment.Name = "tabEditDepartment";
            this.tabEditDepartment.Padding = new System.Windows.Forms.Padding(3);
            this.tabEditDepartment.Size = new System.Drawing.Size(1026, 623);
            this.tabEditDepartment.TabIndex = 1;
            this.tabEditDepartment.Text = "Editar Departamento";
            this.tabEditDepartment.UseVisualStyleBackColor = true;
            // 
            // tabDeleteDepartment
            // 
            this.tabDeleteDepartment.Location = new System.Drawing.Point(4, 22);
            this.tabDeleteDepartment.Name = "tabDeleteDepartment";
            this.tabDeleteDepartment.Size = new System.Drawing.Size(1026, 623);
            this.tabDeleteDepartment.TabIndex = 2;
            this.tabDeleteDepartment.Text = "Eliminar Departamento";
            this.tabDeleteDepartment.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(389, 138);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Editar";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel3);
            this.groupBox1.Controls.Add(this.panel2);
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1020, 214);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Completar datos";
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox1.Location = new System.Drawing.Point(3, 42);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1014, 23);
            this.textBox1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1014, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ingrese el codigo del departamento:";
            // 
            // textBox2
            // 
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox2.Location = new System.Drawing.Point(3, 82);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(1014, 23);
            this.textBox2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.Location = new System.Drawing.Point(3, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(241, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ingrese el nombre del departamento:";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(3, 105);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(374, 106);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(643, 105);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(374, 106);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnEditarEmpleado);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(377, 105);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(266, 106);
            this.panel3.TabIndex = 6;
            // 
            // btnEditarEmpleado
            // 
            this.btnEditarEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnEditarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEditarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEditarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEditarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEditarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditarEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEditarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarEmpleado.Image")));
            this.btnEditarEmpleado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEditarEmpleado.Location = new System.Drawing.Point(0, 0);
            this.btnEditarEmpleado.Name = "btnEditarEmpleado";
            this.btnEditarEmpleado.Size = new System.Drawing.Size(266, 106);
            this.btnEditarEmpleado.TabIndex = 7;
            this.btnEditarEmpleado.Text = "Editar Empleado";
            this.btnEditarEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarEmpleado.UseVisualStyleBackColor = true;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(3, 217);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1020, 97);
            this.panel4.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.button1.Location = new System.Drawing.Point(814, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 97);
            this.button1.TabIndex = 8;
            this.button1.Text = "Editar Empleado";
            this.button1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.Location = new System.Drawing.Point(3, 314);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1020, 306);
            this.dataGridView1.TabIndex = 3;
            // 
            // PanelDepartamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 649);
            this.Controls.Add(this.tabDepartamentos);
            this.Name = "PanelDepartamento";
            this.Text = "PanelDepartamento";
            this.tabDepartamentos.ResumeLayout(false);
            this.tabInsertDepartment.ResumeLayout(false);
            this.tabEditDepartment.ResumeLayout(false);
            this.tabEditDepartment.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabDepartamentos;
        private System.Windows.Forms.TabPage tabInsertDepartment;
        private System.Windows.Forms.TabPage tabEditDepartment;
        private System.Windows.Forms.TabPage tabDeleteDepartment;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnEditarEmpleado;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button1;
    }
}