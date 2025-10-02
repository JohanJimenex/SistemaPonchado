using SistemaPonchado.Services;
using SistemaPonchado.Models;
using SistemaPonchado.Forms;

namespace SistemaPonchado
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            ConfigurarEventos();
            InicializarBaseDatos();
        }

        private void ConfigurarEventos()
        {
            // Limpiar errores al escribir
            txtUsuario.TextChanged += (s, e) => LimpiarEstilosError();
            txtPassword.TextChanged += (s, e) => LimpiarEstilosError();
        }

        private async void InicializarBaseDatos()
        {
            try
            {
                await _authService.InicializarBaseDatos();
#if DEBUG
                // Sembrar datos de desarrollo: 10 usuarios demo con clave 123
                await _authService.SembrarUsuariosPorDefecto(10);
#endif
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inicializando la base de datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            // Limpiar estilos de error
            LimpiarEstilosError();

            if (!ValidarCampos())
                return;

            try
            {
                btnLogin.Enabled = false;
                btnLogin.Text = "Verificando...";

                var usuario = await _authService.AutenticarUsuario(txtUsuario.Text.Trim(), txtPassword.Text);

                if (usuario != null)
                {
                    if (usuario.RequiereCambioPassword)
                    {
                        // Mostrar formulario de cambio de contraseña
                        var cambioPasswordForm = new CambioPasswordForm(usuario.Id, _authService);
                        if (cambioPasswordForm.ShowDialog() == DialogResult.OK)
                        {
                            AbrirFormularioPrincipal(usuario);
                        }
                        else
                        {
                            // Si cancela el cambio, no permite el login
                            MessageBox.Show("Debe cambiar su contraseña para continuar.", "Cambio de contraseña requerido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        AbrirFormularioPrincipal(usuario);
                    }
                }
                else
                {
                    MostrarErrorCredenciales();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error durante el login: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnLogin.Enabled = true;
                btnLogin.Text = "Iniciar Sesión";
            }
        }

        private bool ValidarCampos()
        {
            bool valido = true;

            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MostrarErrorCampo(txtUsuario, "Usuario requerido");
                valido = false;
            }

            if (string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MostrarErrorCampo(txtPassword, "Contraseña requerida");
                valido = false;
            }

            return valido;
        }

        private void MostrarErrorCampo(TextBox textBox, string mensaje)
        {
            textBox.BackColor = Color.FromArgb(255, 245, 245);
            textBox.BorderStyle = BorderStyle.FixedSingle;
            MessageBox.Show(mensaje, "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            textBox.Focus();
        }

        private void MostrarErrorCredenciales()
        {
            txtUsuario.BackColor = Color.FromArgb(255, 245, 245);
            txtPassword.BackColor = Color.FromArgb(255, 245, 245);
            MessageBox.Show("Usuario o contraseña incorrectos.", "Error de autenticación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtPassword.Clear();
            txtPassword.Focus();
        }

        private void LimpiarEstilosError()
        {
            txtUsuario.BackColor = Color.White;
            txtPassword.BackColor = Color.White;
        }

        private void AbrirFormularioPrincipal(Usuario usuario)
        {
            this.Hide();

            if (usuario.Rol == "Admin")
            {
                var adminForm = new AdminMainForm(usuario);
                adminForm.FormClosed += (s, e) => {
                    // Al cerrar sesión, volver a mostrar el login
                    this.Show();
                    txtPassword.Clear();
                    txtUsuario.Focus();
                };
                adminForm.Show();
            }
            else
            {
                var empleadoForm = new EmpleadoMainForm(usuario);
                empleadoForm.FormClosed += (s, e) => {
                    this.Show();
                    txtPassword.Clear();
                    txtUsuario.Focus();
                };
                empleadoForm.Show();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _authService?.Dispose();
        }
    }
}
