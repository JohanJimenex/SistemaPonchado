using SistemaPonchado.Models;
using SistemaPonchado.Services;
using SistemaPonchado.Utils;

namespace SistemaPonchado.Forms
{
    public partial class AgregarEmpleadoForm : Form
    {
        private readonly EmpleadoService _empleadoService;

        public AgregarEmpleadoForm()
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            ConfigurarValidaciones();
            ValidarFormulario();
        }

        private void ConfigurarValidaciones()
        {
            // Eventos para validación en tiempo real
            txtNombre.TextChanged += (s, e) => ValidarFormulario();
            txtCedula.TextChanged += (s, e) => ValidarFormulario();
            txtDepartamento.TextChanged += (s, e) => ValidarFormulario();
            txtCargo.TextChanged += (s, e) => ValidarFormulario();

            // Solo números en cédula
            txtCedula.KeyPress += (s, e) =>
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            };

            // Limpiar mensajes de error al enfocar
            txtNombre.Enter += (s, e) => LimpiarError(lblErrorNombre);
            txtCedula.Enter += (s, e) => LimpiarError(lblErrorCedula);
            txtDepartamento.Enter += (s, e) => LimpiarError(lblErrorDepartamento);
            txtCargo.Enter += (s, e) => LimpiarError(lblErrorCargo);
        }

        private void ValidarFormulario()
        {
            bool formularioValido = true;

            // Validar nombre
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MostrarError(lblErrorNombre, "El nombre completo es obligatorio");
                formularioValido = false;
            }
            else if (txtNombre.Text.Trim().Length < 3)
            {
                MostrarError(lblErrorNombre, "El nombre debe tener al menos 3 caracteres");
                formularioValido = false;
            }
            else
            {
                LimpiarError(lblErrorNombre);
            }

            // Validar cédula
            if (string.IsNullOrWhiteSpace(txtCedula.Text))
            {
                MostrarError(lblErrorCedula, "La cédula es obligatoria");
                formularioValido = false;
            }
            else if (txtCedula.Text.Trim().Length != 11)
            {
                MostrarError(lblErrorCedula, "La cédula debe tener exactamente 11 dígitos");
                formularioValido = false;
            }
            else
            {
                LimpiarError(lblErrorCedula);
            }

            // Validar departamento
            if (string.IsNullOrWhiteSpace(txtDepartamento.Text))
            {
                MostrarError(lblErrorDepartamento, "El departamento es obligatorio");
                formularioValido = false;
            }
            else if (txtDepartamento.Text.Trim().Length < 2)
            {
                MostrarError(lblErrorDepartamento, "El departamento debe tener al menos 2 caracteres");
                formularioValido = false;
            }
            else
            {
                LimpiarError(lblErrorDepartamento);
            }

            // Validar cargo
            if (string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MostrarError(lblErrorCargo, "El cargo es obligatorio");
                formularioValido = false;
            }
            else if (txtCargo.Text.Trim().Length < 2)
            {
                MostrarError(lblErrorCargo, "El cargo debe tener al menos 2 caracteres");
                formularioValido = false;
            }
            else
            {
                LimpiarError(lblErrorCargo);
            }

            // Habilitar/deshabilitar botón guardar
            btnGuardar.Enabled = formularioValido;
        }

        private void MostrarError(Label lblError, string mensaje)
        {
            lblError.Text = mensaje;
            lblError.ForeColor = Color.Red;
            lblError.Visible = true;
        }

        private void LimpiarError(Label lblError)
        {
            lblError.Visible = false;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                btnGuardar.Enabled = false;
                btnGuardar.Text = "Guardando...";

                // Validación proactiva de cédula duplicada
                var cedulaIngresada = txtCedula.Text.Trim();
                if (await _empleadoService.ExisteCedula(cedulaIngresada))
                {
                    MostrarError(lblErrorCedula, "Ya existe un empleado con esta cédula");
                    MessageBox.Show("Ya existe un empleado con esta cédula.", "Cédula duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCedula.Focus();
                    return;
                }

                var empleado = new Empleado
                {
                    NombreCompleto = txtNombre.Text.Trim(),
                    Cedula = txtCedula.Text.Trim(),
                    Departamento = txtDepartamento.Text.Trim(),
                    Cargo = txtCargo.Text.Trim(),
                    FechaIngreso = DateTime.Now,
                    Activo = true
                };

                await _empleadoService.CrearEmpleado(empleado);

                // Mostrar credenciales en un cuadro con opción de copiar
                var auth = new AuthService();
                try
                {
                    var usuario = await auth.ObtenerUsuarioPorEmpleadoId(empleado.Id);
                    var nombreUsuario = usuario?.NombreUsuario ?? GenerarNombreUsuario(empleado.NombreCompleto);
                    var password = empleado.Cedula.Length >= 4 ? empleado.Cedula[^4..] : empleado.Cedula;

                    using (var cred = new CredencialesUsuarioForm(nombreUsuario, password))
                    {
                        cred.ShowDialog(this);
                    }
                }
                finally
                {
                    auth.Dispose();
                }
                
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Contains("cédula"))
                {
                    MostrarError(lblErrorCedula, "Ya existe un empleado con esta cédula");
                    MessageBox.Show("Ya existe un empleado con esta cédula.", "Cédula duplicada", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCedula.Focus();
                }
                else
                {
                    MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "AgregarEmpleadoForm.btnGuardar_Click");
                MessageBox.Show($"Error creando empleado:\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Guardar";
                ValidarFormulario(); // Revalidar para habilitar/deshabilitar botón
            }
        }

        private string GenerarNombreUsuario(string nombreCompleto)
        {
            var partes = nombreCompleto.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1]).ToLower();
            }
            return nombreCompleto.Replace(" ", "").ToLower();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void AgregarEmpleadoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _empleadoService?.Dispose();
        }
    }
}
