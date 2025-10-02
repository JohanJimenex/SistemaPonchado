namespace SistemaPonchado.Forms
{
    partial class CambioPasswordForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtPasswordActual;
        private TextBox txtPasswordNuevo;
        private TextBox txtConfirmarPassword;
        private Button btnCambiar;
        private Button btnCancelar;
        private Label lblPasswordActual;
        private Label lblPasswordNuevo;
        private Label lblConfirmarPassword;
        private Label lblTitulo;
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
            this.lblPasswordActual = new Label();
            this.txtPasswordActual = new TextBox();
            this.lblPasswordNuevo = new Label();
            this.txtPasswordNuevo = new TextBox();
            this.lblConfirmarPassword = new Label();
            this.txtConfirmarPassword = new TextBox();
            this.btnCambiar = new Button();
            this.btnCancelar = new Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.BorderStyle = BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnCancelar);
            this.pnlMain.Controls.Add(this.btnCambiar);
            this.pnlMain.Controls.Add(this.txtConfirmarPassword);
            this.pnlMain.Controls.Add(this.lblConfirmarPassword);
            this.pnlMain.Controls.Add(this.txtPasswordNuevo);
            this.pnlMain.Controls.Add(this.lblPasswordNuevo);
            this.pnlMain.Controls.Add(this.txtPasswordActual);
            this.pnlMain.Controls.Add(this.lblPasswordActual);
            this.pnlMain.Controls.Add(this.lblTitulo);
            this.pnlMain.Location = new Point(20, 20);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(400, 350);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 14F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTitulo.Location = new Point(100, 20);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(200, 24);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cambiar Contraseña";

            // 
            // lblPasswordActual
            // 
            this.lblPasswordActual.AutoSize = true;
            this.lblPasswordActual.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblPasswordActual.Location = new Point(30, 70);
            this.lblPasswordActual.Name = "lblPasswordActual";
            this.lblPasswordActual.Size = new Size(120, 17);
            this.lblPasswordActual.TabIndex = 1;
            this.lblPasswordActual.Text = "Contraseña actual:";

            // 
            // txtPasswordActual
            // 
            this.txtPasswordActual.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtPasswordActual.Location = new Point(30, 90);
            this.txtPasswordActual.Name = "txtPasswordActual";
            this.txtPasswordActual.PasswordChar = '*';
            this.txtPasswordActual.Size = new Size(340, 24);
            this.txtPasswordActual.TabIndex = 1;

            // 
            // lblPasswordNuevo
            // 
            this.lblPasswordNuevo.AutoSize = true;
            this.lblPasswordNuevo.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblPasswordNuevo.Location = new Point(30, 130);
            this.lblPasswordNuevo.Name = "lblPasswordNuevo";
            this.lblPasswordNuevo.Size = new Size(118, 17);
            this.lblPasswordNuevo.TabIndex = 3;
            this.lblPasswordNuevo.Text = "Contraseña nueva:";

            // 
            // txtPasswordNuevo
            // 
            this.txtPasswordNuevo.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtPasswordNuevo.Location = new Point(30, 150);
            this.txtPasswordNuevo.Name = "txtPasswordNuevo";
            this.txtPasswordNuevo.PasswordChar = '*';
            this.txtPasswordNuevo.Size = new Size(340, 24);
            this.txtPasswordNuevo.TabIndex = 2;

            // 
            // lblConfirmarPassword
            // 
            this.lblConfirmarPassword.AutoSize = true;
            this.lblConfirmarPassword.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblConfirmarPassword.Location = new Point(30, 190);
            this.lblConfirmarPassword.Name = "lblConfirmarPassword";
            this.lblConfirmarPassword.Size = new Size(148, 17);
            this.lblConfirmarPassword.TabIndex = 5;
            this.lblConfirmarPassword.Text = "Confirmar contraseña:";

            // 
            // txtConfirmarPassword
            // 
            this.txtConfirmarPassword.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtConfirmarPassword.Location = new Point(30, 210);
            this.txtConfirmarPassword.Name = "txtConfirmarPassword";
            this.txtConfirmarPassword.PasswordChar = '*';
            this.txtConfirmarPassword.Size = new Size(340, 24);
            this.txtConfirmarPassword.TabIndex = 3;

            // 
            // btnCambiar
            // 
            this.btnCambiar.BackColor = Color.FromArgb(40, 167, 69);
            this.btnCambiar.FlatStyle = FlatStyle.Flat;
            this.btnCambiar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnCambiar.ForeColor = Color.White;
            this.btnCambiar.Location = new Point(30, 270);
            this.btnCambiar.Name = "btnCambiar";
            this.btnCambiar.Size = new Size(160, 40);
            this.btnCambiar.TabIndex = 4;
            this.btnCambiar.Text = "Cambiar Contraseña";
            this.btnCambiar.UseVisualStyleBackColor = false;
            this.btnCambiar.Click += new EventHandler(this.btnCambiar_Click);

            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = Color.FromArgb(108, 117, 125);
            this.btnCancelar.FlatStyle = FlatStyle.Flat;
            this.btnCancelar.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Bold);
            this.btnCancelar.ForeColor = Color.White;
            this.btnCancelar.Location = new Point(210, 270);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new Size(160, 40);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new EventHandler(this.btnCancelar_Click);

            // 
            // CambioPasswordForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(440, 390);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CambioPasswordForm";
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = "Cambiar Contraseña";
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}