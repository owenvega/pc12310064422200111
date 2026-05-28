using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC1.CORE.Core.Entities;
using PC1.CORE.Infrastructure.Data;

namespace PC12310064422200111.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly TallerMecanicoDbContext _context;

        public OrdenController(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        // GET: api/Orden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenServicio>>> GetOrdenes()
        {
            return await _context.OrdenServicio.ToListAsync();
        }

        // GET: api/Orden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServicio>> GetOrden(int id)
        {
            var orden = await _context.OrdenServicio.FindAsync(id);

            if (orden == null)
                return NotFound();

            return orden;
        }

        // POST: api/Orden
        [HttpPost]
        public async Task<ActionResult<OrdenServicio>> PostOrden(OrdenServicio orden)
        {
            _context.OrdenServicio.Add(orden);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetOrden),
                new { id = orden.Id },
                orden);
        }

        // PUT: api/Orden/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrden(int id, OrdenServicio orden)
        {
            if (id != orden.Id)
                return BadRequest();

            _context.Entry(orden).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.OrdenServicio.Any(o => o.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Orden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var orden = await _context.OrdenServicio.FindAsync(id);

            if (orden == null)
                return NotFound();

            _context.OrdenServicio.Remove(orden);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
ayudame a acambiarlo entonces