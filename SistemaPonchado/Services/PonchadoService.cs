using Microsoft.EntityFrameworkCore;
using SistemaPonchado.Data;
using SistemaPonchado.Models;

namespace SistemaPonchado.Services
{
    public class PonchadoService : IDisposable
    {
        private readonly SistemaPonchadoContext _context;

        public PonchadoService()
        {
            _context = new SistemaPonchadoContext();
        }

        public async Task<Ponchado?> ObtenerPonchadoHoy(int empleadoId)
        {
            var hoy = DateTime.Today;
            return await _context.Ponchados
                .FirstOrDefaultAsync(p => p.EmpleadoId == empleadoId && p.Fecha.Date == hoy);
        }

        public async Task<Ponchado> RegistrarEntrada(int empleadoId)
        {
            var hoy = DateTime.Today;
            var ponchadoExistente = await ObtenerPonchadoHoy(empleadoId);

            if (ponchadoExistente != null)
            {
                throw new InvalidOperationException("Ya se registró la entrada para hoy.");
            }

            var ponchado = new Ponchado
            {
                EmpleadoId = empleadoId,
                Fecha = hoy,
                HoraEntrada = DateTime.Now,
                FechaCreacion = DateTime.Now
            };

            _context.Ponchados.Add(ponchado);
            await _context.SaveChangesAsync();

            return ponchado;
        }

        public async Task<Ponchado> RegistrarSalida(int empleadoId)
        {
            var ponchado = await ObtenerPonchadoHoy(empleadoId);

            if (ponchado == null)
            {
                throw new InvalidOperationException("Debe registrar la entrada primero.");
            }

            if (ponchado.HoraSalida.HasValue)
            {
                throw new InvalidOperationException("Ya se registró la salida para hoy.");
            }

            ponchado.HoraSalida = DateTime.Now;
            await _context.SaveChangesAsync();

            return ponchado;
        }

        public async Task<List<Ponchado>> ObtenerHistorialEmpleado(int empleadoId, int pagina = 1, int elementosPorPagina = 20)
        {
            return await _context.Ponchados
                .Include(p => p.Empleado)
                .Where(p => p.EmpleadoId == empleadoId)
                .OrderByDescending(p => p.Fecha)
                .Skip((pagina - 1) * elementosPorPagina)
                .Take(elementosPorPagina)
                .ToListAsync();
        }

        public async Task<int> ContarHistorialEmpleado(int empleadoId)
        {
            return await _context.Ponchados
                .CountAsync(p => p.EmpleadoId == empleadoId);
        }

        public async Task<List<Ponchado>> ObtenerTodosPonchados(int pagina = 1, int elementosPorPagina = 20)
        {
            return await _context.Ponchados
                .Include(p => p.Empleado)
                .OrderByDescending(p => p.Fecha)
                .ThenByDescending(p => p.HoraEntrada)
                .Skip((pagina - 1) * elementosPorPagina)
                .Take(elementosPorPagina)
                .ToListAsync();
        }

        public async Task<int> ContarTodosPonchados()
        {
            return await _context.Ponchados.CountAsync();
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}