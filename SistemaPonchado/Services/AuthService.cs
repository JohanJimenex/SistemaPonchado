// 🔐 SERVICIO DE AUTENTICACIÓN
// Este servicio maneja todo lo relacionado con login, registro y autenticación

using SistemaPonchado.Data;
using SistemaPonchado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPonchado.Services
{
    // 💡 CONCEPTO: Un "Service" contiene la lógica de negocio
    // Separamos la lógica de los formularios para mantener el código organizado
    public class AuthService
    {
        // 🗄️ CONTEXTO DE BASE DE DATOS
        // Esta es nuestra conexión a la base de datos SQLite
        private readonly SistemaPonchadoContext _context;

        // 🏗️ CONSTRUCTOR: Se ejecuta cuando creamos una nueva instancia
        public AuthService()
        {
            _context = new SistemaPonchadoContext();
        }

        /// <summary>
        /// 🔍 AUTENTICAR USUARIO
        /// Verifica si el usuario y contraseña son correctos
        /// </summary>
        /// <param name="nombreUsuario">Nombre de usuario ingresado</param>
        /// <param name="password">Contraseña en texto plano</param>
        /// <returns>Usuario si es válido, null si no lo es</returns>
        public async Task<Usuario?> AutenticarUsuario(string nombreUsuario, string password)
        {
            // 🔎 BUSCAR USUARIO EN BASE DE DATOS
            // Include() carga también los datos del empleado relacionado
            var usuario = await _context.Usuarios
                .Include(u => u.Empleado) // 💡 Esto carga los datos del empleado automáticamente
                .FirstOrDefaultAsync(u => u.NombreUsuario == nombreUsuario && u.Activo);

            // 🔒 VERIFICAR CONTRASEÑA
            // BCrypt compara la contraseña en texto plano con la encriptada
            if (usuario != null && BCrypt.Net.BCrypt.Verify(password, usuario.Password))
            {
                return usuario; // ✅ Login exitoso
            }

            return null; // ❌ Credenciales incorrectas
        }

        /// <summary>
        /// 🔄 CAMBIAR CONTRASEÑA
        /// Permite al usuario cambiar su contraseña actual
        /// </summary>
        public async Task<bool> CambiarPassword(int usuarioId, string passwordAnterior, string passwordNuevo)
        {
            var usuario = await _context.Usuarios.FindAsync(usuarioId);
            if (usuario == null)
                return false;

            // Verificar password anterior
            if (!BCrypt.Net.BCrypt.Verify(passwordAnterior, usuario.Password))
                return false;

            // Actualizar password
            usuario.Password = BCrypt.Net.BCrypt.HashPassword(passwordNuevo);
            usuario.RequiereCambioPassword = false;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Usuario?> CrearUsuarioEmpleado(Empleado empleado)
        {
            // Generar nombre de usuario único
            var baseUsername = GenerarNombreUsuario(empleado.NombreCompleto);
            var uniqueUsername = await AsegurarNombreUsuarioUnico(baseUsername);

            // Asegurar password a partir de últimos 4 dígitos de cédula
            string last4 = "1234";
            if (!string.IsNullOrWhiteSpace(empleado.Cedula))
            {
                last4 = empleado.Cedula.Length >= 4 ? empleado.Cedula[^4..] : empleado.Cedula;
            }

            var usuario = new Usuario
            {
                NombreUsuario = uniqueUsername,
                Password = BCrypt.Net.BCrypt.HashPassword(last4),
                Rol = "Empleado",
                RequiereCambioPassword = true,
                EmpleadoId = empleado.Id,
                Activo = true
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }

        /// <summary>
        /// Restablece la contraseña del usuario asociado a un empleado
        /// a los últimos 4 dígitos de su cédula y obliga cambio al próximo login.
        /// </summary>
        public async Task<(bool Exito, string? PasswordTemporal)> RestablecerPasswordPorEmpleado(int empleadoId)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.EmpleadoId == empleadoId && u.Activo);
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Id == empleadoId);
            if (usuario == null || empleado == null)
            {
                return (false, null);
            }

            string last4 = "1234";
            if (!string.IsNullOrWhiteSpace(empleado.Cedula))
            {
                last4 = empleado.Cedula.Length >= 4 ? empleado.Cedula[^4..] : empleado.Cedula;
            }

            usuario.Password = BCrypt.Net.BCrypt.HashPassword(last4);
            usuario.RequiereCambioPassword = true;
            await _context.SaveChangesAsync();

            return (true, last4);
        }

        public async Task<Usuario?> ObtenerUsuarioPorEmpleadoId(int empleadoId)
        {
            return await _context.Usuarios.FirstOrDefaultAsync(u => u.EmpleadoId == empleadoId);
        }

        private static string GenerarNombreUsuario(string nombreCompleto)
        {
            var partes = nombreCompleto.Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            if (partes.Length >= 2)
            {
                return (partes[0].Substring(0, 1) + partes[1]).ToLower();
            }
            return nombreCompleto.Replace(" ", "").ToLower();
        }

        private async Task<string> AsegurarNombreUsuarioUnico(string baseUsername)
        {
            string candidate = baseUsername;
            int suffix = 0;
            while (true)
            {
                var exists = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == candidate);
                if (!exists) return candidate;
                suffix++;
                candidate = baseUsername + suffix.ToString();
            }
        }

        public async Task InicializarBaseDatos()
        {
            try
            {
                await _context.Database.EnsureCreatedAsync();
                
                // Verificar si ya existe el usuario admin
                var adminExiste = await _context.Usuarios.AnyAsync(u => u.Rol == "Admin");
                
                if (!adminExiste)
                {
                    var admin = new Usuario
                    {
                        NombreUsuario = "admin",
                        Password = BCrypt.Net.BCrypt.HashPassword("admin123"),
                        Rol = "Admin",
                        RequiereCambioPassword = false,
                        Activo = true
                    };
                    
                    _context.Usuarios.Add(admin);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                // Log error
                Console.WriteLine($"Error inicializando base de datos: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea usuarios y empleados de demostración para entorno de desarrollo.
        /// Genera hasta 'cantidad' usuarios con usuario 'demo1'...'demoN' y contraseña '123'.
        /// No duplica registros si ya existen.
        /// </summary>
        /// <param name="cantidad">Cantidad de usuarios a crear (por defecto 10)</param>
        public async Task SembrarUsuariosPorDefecto(int cantidad = 10)
        {
            try
            {
                // Asegurar BD creada
                await _context.Database.EnsureCreatedAsync();

                for (int i = 1; i <= cantidad; i++)
                {
                    string username = $"demo{i}";
                    string cedula = $"D{i:0000}"; // Única por índice

                    // Si ya existe el usuario demo{i}, saltar
                    bool usuarioExiste = await _context.Usuarios.AnyAsync(u => u.NombreUsuario == username);
                    if (usuarioExiste)
                        continue;

                    // Buscar si existe un empleado con esa cédula (por si se ejecuta varias veces)
                    var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.Cedula == cedula);
                    if (empleado == null)
                    {
                        empleado = new Empleado
                        {
                            NombreCompleto = $"Empleado Demo {i}",
                            Cedula = cedula,
                            Departamento = "DEMO",
                            Cargo = "Tester",
                            FechaIngreso = DateTime.Now,
                            Activo = true
                        };
                        _context.Empleados.Add(empleado);
                        await _context.SaveChangesAsync();
                    }

                    // Crear usuario asociado con contraseña 123
                    var usuario = new Usuario
                    {
                        NombreUsuario = username,
                        Password = BCrypt.Net.BCrypt.HashPassword("123"),
                        Rol = "Empleado",
                        RequiereCambioPassword = false,
                        Activo = true,
                        EmpleadoId = empleado.Id
                    };

                    _context.Usuarios.Add(usuario);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sembrando usuarios de desarrollo: {ex.Message}");
                throw;
            }
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
