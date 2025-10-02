namespace SistemaPonchado.Forms
{
    partial class AgregarEmpleadoForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtNombre;
        private TextBox txtCedula;
        private TextBox txtDepartamento;
        private TextBox txtCargo;
        private Button btnGuardar;
        private Button btnCancelar;
        private Label lblNombre;
        private Label lblCedula;
        private Label lblDepartamento;
        private Label lblCargo;
        private Label lblTitulo;
        private Label lblErrorNombre;
        private Label lblErrorCedula;
        private Label lblErrorDepartamento;
        private Label lblErrorCargo;
        private Panel pnlMain;

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
            this.pnlMain = new Panel();
            this.lblTitulo = new Label();
            this.lblNombre = new Label();
            this.txtNombre = new TextBox();
            this.lblErrorNombre = new Label();
            this.lblCedula = new Label();
            this.txtCedula = new TextBox();
            this.lblErrorCedula = new Label();
            this.lblDepartamento = new Label();
            this.txtDepartamento = new TextBox();
            this.lblErrorDepartamento = new Label();
            this.lblCargo = new Label();
            this.txtCargo = new TextBox();
            this.lblErrorCargo = new Label();
            this.btnGuardar = new Button();
            this.btnCancelar = new Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.BorderStyle = BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnCancelar);
            this.pnlMain.Controls.Add(this.btnGuardar);
            this.pnlMain.Controls.Add(this.lblErrorCargo);
            this.pnlMain.Controls.Add(this.txtCargo);
            this.pnlMain.Controls.Add(this.lblCargo);
            this.pnlMain.Controls.Add(this.lblErrorDepartamento);
            this.pnlMain.Controls.Add(this.txtDepartamento);
            this.pnlMain.Controls.Add(this.lblDepartamento);
            this.pnlMain.Controls.Add(this.lblErrorCedula);
            this.pnlMain.Controls.Add(this.txtCedula);
            this.pnlMain.Controls.Add(this.lblCedula);
            this.pnlMain.Controls.Add(this.lblErrorNombre);
            this.pnlMain.Controls.Add(this.txtNombre);
            this.pnlMain.Controls.Add(this.lblNombre);
            this.pnlMain.Controls.Add(this.lblTitulo);
            this.pnlMain.Location = new Point(20, 20);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(460, 450);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTitulo.Location = new Point(150, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(160, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Agregar Empleado";

            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblNombre.Location = new Point(30, 70);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new Size(139, 17);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre completo *:";

            // 
            // txtNombre
            // 
            this.txtNombre.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtNombre.Location = new Point(30, 90);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new Size(400, 24);
            this.txtNombre.TabIndex = 1;

            // 
            // lblErrorNombre
            // 
            this.lblErrorNombre.AutoSize = true;
            this.lblErrorNombre.Font = new Font("Microsoft Sans Serif", 8F);
            this.lblErrorNombre.ForeColor = Color.Red;
            this.lblErrorNombre.Location = new Point(30, 117);
            this.lblErrorNombre.Name = "lblErrorNombre";
            this.lblErrorNombre.Size = new Size(0, 13);
            this.lblErrorNombre.TabIndex = 2;
            this.lblErrorNombre.Visible = false;

            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblCedula.Location = new Point(30, 140);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new Size(77, 17);
            this.lblCedula.TabIndex = 3;
            this.lblCedula.Text = "Cédula *:";

            // 
            // txtCedula
            // 
            this.txtCedula.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtCedula.Location = new Point(30, 160);
            this.txtCedula.MaxLength = 11;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.Size = new Size(200, 24);
            this.txtCedula.TabIndex = 2;

            // 
            // lblErrorCedula
            // 
            this.lblErrorCedula.AutoSize = true;
            this.lblErrorCedula.Font = new Font("Microsoft Sans Serif", 8F);
            this.lblErrorCedula.ForeColor = Color.Red;
            this.lblErrorCedula.Location = new Point(30, 187);
            this.lblErrorCedula.Name = "lblErrorCedula";
            this.lblErrorCedula.Size = new Size(0, 13);
            this.lblErrorCedula.TabIndex = 4;
            this.lblErrorCedula.Visible = false;

            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblDepartamento.Location = new Point(30, 210);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new Size(125, 17);
            this.lblDepartamento.TabIndex = 5;
            this.lblDepartamento.Text = "Departamento *:";

            // 
            // txtDepartamento
            // 
            this.txtDepartamento.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtDepartamento.Location = new Point(30, 230);
            this.txtDepartamento.Name = "txtDepartamento";
            this.txtDepartamento.Size = new Size(400, 24);
            this.txtDepartamento.TabIndex = 3;

            // 
            // lblErrorDepartamento
            // 
            this.lblErrorDepartamento.AutoSize = true;
            this.lblErrorDepartamento.Font = new Font("Microsoft Sans Serif", 8F);
            this.lblErrorDepartamento.ForeColor = Color.Red;
            this.lblErrorDepartamento.Location = new Point(30, 257);
            this.lblErrorDepartamento.Name = "lblErrorDepartamento";
            this.lblErrorDepartamento.Size = new Size(0, 13);
            this.lblErrorDepartamento.TabIndex = 6;
            this.lblErrorDepartamento.Visible = false;

            // 
            // lblCargo
            // 
            this.lblCargo.AutoSize = true;
            this.lblCargo.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblCargo.Location = new Point(30, 280);
            this.lblCargo.Name = "lblCargo";
            this.lblCargo.Size = new Size(68, 17);
            this.lblCargo.TabIndex = 7;
            this.lblCargo.Text = "Cargo *:";

            // 
            // txtCargo
            // 
            this.txtCargo.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtCargo.Location = new Point(30, 300);
            this.txtCargo.Name = "txtCargo";
            this.txtCargo.Size = new Size(400, 24);
            this.txtCargo.TabIndex = 4;

            // 
            // lblErrorCargo
            // 
            this.lblErrorCargo.AutoSize = true;
            this.lblErrorCargo.Font = new Font("Microsoft Sans Serif", 8F);
            this.lblErrorCargo.ForeColor = Color.Red;
            this.lblErrorCargo.Location = new Point(30, 327);
            this.lblErrorCargo.Name = "lblErrorCargo";
            this.lblErrorCargo.Size = new Size(0, 13);
            this.lblErrorCargo.TabIndex = 8;
            this.lblErrorCargo.Visible = false;

            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = FlatStyle.Flat;
            this.btnGuardar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            this.btnGuardar.ForeColor = Color.White;
            this.btnGuardar.Location = new Point(130, 380);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new Size(120, 40);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new EventHandler(this.btnGuardar_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(270, 380);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(120, 40);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // 
            // AgregarEmpleadoForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(500, 490);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarEmpleadoForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Agregar Empleado";
            this.FormClosing += new FormClosingEventHandler(this.AgregarEmpleadoForm_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}