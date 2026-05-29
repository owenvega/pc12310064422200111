using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using PC1.CORE.Core.Entities;
using PC1.CORE.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using PC1.CORE.Core.Interfaces;
namespace PC1.CORE.Infrastructure.Repositories
{
    public class OrdenServicioRepository : IOrdenServicioRepository
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
            _context.OrdenServicio.Add(ordenServicio);
            await _context.SaveChangesAsync();
            return ordenServicio;
        }

        public async Task<OrdenServicio> updateOrdenServicio(OrdenServicio ordenServicio)
        {
            // El método .Update() rastrea automáticamente la entidad por su ID 
            // y sobreescribe todos sus campos en la base de datos de un solo golpe.
            _context.OrdenServicio.Update(ordenServicio);
            await _context.SaveChangesAsync();
            return ordenServicio;
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


    }
}
