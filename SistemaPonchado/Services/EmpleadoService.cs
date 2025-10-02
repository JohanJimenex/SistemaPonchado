using SistemaPonchado.Data;
using SistemaPonchado.Models;
using Microsoft.EntityFrameworkCore;

namespace SistemaPonchado.Services
{
    public class EmpleadoService
    {
        private readonly SistemaPonchadoContext _context;
        private readonly AuthService _authService;

        public EmpleadoService()
        {
            _context = new SistemaPonchadoContext();
            _authService = new AuthService();
        }

        public async Task<bool> ExisteCedula(string cedula)
        {
            return await _context.Empleados.AnyAsync(e => e.Cedula == cedula);
        }

        public async Task<List<Empleado>> ObtenerEmpleados(int pagina = 1, int elementosPorPagina = 20, string? filtro = null)
        {
            var query = _context.Empleados.Include(e => e.Usuario).AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(e => e.NombreCompleto.Contains(filtro) || 
                                       e.Cedula.Contains(filtro) ||
                                       (e.Departamento != null && e.Departamento.Contains(filtro)));
            }

            return await query
                .OrderBy(e => e.NombreCompleto)
                .Skip((pagina - 1) * elementosPorPagina)
                .Take(elementosPorPagina)
                .ToListAsync();
        }

        public async Task<int> ContarEmpleados(string? filtro = null)
        {
            var query = _context.Empleados.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query = query.Where(e => e.NombreCompleto.Contains(filtro) || 
                                       e.Cedula.Contains(filtro) ||
                                       (e.Departamento != null && e.Departamento.Contains(filtro)));
            }

            return await query.CountAsync();
        }

        public async Task<Empleado?> CrearEmpleado(Empleado empleado)
        {
            try
            {
                // Verificar que la cédula no exista
                var existeCedula = await ExisteCedula(empleado.Cedula);
                if (existeCedula)
                {
                    throw new InvalidOperationException("Ya existe un empleado con esa cédula.");
                }

                // Crear empleado
                _context.Empleados.Add(empleado);
                await _context.SaveChangesAsync();

                // Crear usuario asociado
                await _authService.CrearUsuarioEmpleado(empleado);

                return empleado;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ActualizarEmpleado(Empleado empleado)
        {
            try
            {
                // Verificar que la cédula no exista en otro empleado
                var existeCedula = await _context.Empleados
                    .AnyAsync(e => e.Cedula == empleado.Cedula && e.Id != empleado.Id);
                
                if (existeCedula)
                {
                    throw new InvalidOperationException("Ya existe otro empleado con esa cédula.");
                }

                _context.Empleados.Update(empleado);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> EliminarEmpleado(int empleadoId)
        {
            try
            {
                var empleado = await _context.Empleados
                    .Include(e => e.Usuario)
                    .FirstOrDefaultAsync(e => e.Id == empleadoId);

                if (empleado == null)
                    return false;

                // Desactivar en lugar de eliminar físicamente
                empleado.Activo = false;
                if (empleado.Usuario != null)
                {
                    empleado.Usuario.Activo = false;
                }

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Empleado?> ObtenerEmpleadoPorId(int id)
        {
            return await _context.Empleados
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public void Dispose()
        {
            _context?.Dispose();
            _authService?.Dispose();
        }
    }
}