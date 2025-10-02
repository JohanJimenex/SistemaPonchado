// 👨‍💼 FORMULARIO PRINCIPAL DEL EMPLEADO
// Esta ventana es lo que ve un empleado cuando inicia sesión

using SistemaPonchado.Models;
using SistemaPonchado.Services;

namespace SistemaPonchado.Forms
{
    // 💡 CONCEPTO: Este formulario hereda de Form (clase base de Windows Forms)
    public partial class EmpleadoMainForm : Form
    {
        // 📦 VARIABLES PRIVADAS
        // Solo esta clase puede acceder a estas variables
        private readonly Usuario _usuario; // Datos del usuario logueado
        private readonly PonchadoService _ponchadoService; // Servicio para manejar ponchados

        /// <summary>
        /// 🏗️ CONSTRUCTOR
        /// Se ejecuta cuando se crea una nueva instancia de este formulario
        /// </summary>
        /// <param name="usuario">El usuario que inició sesión</param>
        public EmpleadoMainForm(Usuario usuario)
        {
            // 🎨 Inicializar componentes visuales (botones, labels, etc.)
            InitializeComponent();
            
            // 💾 Guardar referencias para usar en otros métodos
            _usuario = usuario;
            _ponchadoService = new PonchadoService();
            
            // 👋 Mostrar mensaje de bienvenida personalizado
            lblBienvenida.Text = $"Bienvenido, {_usuario.Empleado?.NombreCompleto ?? _usuario.NombreUsuario}";
            
            // 🔄 Verificar estado actual del ponchado (entrada/salida)
            ActualizarEstadoPonchado();
        }

