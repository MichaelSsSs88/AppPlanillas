
namespace AppPlanillas.GUI
{
    partial class PanelVistaUnificacionPorPago
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvConsultas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre_empleado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_extra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hora_doble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_regular = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_extras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_doble = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_deduccion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.estado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1371, 43);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de unificaciones aplicadas al pago seleccionado";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgvConsultas
            // 
            this.dgvConsultas.BackgroundColor = System.Drawing.Color.Cornsilk;
            this.dgvConsultas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConsultas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn27,
            this.dataGridViewTextBoxColumn31,
            this.nombre_empleado,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.hora_extra,
            this.hora_doble,
            this.total_regular,
            this.total_extras,
            this.total_doble,
            this.total_deduccion,
            this.estado,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38});
            this.dgvConsultas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConsultas.GridColor = System.Drawing.Color.Cornsilk;
            this.dgvConsultas.Location = new System.Drawing.Point(0, 43);
            this.dgvConsultas.Margin = new System.Windows.Forms.Padding(4);
            this.dgvConsultas.MultiSelect = false;
            this.dgvConsultas.Name = "dgvConsultas";
            this.dgvConsultas.RowHeadersWidth = 51;
            this.dgvConsultas.RowTemplate.Height = 200;
            this.dgvConsultas.Size = new System.Drawing.Size(1371, 804);
            this.dgvConsultas.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "idUnificacion";
            this.dataGridViewTextBoxColumn27.HeaderText = "Código Unificacion";
            this.dataGridViewTextBoxColumn27.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.Width = 125;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "IdEmpleado";
            this.dataGridViewTextBoxColumn31.HeaderText = "Empleado";
            this.dataGridViewTextBoxColumn31.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.Width = 125;
            // 
            // nombre_empleado
            // 
            this.nombre_empleado.DataPropertyName = "Nombre";
            this.nombre_empleado.HeaderText = "Nombre Empleado";
            this.nombre_empleado.MinimumWidth = 6;
            this.nombre_empleado.Name = "nombre_empleado";
            this.nombre_empleado.Width = 125;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "fecha_inicio";
            this.dataGridViewTextBoxColumn28.HeaderText = "Fecha inicio";
            this.dataGridViewTextBoxColumn28.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.Width = 125;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "fecha_fin";
            this.dataGridViewTextBoxColumn29.HeaderText = "Fecha fin";
            this.dataGridViewTextBoxColumn29.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.Width = 125;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "hora_regular";
            this.dataGridViewTextBoxColumn30.HeaderText = "Horas regulares";
            this.dataGridViewTextBoxColumn30.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.Width = 125;
            // 
            // hora_extra
            // 
            this.hora_extra.DataPropertyName = "hora_extra";
            this.hora_extra.HeaderText = "Horas extras";
            this.hora_extra.MinimumWidth = 6;
            this.hora_extra.Name = "hora_extra";
            this.hora_extra.Width = 125;
            // 
            // hora_doble
            // 
            this.hora_doble.DataPropertyName = "hora_doble";
            this.hora_doble.HeaderText = "Horas dobles";
            this.hora_doble.MinimumWidth = 6;
            this.hora_doble.Name = "hora_doble";
            this.hora_doble.Width = 125;
            // 
            // total_regular
            // 
            this.total_regular.DataPropertyName = "total_regular";
            this.total_regular.HeaderText = "Total Regular";
            this.total_regular.MinimumWidth = 6;
            this.total_regular.Name = "total_regular";
            this.total_regular.Width = 125;
            // 
            // total_extras
            // 
            this.total_extras.DataPropertyName = "total_extra";
            this.total_extras.HeaderText = "Total Extras";
            this.total_extras.MinimumWidth = 6;
            this.total_extras.Name = "total_extras";
            this.total_extras.Width = 125;
            // 
            // total_doble
            // 
            this.total_doble.DataPropertyName = "total_doble";
            this.total_doble.HeaderText = "Total Dobles";
            this.total_doble.MinimumWidth = 6;
            this.total_doble.Name = "total_doble";
            this.total_doble.Width = 125;
            // 
            // total_deduccion
            // 
            this.total_deduccion.DataPropertyName = "total_deduccion";
            this.total_deduccion.HeaderText = "Total Deducciones";
            this.total_deduccion.MinimumWidth = 6;
            this.total_deduccion.Name = "total_deduccion";
            this.total_deduccion.Width = 125;
            // 
            // estado
            // 
            this.estado.DataPropertyName = "estado";
            this.estado.HeaderText = "Estado";
            this.estado.MinimumWidth = 6;
            this.estado.Name = "estado";
            this.estado.Width = 125;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "creadoPor";
            this.dataGridViewTextBoxColumn35.HeaderText = "Creador";
            this.dataGridViewTextBoxColumn35.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.Width = 125;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "fechaCreacion";
            this.dataGridViewTextBoxColumn36.HeaderText = "Fecha de Creacion";
            this.dataGridViewTextBoxColumn36.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.Width = 125;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "modificadoPor";
            this.dataGridViewTextBoxColumn37.HeaderText = "Modificador";
            this.dataGridViewTextBoxColumn37.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.Width = 125;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.DataPropertyName = "fechaModificacion";
            this.dataGridViewTextBoxColumn38.HeaderText = "Fecha de Modificacion";
            this.dataGridViewTextBoxColumn38.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.Width = 125;
            // 
            // PanelVistaUnificacionPorPago
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1371, 847);
            this.Controls.Add(this.dgvConsultas);
            this.Controls.Add(this.label1);
            this.Name = "PanelVistaUnificacionPorPago";
            this.Text = "PanelVistaUnificacionPorPago";
            ((System.ComponentModel.ISupportInitialize)(this.dgvConsultas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvConsultas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre_empleado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_extra;
        private System.Windows.Forms.DataGridViewTextBoxColumn hora_doble;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_regular;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_extras;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_doble;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_deduccion;
        private System.Windows.Forms.DataGridViewTextBoxColumn estado;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
    }
}