using SistemaPonchado.Models;
using SistemaPonchado.Services;
using SistemaPonchado.Utils;

namespace SistemaPonchado.Forms
{
    public partial class VerPonchadosForm : Form
    {
        private readonly PonchadoService _ponchadoService;
        private int _paginaActual = 1;
        private int _elementosPorPagina = 20;
        private int _totalElementos = 0;
        private bool _mostroAvisoVacio = false;

        public VerPonchadosForm()
        {
            InitializeComponent();
            _ponchadoService = new PonchadoService();
            ConfigurarComboElementosPorPagina();
            CargarPonchados();
        }

        private void ConfigurarComboElementosPorPagina()
        {
            cmbElementosPorPagina.Items.Clear();
            cmbElementosPorPagina.Items.AddRange(new object[] { 10, 20, 50 });
            cmbElementosPorPagina.SelectedItem = 20;
        }

        private async void CargarPonchados()
        {
            try
            {
                btnRefrescar.Enabled = false;
                btnRefrescar.Text = "Cargando...";

                var ponchados = await _ponchadoService.ObtenerTodosPonchados(_paginaActual, _elementosPorPagina);
                _totalElementos = await _ponchadoService.ContarTodosPonchados();

                // Filtrar ponchados que tengan empleado válido y crear la vista
                var ponchadosView = ponchados
                    .Select(p => new
                    {
                        Id = p.Id,
                        Empleado = p.Empleado != null ? (p.Empleado.NombreCompleto ?? "Sin nombre") : "Sin nombre",
                        Cedula = p.Empleado != null ? (p.Empleado.Cedula ?? "Sin cédula") : "Sin cédula",
                        Fecha = p.Fecha.ToString("dd/MM/yyyy"),
                        HoraEntrada = p.HoraEntrada?.ToString("HH:mm:ss") ?? "Sin registro",
                        HoraSalida = p.HoraSalida?.ToString("HH:mm:ss") ?? "Sin registro",
                        TiempoTrabajado = p.TiempoTrabajado?.ToString(@"hh\:mm") ?? "Incompleto",
                        Estado = p.PoncheoCompleto ? "Completo" : "Pendiente"
                    }).ToList();

                dgvPonchados.DataSource = ponchadosView;

                if (ponchadosView.Count == 0 && !_mostroAvisoVacio)
                {
                    MessageBox.Show("No hay ponchados registrados aún.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _mostroAvisoVacio = true;
                }

                ActualizarInfoPaginacion();
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "VerPonchadosForm.CargarPonchados");
                MessageBox.Show($"Error cargando ponchados:\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefrescar.Enabled = true;
                btnRefrescar.Text = "Refrescar";
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvPonchados.Columns.Count > 0)
            {
                // Verificar y configurar cada columna si existe
                if (dgvPonchados.Columns["Id"] != null)
                    dgvPonchados.Columns["Id"]!.Visible = false;
                
                if (dgvPonchados.Columns["Empleado"] != null)
                {
                    var col = dgvPonchados.Columns["Empleado"]!;
                    col.HeaderText = "Empleado";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 200;
                }
                
                if (dgvPonchados.Columns["Cedula"] != null)
                {
                    var col = dgvPonchados.Columns["Cedula"]!;
                    col.HeaderText = "Cédula";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 90;
                }
                
                if (dgvPonchados.Columns["Fecha"] != null)
                {
                    var col = dgvPonchados.Columns["Fecha"]!;
                    col.HeaderText = "Fecha";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 80;
                }
                
                if (dgvPonchados.Columns["HoraEntrada"] != null)
                {
                    var col = dgvPonchados.Columns["HoraEntrada"]!;
                    col.HeaderText = "Entrada";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 80;
                }
                
                if (dgvPonchados.Columns["HoraSalida"] != null)
                {
                    var col = dgvPonchados.Columns["HoraSalida"]!;
                    col.HeaderText = "Salida";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 80;
                }
                
                if (dgvPonchados.Columns["TiempoTrabajado"] != null)
                {
                    var col = dgvPonchados.Columns["TiempoTrabajado"]!;
                    col.HeaderText = "Tiempo Trabajado";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 120;
                }
                
                if (dgvPonchados.Columns["Estado"] != null)
                {
                    var col = dgvPonchados.Columns["Estado"]!;
                    col.HeaderText = "Estado";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 80;
                }

                // Colores para diferentes estados (solo si existe la columna)
                var estadoCol = dgvPonchados.Columns["Estado"]; 
                if (estadoCol != null)
                {
                    foreach (DataGridViewRow row in dgvPonchados.Rows)
                    {
                        var estadoCell = row.Cells["Estado"];
                        var estado = estadoCell != null ? (estadoCell.Value?.ToString()) : null;
                        if (estado == "Completo")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(240, 255, 240); // Verde claro
                        }
                        else if (estado == "Pendiente")
                        {
                            row.DefaultCellStyle.BackColor = Color.FromArgb(255, 248, 220); // Amarillo claro
                        }
                    }
                }
            }
        }

        private void ActualizarInfoPaginacion()
        {
            int totalPaginas = (int)Math.Ceiling((double)_totalElementos / _elementosPorPagina);
            lblPaginacion.Text = $"Página {_paginaActual} de {totalPaginas} | Total: {_totalElementos} registros";

            btnAnterior.Enabled = _paginaActual > 1;
            btnSiguiente.Enabled = _paginaActual < totalPaginas;
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarPonchados();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                CargarPonchados();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _paginaActual++;
            CargarPonchados();
        }

        private void cmbElementosPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElementosPorPagina.SelectedItem != null)
            {
                _elementosPorPagina = (int)cmbElementosPorPagina.SelectedItem;
                _paginaActual = 1;
                CargarPonchados();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void VerPonchadosForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ponchadoService?.Dispose();
        }
    }
}
