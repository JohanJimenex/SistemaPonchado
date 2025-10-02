namespace SistemaPonchado.Forms
{
    partial class HistorialEmpleadoForm
    {
        private System.ComponentModel.IContainer components = null;
        private DataGridView dgvHistorial;
        private Button btnRefrescar;
        private Button btnAnterior;
        private Button btnSiguiente;
        private Button btnCerrar;
        private ComboBox cmbElementosPorPagina;
        private Label lblPaginacion;
        private Label lblElementosPorPagina;
        private Label lblTitulo;
        private Panel pnlHeader;
        private Panel pnlFooter;
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
            this.pnlHeader = new Panel();
            this.lblTitulo = new Label();
            this.btnCerrar = new Button();
            this.pnlMain = new Panel();
            this.dgvHistorial = new DataGridView();
            this.pnlFooter = new Panel();
            this.lblElementosPorPagina = new Label();
            this.cmbElementosPorPagina = new ComboBox();
            this.btnRefrescar = new Button();
            this.btnAnterior = new Button();
            this.btnSiguiente = new Button();
            this.lblPaginacion = new Label();
            this.pnlHeader.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).BeginInit();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = Color.FromArgb(0, 123, 255);
            this.pnlHeader.Controls.Add(this.btnCerrar);
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new Size(900, 60);
            this.pnlHeader.TabIndex = 0;

            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new Font("Microsoft Sans Serif", 16F, FontStyle.Bold);
            this.lblTitulo.ForeColor = Color.White;
            this.lblTitulo.Location = new Point(20, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new Size(190, 26);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Mi Historial";

            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnCerrar.BackColor = Color.FromArgb(220, 53, 69);
            this.btnCerrar.FlatStyle = FlatStyle.Flat;
            this.btnCerrar.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold);
            this.btnCerrar.ForeColor = Color.White;
            this.btnCerrar.Location = new Point(820, 15);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new Size(70, 30);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.Text = "Cerrar";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new EventHandler(this.btnCerrar_Click);

            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.dgvHistorial);
            this.pnlMain.Dock = DockStyle.Fill;
            this.pnlMain.Location = new Point(0, 60);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new Size(900, 390);
            this.pnlMain.TabIndex = 1;

            // 
            // dgvHistorial
            // 
            this.dgvHistorial.AllowUserToAddRows = false;
            this.dgvHistorial.AllowUserToDeleteRows = false;
            this.dgvHistorial.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHistorial.BackgroundColor = Color.White;
            this.dgvHistorial.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorial.Dock = DockStyle.Fill;
            this.dgvHistorial.Location = new Point(0, 0);
            this.dgvHistorial.MultiSelect = false;
            this.dgvHistorial.Name = "dgvHistorial";
            this.dgvHistorial.ReadOnly = true;
            this.dgvHistorial.RowHeadersVisible = false;
            this.dgvHistorial.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorial.Size = new Size(900, 390);
            this.dgvHistorial.TabIndex = 0;

            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = Color.FromArgb(248, 249, 250);
            this.pnlFooter.BorderStyle = BorderStyle.FixedSingle;
            this.pnlFooter.Controls.Add(this.lblPaginacion);
            this.pnlFooter.Controls.Add(this.btnSiguiente);
            this.pnlFooter.Controls.Add(this.btnAnterior);
            this.pnlFooter.Controls.Add(this.btnRefrescar);
            this.pnlFooter.Controls.Add(this.cmbElementosPorPagina);
            this.pnlFooter.Controls.Add(this.lblElementosPorPagina);
            this.pnlFooter.Dock = DockStyle.Bottom;
            this.pnlFooter.Location = new Point(0, 450);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new Size(900, 50);
            this.pnlFooter.TabIndex = 2;

            // 
            // lblElementosPorPagina
            // 
            this.lblElementosPorPagina.AutoSize = true;
            this.lblElementosPorPagina.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblElementosPorPagina.Location = new Point(20, 16);
            this.lblElementosPorPagina.Name = "lblElementosPorPagina";
            this.lblElementosPorPagina.Size = new Size(102, 15);
            this.lblElementosPorPagina.TabIndex = 0;
            this.lblElementosPorPagina.Text = "Registros por página:";

            // 
            // cmbElementosPorPagina
            // 
            this.cmbElementosPorPagina.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbElementosPorPagina.Font = new Font("Microsoft Sans Serif", 9F);
            this.cmbElementosPorPagina.Location = new Point(130, 13);
            this.cmbElementosPorPagina.Name = "cmbElementosPorPagina";
            this.cmbElementosPorPagina.Size = new Size(60, 23);
            this.cmbElementosPorPagina.TabIndex = 1;
            this.cmbElementosPorPagina.SelectedIndexChanged += new EventHandler(this.cmbElementosPorPagina_SelectedIndexChanged);

            // 
            // btnRefrescar
            // 
            this.btnRefrescar.BackColor = Color.FromArgb(0, 123, 255);
            this.btnRefrescar.FlatStyle = FlatStyle.Flat;
            this.btnRefrescar.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnRefrescar.ForeColor = Color.White;
            this.btnRefrescar.Location = new Point(220, 10);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new Size(80, 30);
            this.btnRefrescar.TabIndex = 2;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = false;
            this.btnRefrescar.Click += new EventHandler(this.btnRefrescar_Click);

            // 
            // lblPaginacion
            // 
            this.lblPaginacion.Anchor = AnchorStyles.Bottom;
            this.lblPaginacion.AutoSize = true;
            this.lblPaginacion.Font = new Font("Microsoft Sans Serif", 9F);
            this.lblPaginacion.Location = new Point(350, 16);
            this.lblPaginacion.Name = "lblPaginacion";
            this.lblPaginacion.Size = new Size(150, 15);
            this.lblPaginacion.TabIndex = 3;
            this.lblPaginacion.Text = "Página 1 de 1 | Total: 0 registros";

            // 
            // btnAnterior
            // 
            this.btnAnterior.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnAnterior.BackColor = Color.FromArgb(108, 117, 125);
            this.btnAnterior.FlatStyle = FlatStyle.Flat;
            this.btnAnterior.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnAnterior.ForeColor = Color.White;
            this.btnAnterior.Location = new Point(720, 10);
            this.btnAnterior.Name = "btnAnterior";
            this.btnAnterior.Size = new Size(80, 30);
            this.btnAnterior.TabIndex = 4;
            this.btnAnterior.Text = "← Anterior";
            this.btnAnterior.UseVisualStyleBackColor = false;
            this.btnAnterior.Click += new EventHandler(this.btnAnterior_Click);

            // 
            // btnSiguiente
            // 
            this.btnSiguiente.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.btnSiguiente.BackColor = Color.FromArgb(108, 117, 125);
            this.btnSiguiente.FlatStyle = FlatStyle.Flat;
            this.btnSiguiente.Font = new Font("Microsoft Sans Serif", 9F);
            this.btnSiguiente.ForeColor = Color.White;
            this.btnSiguiente.Location = new Point(810, 10);
            this.btnSiguiente.Name = "btnSiguiente";
            this.btnSiguiente.Size = new Size(80, 30);
            this.btnSiguiente.TabIndex = 5;
            this.btnSiguiente.Text = "Siguiente →";
            this.btnSiguiente.UseVisualStyleBackColor = false;
            this.btnSiguiente.Click += new EventHandler(this.btnSiguiente_Click);

            // 
            // HistorialEmpleadoForm
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 500);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.MinimumSize = new Size(700, 400);
            this.Name = "HistorialEmpleadoForm";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = "Mi Historial de Ponchados";
            this.FormClosing += new FormClosingEventHandler(this.HistorialEmpleadoForm_FormClosing);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorial)).EndInit();
            this.pnlFooter.ResumeLayout(false);
            this.pnlFooter.PerformLayout();
            this.ResumeLayout(false);
        }
    }
}