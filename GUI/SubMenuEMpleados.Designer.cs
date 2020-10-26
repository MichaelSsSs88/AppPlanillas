namespace AppPlanillas.GUI
{
    partial class SubMenuEmpleados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubMenuEmpleados));
            this.panelMenuHorizontal = new System.Windows.Forms.Panel();
            this.btnInsertarEmpleado = new System.Windows.Forms.Button();
            this.btnEliminarEmpleado = new System.Windows.Forms.Button();
            this.btnEditarEmpleado = new System.Windows.Forms.Button();
            this.panelMenuHorizontal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenuHorizontal
            // 
            this.panelMenuHorizontal.BackColor = System.Drawing.Color.MediumTurquoise;
            this.panelMenuHorizontal.Controls.Add(this.btnEditarEmpleado);
            this.panelMenuHorizontal.Controls.Add(this.btnEliminarEmpleado);
            this.panelMenuHorizontal.Controls.Add(this.btnInsertarEmpleado);
            this.panelMenuHorizontal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMenuHorizontal.Location = new System.Drawing.Point(0, 0);
            this.panelMenuHorizontal.Name = "panelMenuHorizontal";
            this.panelMenuHorizontal.Size = new System.Drawing.Size(870, 90);
            this.panelMenuHorizontal.TabIndex = 10;
            // 
            // btnInsertarEmpleado
            // 
            this.btnInsertarEmpleado.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInsertarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnInsertarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnInsertarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInsertarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnInsertarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnInsertarEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnInsertarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnInsertarEmpleado.Image")));
            this.btnInsertarEmpleado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnInsertarEmpleado.Location = new System.Drawing.Point(0, 0);
            this.btnInsertarEmpleado.Name = "btnInsertarEmpleado";
            this.btnInsertarEmpleado.Size = new System.Drawing.Size(300, 90);
            this.btnInsertarEmpleado.TabIndex = 3;
            this.btnInsertarEmpleado.Text = "Insertar Empleado";
            this.btnInsertarEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnInsertarEmpleado.UseVisualStyleBackColor = true;
            this.btnInsertarEmpleado.Click += new System.EventHandler(this.btnInsertar_Click);
            this.btnInsertarEmpleado.MouseLeave += new System.EventHandler(this.btnInsertar_MouseLeave);
            this.btnInsertarEmpleado.MouseHover += new System.EventHandler(this.btnInsertar_MouseHover);
            // 
            // btnEliminarEmpleado
            // 
            this.btnEliminarEmpleado.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnEliminarEmpleado.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btnEliminarEmpleado.FlatAppearance.BorderSize = 0;
            this.btnEliminarEmpleado.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarEmpleado.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnEliminarEmpleado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarEmpleado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btnEliminarEmpleado.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarEmpleado.Image")));
            this.btnEliminarEmpleado.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnEliminarEmpleado.Location = new System.Drawing.Point(570, 0);
            this.btnEliminarEmpleado.Name = "btnEliminarEmpleado";
            this.btnEliminarEmpleado.Size = new System.Drawing.Size(300, 90);
            this.btnEliminarEmpleado.TabIndex = 5;
            this.btnEliminarEmpleado.Text = "Eliminar Empleado";
            this.btnEliminarEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEliminarEmpleado.UseVisualStyleBackColor = true;
            this.btnEliminarEmpleado.Click += new System.EventHandler(this.btnEliminarEmpleado_Click);
            this.btnEliminarEmpleado.MouseLeave += new System.EventHandler(this.btnEliminarEmpleado_MouseLeave);
            this.btnEliminarEmpleado.MouseHover += new System.EventHandler(this.btnEliminarEmpleado_MouseHover);
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
            this.btnEditarEmpleado.Location = new System.Drawing.Point(300, 0);
            this.btnEditarEmpleado.Name = "btnEditarEmpleado";
            this.btnEditarEmpleado.Size = new System.Drawing.Size(270, 90);
            this.btnEditarEmpleado.TabIndex = 6;
            this.btnEditarEmpleado.Text = "Editar Empleado";
            this.btnEditarEmpleado.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnEditarEmpleado.UseVisualStyleBackColor = true;
            this.btnEditarEmpleado.Click += new System.EventHandler(this.btnEditarEmpleado_Click);
            this.btnEditarEmpleado.MouseLeave += new System.EventHandler(this.btnEditarEmpleado_MouseLeave);
            this.btnEditarEmpleado.MouseHover += new System.EventHandler(this.btnEditarEmpleado_MouseHover);
            // 
            // SubMenuEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 90);
            this.Controls.Add(this.panelMenuHorizontal);
            this.Name = "SubMenuEmpleados";
            this.Text = "SubMenuEmpleados";
            this.panelMenuHorizontal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuHorizontal;
        private System.Windows.Forms.Button btnInsertarEmpleado;
        private System.Windows.Forms.Button btnEliminarEmpleado;
        private System.Windows.Forms.Button btnEditarEmpleado;
    }
}