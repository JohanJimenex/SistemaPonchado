namespace SistemaPonchado
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtUsuario;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label lblUsuario;
        private Label lblPassword;
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
            this.lblUsuario = new Label();
            this.txtUsuario = new TextBox();
            this.lblPassword = new Label();
            this.txtPassword = new TextBox();
            this.btnLogin = new Button();
            this.pnlMain.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = Color.White;
            this.pnlMain.BorderStyle = BorderStyle.FixedSingle;
            this.pnlMain.Controls.Add(this.btnLogin);
            this.pnlMain.Controls.Add(this.txtPassword);
            this.pnlMain.Controls.Add(this.lblPassword);
            this.pnlMain.Controls.Add(this.txtUsuario);
            this.pnlMain.Controls.Add(this.lblUsuario);
            this.pnlMain.Controls.Add(this.lblTitulo);
            this.pnlMain.Location = new Point(50, 50);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(350, 280);
            this.pnlMain.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.FromArgb(64, 64, 64);
            this.lblTitulo.Location = new Point(80, 30);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(190, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Sistema Ponchado";

            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblUsuario.Location = new Point(30, 80);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new Size(57, 17);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";

            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtUsuario.Location = new Point(30, 100);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new Size(290, 24);
            this.txtUsuario.TabIndex = 1;

            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new Font("Microsoft Sans Serif", 10F);
            this.lblPassword.Location = new Point(30, 140);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new Size(81, 17);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña:";

            // 
            // txtPassword
            // 
            this.txtPassword.Font = new Font("Microsoft Sans Serif", 11F);
            this.txtPassword.Location = new Point(30, 160);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new Size(290, 24);
            this.txtPassword.TabIndex = 2;
            this.txtPassword.KeyPress += new KeyPressEventHandler(this.txtPassword_KeyPress);

            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = Color.FromArgb(0, 123, 255);
            this.btnLogin.FlatStyle = FlatStyle.Flat;
            this.btnLogin.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);
            this.btnLogin.ForeColor = Color.White;
            this.btnLogin.Location = new Point(30, 210);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new Size(290, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Iniciar Sesión";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new EventHandler(this.btnLogin_Click);

            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(240, 240, 240);
            this.ClientSize = new Size(450, 380);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Sistema de Ponchado - Login";
            this.FormClosing += new FormClosingEventHandler(this.LoginForm_FormClosing);
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}