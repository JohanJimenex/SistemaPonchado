using SistemaPonchado.Models;

namespace SistemaPonchado.Forms
{
    public partial class AdminMainForm : Form
    {
        private readonly Usuario _usuario;

        public AdminMainForm(Usuario usuario)
        {
            InitializeComponent();
            _usuario = usuario;
            lblBienvenida.Text = $"Bienvenido, {_usuario.NombreUsuario}";
        }

        private void btnGestionEmpleados_Click(object sender, EventArgs e)
        {
            var agregarEmpleadoForm = new AgregarEmpleadoForm();
            if (agregarEmpleadoForm.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("Empleado agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnVerPonchados_Click(object sender, EventArgs e)
        {
            var verPonchadosForm = new VerPonchadosForm();
            verPonchadosForm.ShowDialog();
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}