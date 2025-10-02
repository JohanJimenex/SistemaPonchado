namespace SistemaPonchado.Forms
{
    partial class EmpleadoMainForm
    {
        private System.ComponentModel.IContainer components = null;
        private Button btnPonchar;
        private Button btnVerHistorial;
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
            this.btnPonchar = new Button();
            this.btnVerHistorial = new Button();
            this.pnlHeader.SuspendLayout();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = Color.FromArgb(0, 123, 255);
            this.pnlHeader.Controls.Add(this.btnCerrarSesion);
            this.pnlHeader.Controls.Add(this.lblBienvenida);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(700, 80);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(20, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(190, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema Ponchado";

            // 
            // lblBienvenida
            // 
            this.lblBienvenida.AutoSize = true;
            this.lblBienvenida.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblBienvenida.ForeColor = Color.LightBlue;
            this.lblBienvenida.Location = new Point(20, 45);
            this.lblBienvenida.Name = "lblBienvenida";
            this.lblBienvenida.Size = new Size(120, 17);
            this.lblBienvenida.TabIndex = 1;
            this.lblBienvenida.Text = "Bienvenido, Empleado";

            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrarSesion.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrarSesion.FlatStyle = FlatStyle.Flat;
            this.btnCerrarSesion.Font = new Font("Microsoft Sans Serif", 8F, FontStyle.Bold);
            this.btnCerrarSesion.ForeColor = Color.White;
            this.btnCerrarSesion.Location = new Point(580, 25);
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
            this.pnlButtons.Controls.Add(this.btnVerHistorial);
            this.pnlButtons.Controls.Add(this.btnPonchar);
            this.pnlButtons.Dock = DockStyle.Fill;
            this.pnlButtons.Location = new Point(0, 80);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new Size(700, 320);
            this.pnlButtons.TabIndex = 1;

            // 
            // btnPonchar
            // 
            this.btnPonchar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnPonchar.FlatStyle = FlatStyle.Flat;
            this.btnPonchar.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.btnPonchar.ForeColor = Color.White;
            this.btnPonchar.Location = new Point(100, 60);
            this.btnPonchar.Name = "btnPonchar";
            this.btnPonchar.Size = new Size(200, 80);
            this.btnPonchar.TabIndex = 1;
            this.btnPonchar.Text = "PONCHAR";
            this.btnPonchar.UseVisualStyleBackColor = false;
            this.btnPonchar.Click += new EventHandler(this.btnPonchar_Click);

            // 
            // btnVerHistorial
            // 
            this.btnVerHistorial.BackColor = Color.FromArgb(108, 117, 125);
            this.btnVerHistorial.FlatStyle = FlatStyle.Flat;
            this.btnVerHistorial.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold);
            this.btnVerHistorial.ForeColor = Color.White;
            this.btnVerHistorial.Location = new Point(400, 60);
            this.btnVerHistorial.Name = "btnVerHistorial";
            this.btnVerHistorial.Size = new Size(200, 80);
            this.btnVerHistorial.TabIndex = 2;
            this.btnVerHistorial.Text = "Ver Mi Historial";
            this.btnVerHistorial.UseVisualStyleBackColor = false;
            this.btnVerHistorial.Click += new EventHandler(this.btnVerHistorial_Click);

            // 
            // EmpleadoMainForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(700, 400);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.pnlHeader);
            this.Name = "EmpleadoMainForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ponchado - Empleado";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }
    }
}