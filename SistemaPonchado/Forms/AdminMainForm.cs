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
            using (var gestion = new GestionEmpleadosForm())
            {
                gestion.ShowDialog(this);
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
