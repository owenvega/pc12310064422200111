using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PC1.CORE.Core.Entities;
using PC1.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
namespace PC1.CORE.Infrastructure.Repositories
{
    public class OrdenServicioRepository
    {
        private readonly TallerMecanicoDbContext _context;


        public OrdenServicioRepository(TallerMecanicoDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<OrdenServicio>> getOrdenServicio()
        {
            return await _context.OrdenServicio
                .Include(os => os.TipoServicio)
                .Include(os => os.Vehiculo)
                .ToListAsync();
        }

        public async Task<OrdenServicio> getOrdenServicioById(int id)
        {
            return await _context.OrdenServicio
                .Include(os => os.TipoServicio)
                .Include(os => os.Vehiculo)
                .FirstOrDefaultAsync(os => os.Id == id);

        }
//a

        public async Task<OrdenServicio> createOrdenServicio(OrdenServicio ordenServicio)
        {
            if (ordenServicio == null) throw new ArgumentNullException(nameof(ordenServicio));

            // Ensure related entities exist
            var tipo = await _context.TipoServicio.FindAsync(ordenServicio.TipoServicioId);
            if (tipo == null) throw new InvalidOperationException($"TipoServicio with Id {ordenServicio.TipoServicioId} not found.");

            var veh = await _context.Vehiculo.FindAsync(ordenServicio.VehiculoId);
            if (veh == null) throw new InvalidOperationException($"Vehiculo with Id {ordenServicio.VehiculoId} not found.");

            // If FechaIngreso not provided, set to now (DB also has default but keep entity consistent)
            if (ordenServicio.FechaIngreso == default)
            {
                ordenServicio.FechaIngreso = DateTime.Now;
            }

            _context.OrdenServicio.Add(ordenServicio);
            await _context.SaveChangesAsync();
            // Attach navigation properties for returned entity
            ordenServicio.TipoServicio = tipo;
            ordenServicio.Vehiculo = veh;
            return ordenServicio;
        }

        public async Task<OrdenServicio> updateOrdenServicio(OrdenServicio ordenServicio)
        {
            if (ordenServicio == null) throw new ArgumentNullException(nameof(ordenServicio));

            var existing = await _context.OrdenServicio.FindAsync(ordenServicio.Id);
            if (existing == null)
            {
                return null;
            }

            // Validate foreign keys if changed
            if (ordenServicio.TipoServicioId != existing.TipoServicioId)
            {
                var tipo = await _context.TipoServicio.FindAsync(ordenServicio.TipoServicioId);
                if (tipo == null) throw new InvalidOperationException($"TipoServicio with Id {ordenServicio.TipoServicioId} not found.");
                existing.TipoServicioId = ordenServicio.TipoServicioId;
            }

            if (ordenServicio.VehiculoId != existing.VehiculoId)
            {
                var veh = await _context.Vehiculo.FindAsync(ordenServicio.VehiculoId);
                if (veh == null) throw new InvalidOperationException($"Vehiculo with Id {ordenServicio.VehiculoId} not found.");
                existing.VehiculoId = ordenServicio.VehiculoId;
            }

            // Update scalar properties
            existing.DescripcionProblema = ordenServicio.DescripcionProblema;
            existing.CostoEstimado = ordenServicio.CostoEstimado;
            existing.Estado = ordenServicio.Estado;
            // Do not overwrite FechaIngreso by default; if caller provided a non-default value, update it
            if (ordenServicio.FechaIngreso != default)
            {
                existing.FechaIngreso = ordenServicio.FechaIngreso;
            }

            await _context.SaveChangesAsync();
            // Reload navigation properties
            await _context.Entry(existing).Reference(e => e.TipoServicio).LoadAsync();
            await _context.Entry(existing).Reference(e => e.Vehiculo).LoadAsync();
            return existing;
        }

        public async Task<bool> deleteOrdenServicio(int id)
        {
            var ordenServicio = await _context.OrdenServicio.FindAsync(id);
            if (ordenServicio == null)
            {
                return false;
            }
            _context.OrdenServicio.Remove(ordenServicio);
            await _context.SaveChangesAsync();
            return true;
        }
//a

    }
}
