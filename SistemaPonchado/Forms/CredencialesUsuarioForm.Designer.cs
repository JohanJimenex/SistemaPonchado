namespace SistemaPonchado.Forms
{
    partial class CredencialesUsuarioForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox txtContenido;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.Button btnCerrar;

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
            this.txtContenido = new System.Windows.Forms.TextBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // txtContenido
            this.txtContenido.Location = new System.Drawing.Point(12, 12);
            this.txtContenido.Multiline = true;
            this.txtContenido.Name = "txtContenido";
            this.txtContenido.ReadOnly = true;
            this.txtContenido.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtContenido.Size = new System.Drawing.Size(420, 150);
            this.txtContenido.TabIndex = 0;

            // btnCopiar
            this.btnCopiar.Location = new System.Drawing.Point(266, 170);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(80, 28);
            this.btnCopiar.TabIndex = 1;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);

            // btnCerrar
            this.btnCerrar.Location = new System.Drawing.Point(352, 170);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(80, 28);
            this.btnCerrar.TabIndex = 2;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);

            // CredencialesUsuarioForm
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 211);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnCopiar);
            this.Controls.Add(this.txtContenido);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CredencialesUsuarioForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Credenciales";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

