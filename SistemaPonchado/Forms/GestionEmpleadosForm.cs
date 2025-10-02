using SistemaPonchado.Models;
using SistemaPonchado.Services;

namespace SistemaPonchado.Forms
{
    public partial class GestionEmpleadosForm : Form
    {
        private readonly EmpleadoService _empleadoService;
        private readonly AuthService _authService;
        private List<Empleado> _empleados = new();

        public GestionEmpleadosForm()
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            _authService = new AuthService();
        }

        private async void GestionEmpleadosForm_Load(object sender, EventArgs e)
        {
            await CargarEmpleados();
        }

        private async Task CargarEmpleados(string? filtro = null)
        {
            try
            {
                _empleados = await _empleadoService.ObtenerEmpleados(1, 500, filtro);
                dgvEmpleados.Rows.Clear();
                foreach (var e in _empleados)
                {
                    dgvEmpleados.Rows.Add(
                        e.Id,
                        e.NombreCompleto,
                        e.Cedula,
                        e.Departamento ?? string.Empty,
                        e.Cargo ?? string.Empty,
                        e.Usuario?.NombreUsuario ?? string.Empty,
                        e.Activo ? "Sí" : "No"
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cargando empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Empleado? ObtenerEmpleadoSeleccionado()
        {
            if (dgvEmpleados.SelectedRows.Count == 0) return null;
            var idObj = dgvEmpleados.SelectedRows[0].Cells[0].Value;
            if (idObj == null) return null;
            var id = Convert.ToInt32(idObj);
            return _empleados.FirstOrDefault(x => x.Id == id);
        }

        private async void btnBuscar_Click(object sender, EventArgs e)
        {
            await CargarEmpleados(txtBuscar.Text.Trim());
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            txtBuscar.Clear();
            await CargarEmpleados();
        }

        private async void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var f = new AgregarEmpleadoForm())
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarEmpleados();
                }
            }
        }

        private async void btnEditar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerEmpleadoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Obtener de BD por si falta relación
            var empleado = await _empleadoService.ObtenerEmpleadoPorId(seleccionado.Id);
            if (empleado == null)
            {
                MessageBox.Show("No se encontró el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            using (var f = new EditarEmpleadoForm(empleado))
            {
                if (f.ShowDialog(this) == DialogResult.OK)
                {
                    await CargarEmpleados(txtBuscar.Text.Trim());
                }
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerEmpleadoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show(
                "¿Restablecer contraseña a los últimos 4 dígitos de la cédula?",
                "Confirmar",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (confirm != DialogResult.Yes) return;

            var (exito, passTemp) = await _authService.RestablecerPasswordPorEmpleado(seleccionado.Id);
            if (!exito || passTemp == null)
            {
                MessageBox.Show("No fue posible restablecer la contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Mostrar credenciales con botón copiar
            var usuario = seleccionado.Usuario?.NombreUsuario ?? string.Empty;
            using (var cred = new CredencialesUsuarioForm(usuario, passTemp))
            {
                cred.ShowDialog(this);
            }
        }

        private async void btnDesactivar_Click(object sender, EventArgs e)
        {
            var seleccionado = ObtenerEmpleadoSeleccionado();
            if (seleccionado == null)
            {
                MessageBox.Show("Seleccione un empleado.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var confirm = MessageBox.Show("¿Desactivar este empleado?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            var ok = await _empleadoService.EliminarEmpleado(seleccionado.Id);
            if (ok)
            {
                await CargarEmpleados(txtBuscar.Text.Trim());
            }
            else
            {
                MessageBox.Show("No se pudo desactivar el empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void GestionEmpleadosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _empleadoService?.Dispose();
            _authService?.Dispose();
        }
    }
}
