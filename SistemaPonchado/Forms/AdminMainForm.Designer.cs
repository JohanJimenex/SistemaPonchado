namespace SistemaPonchado.Forms
{
    partial class AdminMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnGestionEmpleados;
        private Button btnVerPonchados;
        private Button btnCerrarSesion;
        private Label lblBienvenida;
        private Label lblTitulo;
        private Panel pnlHeader;
        private Panel pnlButtons;

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
            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.lblBienvenida = new Label();
            this.btnCerrarSesion = new Button();
            this.pnlButtons = new Panel();
            this.btnGestionEmpleados = new Button();
            this.btnVerPonchados = new Button();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = Color.FromArgb(52, 58, 64);
            this.pnlHeader.Controls.Add(this.btnCerrarSesion);
            this.pnlHeader.Controls.Add(this.lblBienvenida);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(800, 80);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(284, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Panel de Administración";

            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblBienvenida.ForeColor = Color.LightGray;
            this.lblBienvenida.Location = new Point(20, 45);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new Size(108, 17);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido, Admin";

            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrarSesion.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            this.btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = Color.White;
            this.btnCerrarSesion.Location = new Point(680, 25);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new Size(100, 30);
            this.btnCerrarSesion.TabIndex = 3;
            this.btnCerrarSesion.Text = "Cerrar Sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new EventHandler(this.btnCerrarSesion_Click);

            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = Color.White;
            this.pnlButtons.Controls.Add(this.btnVerPonchados);
            this.pnlButtons.Controls.Add(this.btnGestionEmpleados);
            this.pnlButtons.Dock = DockStyle.Fill;
            this.pnlButtons.Location = new Point(0, 80);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new Size(800, 370);
            this.pnlButtons.TabIndex = 1;

            // 
            // btnGestionEmpleados
            // 
            this.btnGestionEmpleados.BackColor = Color.FromArgb(0, 123, 255);
            this.btnGestionEmpleados.FlatStyle = FlatStyle.Flat;
            this.btnGestionEmpleados.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.btnGestionEmpleados.ForeColor = Color.White;
            this.btnGestionEmpleados.Location = new Point(100, 80);
            this.btnGestionEmpleados.Name = "btnGestionEmpleados";
            this.btnGestionEmpleados.Size = new Size(250, 80);
            this.btnGestionEmpleados.TabIndex = 1;
            this.btnGestionEmpleados.Text = "Gestión de Empleados";
            this.btnGestionEmpleados.UseVisualStyleBackColor = false;
            this.btnGestionEmpleados.Click += new EventHandler(this.btnGestionEmpleados_Click);

            // 
            // btnVerPonchados
            // 
            this.btnVerPonchados.BackColor = Color.FromArgb(40, 167, 69);
            this.btnVerPonchados.FlatStyle = FlatStyle.Flat;
            this.btnVerPonchados.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.btnVerPonchados.ForeColor = Color.White;
            this.btnVerPonchados.Location = new Point(450, 80);
            this.btnVerPonchados.Name = "btnVerPonchados";
            this.btnVerPonchados.Size = new Size(250, 80);
            this.btnVerPonchados.TabIndex = 2;
            this.btnVerPonchados.Text = "Ver Todos los Ponchados";
            this.btnVerPonchados.UseVisualStyleBackColor = false;
            this.btnVerPonchados.Click += new EventHandler(this.btnVerPonchados_Click);

            // 
            // AdminMainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.Name = "AdminMainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ponchado - Administración";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}