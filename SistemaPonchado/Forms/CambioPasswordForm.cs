using SistemaPonchado.Services;

namespace SistemaPonchado.Forms
{
    public partial class CambioPasswordForm : Form
    {
        private readonly int _usuarioId;
        private readonly AuthService _authService;

        public CambioPasswordForm(int usuarioId, AuthService authService)
        {
            InitializeComponent();
            _usuarioId = usuarioId;
            _authService = authService;
        }

        private async void btnCambiar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPasswordActual.Text) ||
                string.IsNullOrWhiteSpace(txtPasswordNuevo.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarPassword.Text))
            {
                MessageBox.Show("Todos los campos son requeridos.", "Campos requeridos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPasswordNuevo.Text != txtConfirmarPassword.Text)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtConfirmarPassword.Clear();
                txtConfirmarPassword.Focus();
                return;
            }

            if (txtPasswordNuevo.Text.Length < 6)
            {
                MessageBox.Show("La contraseña debe tener al menos 6 caracteres.", "Contraseña débil", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnCambiar.Enabled = false;
                btnCambiar.Text = "Cambiando...";

                bool exito = await _authService.CambiarPassword(_usuarioId, txtPasswordActual.Text, txtPasswordNuevo.Text);

                if (exito)
                {
                    MessageBox.Show("Contraseña cambiada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("La contraseña actual es incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPasswordActual.Clear();
                    txtPasswordActual.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cambiando la contraseña: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCambiar.Enabled = true;
                btnCambiar.Text = "Cambiar Contraseña";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}