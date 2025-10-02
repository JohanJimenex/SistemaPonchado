using SistemaPonchado.Models;
using SistemaPonchado.Services;
using SistemaPonchado.Utils;

namespace SistemaPonchado.Forms
{
    public partial class HistorialEmpleadoForm : Form
    {
        private readonly PonchadoService _ponchadoService;
        private readonly int _empleadoId;
        private readonly string _nombreEmpleado;
        private int _paginaActual = 1;
        private int _elementosPorPagina = 20;
        private int _totalElementos = 0;

        public HistorialEmpleadoForm(int empleadoId, string nombreEmpleado)
        {
            InitializeComponent();
            _ponchadoService = new PonchadoService();
            _empleadoId = empleadoId;
            _nombreEmpleado = nombreEmpleado;
            
            lblTitulo.Text = $"Historial de Ponchados - {_nombreEmpleado}";
            this.Text = $"Mi Historial - {_nombreEmpleado}";
            
            ConfigurarComboElementosPorPagina();
            CargarHistorial();
        }

        private void ConfigurarComboElementosPorPagina()
        {
            cmbElementosPorPagina.Items.Clear();
            cmbElementosPorPagina.Items.AddRange(new object[] { 10, 20, 50 });
            cmbElementosPorPagina.SelectedItem = 20;
        }

        private async void CargarHistorial()
        {
            try
            {
                btnRefrescar.Enabled = false;
                btnRefrescar.Text = "Cargando...";

                var ponchados = await _ponchadoService.ObtenerHistorialEmpleado(_empleadoId, _paginaActual, _elementosPorPagina);
                _totalElementos = await _ponchadoService.ContarHistorialEmpleado(_empleadoId);

                // Crear la vista con validación adicional
                var historialView = ponchados.Select(p => new
                {
                    Id = p.Id,
                    Fecha = p.Fecha.ToString("dd/MM/yyyy"),
                    DiaSemana = p.Fecha.ToString("dddd", new System.Globalization.CultureInfo("es-ES")),
                    HoraEntrada = p.HoraEntrada?.ToString("HH:mm:ss") ?? "Sin registro",
                    HoraSalida = p.HoraSalida?.ToString("HH:mm:ss") ?? "Sin registro",
                    TiempoTrabajado = p.TiempoTrabajado?.ToString(@"hh\:mm") ?? "Incompleto",
                    Estado = p.PoncheoCompleto ? "Completo" : "Pendiente"
                }).ToList();

                dgvHistorial.DataSource = historialView;

                ActualizarInfoPaginacion();
                ConfigurarColumnas();
            }
            catch (Exception ex)
            {
                Logger.LogError(ex, "HistorialEmpleadoForm.CargarHistorial");
                MessageBox.Show($"Error cargando historial:\n\n{ex}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnRefrescar.Enabled = true;
                btnRefrescar.Text = "Refrescar";
            }
        }

        private void ConfigurarColumnas()
        {
            if (dgvHistorial.Columns.Count > 0)
            {
                // Verificar y configurar cada columna si existe
                if (dgvHistorial.Columns["Id"] != null)
                    dgvHistorial.Columns["Id"]!.Visible = false;
                
                if (dgvHistorial.Columns["Fecha"] != null)
                {
                    var col = dgvHistorial.Columns["Fecha"]!;
                    col.HeaderText = "Fecha";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 100;
                }
                
                if (dgvHistorial.Columns["DiaSemana"] != null)
                {
                    var col = dgvHistorial.Columns["DiaSemana"]!;
                    col.HeaderText = "Día";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 120;
                }
                
                if (dgvHistorial.Columns["HoraEntrada"] != null)
                {
                    var col = dgvHistorial.Columns["HoraEntrada"]!;
                    col.HeaderText = "Entrada";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 100;
                }
                
                if (dgvHistorial.Columns["HoraSalida"] != null)
                {
                    var col = dgvHistorial.Columns["HoraSalida"]!;
                    col.HeaderText = "Salida";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 100;
                }
                
                if (dgvHistorial.Columns["TiempoTrabajado"] != null)
                {
                    var col = dgvHistorial.Columns["TiempoTrabajado"]!;
                    col.HeaderText = "Tiempo Trabajado";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 120;
                }
                
                if (dgvHistorial.Columns["Estado"] != null)
                {
                    var col = dgvHistorial.Columns["Estado"]!;
                    col.HeaderText = "Estado";
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    col.FillWeight = 100;
                }

                // Colores para diferentes estados (solo si existe la columna)
                var estadoCol = dgvHistorial.Columns["Estado"]; 
                if (estadoCol != null)
                {
                    foreach (DataGridViewRow row in dgvHistorial.Rows)
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
            CargarHistorial();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            if (_paginaActual > 1)
            {
                _paginaActual--;
                CargarHistorial();
            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            _paginaActual++;
            CargarHistorial();
        }

        private void cmbElementosPorPagina_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbElementosPorPagina.SelectedItem != null)
            {
                _elementosPorPagina = (int)cmbElementosPorPagina.SelectedItem;
                _paginaActual = 1;
                CargarHistorial();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HistorialEmpleadoForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ponchadoService?.Dispose();
        }
    }
}
