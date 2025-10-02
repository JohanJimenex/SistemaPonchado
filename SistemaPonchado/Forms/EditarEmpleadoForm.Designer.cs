namespace SistemaPonchado.Forms
{
    partial class EditarEmpleadoForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.TextBox txtDepartamento;
        private System.Windows.Forms.TextBox txtCargo;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTitulo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.txtDepartamento = new System.Windows.Forms.TextBox();
            this.txtCargo = new System.Windows.Forms.TextBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // lblTitulo
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(154, 20);
            this.lblTitulo.Text = "Editar Empleado";

            // txtNombre
            this.txtNombre.Location = new System.Drawing.Point(24, 50);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.PlaceholderText = "Nombre completo";
            this.txtNombre.Size = new System.Drawing.Size(360, 23);

            // txtCedula
            this.txtCedula.Location = new System.Drawing.Point(24, 85);
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.PlaceholderText = "Cédula (11 dígitos)";
            this.txtCedula.Size = new System.Drawing.Size(360, 23);

            // txtDepartamento
            this.txtDepartamento.Location = new System.Drawing.Point(24, 120);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.PlaceholderText = "Departamento";
            this.txtDepartamento.Size = new System.Drawing.Size(360, 23);

            // txtCargo
            this.txtCargo.Location = new System.Drawing.Point(24, 155);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.PlaceholderText = "Cargo";
            this.txtCargo.Size = new System.Drawing.Size(360, 23);

            // chkActivo
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(24, 190);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(61, 19);
            this.chkActivo.Text = "Activo";

            // btnGuardar
            this.btnGuardar.Location = new System.Drawing.Point(218, 225);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 30);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);

            // btnCancelar
            this.btnCancelar.Location = new System.Drawing.Point(304, 225);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 30);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);

            // EditarEmpleadoForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(408, 272);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.chkActivo);
            this.Controls.Add(this.txtCargo);
            this.Controls.Add(this.txtDepartamento);
            this.Controls.Add(this.txtCedula);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditarEmpleadoForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Empleado";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EditarEmpleadoForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