        /// <summary>
        /// 🔄 ACTUALIZAR ESTADO DEL BOTÓN DE PONCHADO
        /// Verifica si el empleado ya registró entrada hoy y cambia el botón correspondiente
        /// </summary>
        private async void ActualizarEstadoPonchado()
        {
            try
            {
                // ✅ Verificar que el usuario tenga un empleado asociado
                if (_usuario.EmpleadoId.HasValue)
                {
                    // 🔍 Buscar si hay un ponchado para hoy
                    var ponchadoHoy = await _ponchadoService.ObtenerPonchadoHoy(_usuario.EmpleadoId.Value);
                    
                    if (ponchadoHoy == null)
                    {
                        // 📥 No hay ponchado hoy → Mostrar botón de ENTRADA
                        btnPonchar.Text = "ENTRADA";
                        btnPonchar.BackColor = Color.FromArgb(40, 167, 69); // Verde
                    }
                    else if (!ponchadoHoy.HoraSalida.HasValue)
                    {
                        // 📤 Ya registró entrada → Mostrar botón de SALIDA
                        btnPonchar.Text = "SALIDA";
                        btnPonchar.BackColor = Color.FromArgb(220, 53, 69); // Rojo
                    }
                    else
                    {
                        // ✅ Ya completó entrada y salida → Botón deshabilitado
                        btnPonchar.Text = "COMPLETADO";
                        btnPonchar.BackColor = Color.FromArgb(108, 117, 125); // Gris
                        btnPonchar.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                // 🚨 MANEJO DE ERRORES
                // Si algo sale mal, mostrar mensaje al usuario
                MessageBox.Show($"Error verificando estado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 🕐 EVENTO: CLICK EN BOTÓN PONCHAR
        /// Este método se ejecuta cuando el empleado hace click en el botón principal
        /// Maneja tanto entrada como salida según el estado actual
        /// </summary>
        private async void btnPonchar_Click(object sender, EventArgs e)
        {
            // 🔒 Validación de seguridad
            if (!_usuario.EmpleadoId.HasValue)
            {
                MessageBox.Show("Error: No se encontró información del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // 🚫 Deshabilitar botón para evitar doble click
                btnPonchar.Enabled = false;

                // 🔍 Verificar estado actual del ponchado
                var ponchadoHoy = await _ponchadoService.ObtenerPonchadoHoy(_usuario.EmpleadoId.Value);
                
                if (ponchadoHoy == null)
                {
                    // 📥 CASO 1: No hay ponchado hoy → REGISTRAR ENTRADA
                    var ponchado = await _ponchadoService.RegistrarEntrada(_usuario.EmpleadoId.Value);
                    MessageBox.Show($"Entrada registrada: {ponchado.HoraEntrada:HH:mm:ss}", "Entrada Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (!ponchadoHoy.HoraSalida.HasValue)
                {
                    // 📤 CASO 2: Ya tiene entrada → REGISTRAR SALIDA
                    MessageBox.Show($"Registrando salida para empleado ID: {_usuario.EmpleadoId.Value}", "Debug", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    var ponchado = await _ponchadoService.RegistrarSalida(_usuario.EmpleadoId.Value);
                    var tiempoTrabajado = ponchado.TiempoTrabajado;
                    var mensaje = $"Salida registrada: {ponchado.HoraSalida:HH:mm:ss}";
                    
                    // 📊 Mostrar tiempo trabajado si está disponible
                    if (tiempoTrabajado.HasValue)
                    {
                        mensaje += $"\nTiempo trabajado: {tiempoTrabajado.Value.Hours:D2}:{tiempoTrabajado.Value.Minutes:D2}";
                    }
                    MessageBox.Show(mensaje, "Salida Registrada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // ✅ CASO 3: Ya está completo el ponchado
                    MessageBox.Show("El ponchado para hoy ya está completo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 🔄 Actualizar el estado del botón después de la operación
                ActualizarEstadoPonchado();
            }
            catch (Exception ex)
            {
                // 🚨 MANEJO DE ERRORES CON INFORMACIÓN DETALLADA
                MessageBox.Show($"Error registrando ponchado: {ex.Message}\n\nStackTrace: {ex.StackTrace}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 🔓 SIEMPRE volver a habilitar el botón (incluso si hay error)
                btnPonchar.Enabled = true;
            }
        }

        /// <summary>
        /// 📊 VER HISTORIAL PERSONAL
        /// Abre una ventana con el historial de ponchados del empleado
        /// </summary>
        private void btnVerHistorial_Click(object sender, EventArgs e)
        {
            // 🔒 Validación de seguridad
            if (!_usuario.EmpleadoId.HasValue)
            {
                MessageBox.Show("Error: No se encontró información del empleado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 👤 Obtener nombre para mostrar en la ventana
            var nombreEmpleado = _usuario.Empleado?.NombreCompleto ?? _usuario.NombreUsuario;
            
            // 🖼️ Abrir ventana de historial como diálogo modal
            using (var historialForm = new HistorialEmpleadoForm(_usuario.EmpleadoId.Value, nombreEmpleado))
            {
                historialForm.ShowDialog(); // Bloquea esta ventana hasta que se cierre la otra
            }
        }

        /// <summary>
        /// 🚪 CERRAR SESIÓN
        /// Cierra esta ventana y regresa al login
        /// </summary>
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            this.Close(); // Cierra esta ventana
        }

        /// <summary>
        /// 🧹 LIMPIEZA AL CERRAR
        /// Se ejecuta cuando se está cerrando la ventana
        /// Libera recursos para evitar memory leaks
        /// </summary>
        private void EmpleadoMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 🗑️ Liberar recursos del servicio de ponchado
            _ponchadoService?.Dispose();
        }
        
        // 🎯 CONCEPTOS CLAVE EN ESTE ARCHIVO:
        // - Event Handlers (métodos que responden a clicks)
        // - Async/Await (para operaciones de base de datos)
        // - Try-Catch-Finally (manejo de errores)
        // - Using statements (liberar recursos automáticamente)
        // - Null conditional operators (?.) para evitar null reference
        // - String interpolation ($"texto {variable}")
    }
}