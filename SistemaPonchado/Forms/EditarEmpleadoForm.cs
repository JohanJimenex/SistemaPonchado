using SistemaPonchado.Models;
using SistemaPonchado.Services;

namespace SistemaPonchado.Forms
{
    public partial class EditarEmpleadoForm : Form
    {
        private readonly EmpleadoService _empleadoService;
        private Empleado _empleado;

        public EditarEmpleadoForm(Empleado empleado)
        {
            InitializeComponent();
            _empleadoService = new EmpleadoService();
            _empleado = empleado;
            CargarDatos();
        }

        private void CargarDatos()
        {
            txtNombre.Text = _empleado.NombreCompleto;
            txtCedula.Text = _empleado.Cedula;
            txtDepartamento.Text = _empleado.Departamento ?? string.Empty;
            txtCargo.Text = _empleado.Cargo ?? string.Empty;
            chkActivo.Checked = _empleado.Activo;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
                string.IsNullOrWhiteSpace(txtCedula.Text) ||
                string.IsNullOrWhiteSpace(txtDepartamento.Text) ||
                string.IsNullOrWhiteSpace(txtCargo.Text))
            {
                MessageBox.Show("Todos los campos marcados son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtCedula.Text.Trim().Length != 11)
            {
                MessageBox.Show("La cédula debe tener exactamente 11 dígitos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnGuardar.Enabled = false;
                btnGuardar.Text = "Guardando...";

                _empleado.NombreCompleto = txtNombre.Text.Trim();
                _empleado.Cedula = txtCedula.Text.Trim();
                _empleado.Departamento = txtDepartamento.Text.Trim();
                _empleado.Cargo = txtCargo.Text.Trim();
                _empleado.Activo = chkActivo.Checked;

                var ok = await _empleadoService.ActualizarEmpleado(_empleado);
                if (ok)
                {
                    MessageBox.Show("Empleado actualizado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error actualizando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnGuardar.Enabled = true;
                btnGuardar.Text = "Guardar";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void EditarEmpleadoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _empleadoService?.Dispose();
        }
    }
}

