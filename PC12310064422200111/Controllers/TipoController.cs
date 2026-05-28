using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PC1.CORE.Core.Entities;
using PC1.CORE.Infrastructure.Data;

namespace PC12310064422200111.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoController : ControllerBase
    {
        private readonly TallerMecanicoDbContext _context;

        public TipoController(TallerMecanicoDbContext context)
        {
            _context = context;
        }

        // GET: api/Tipo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TipoServicio>>> GetTipos()
        {
            return await _context.TipoServicio.ToListAsync();
        }

        // GET: api/Tipo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoServicio>> GetTipo(int id)
        {
            var tipo = await _context.TipoServicio.FindAsync(id);

            if (tipo == null)
                return NotFound();

            return tipo;
        }

        // POST: api/Tipo
        [HttpPost]
        public async Task<ActionResult<TipoServicio>> PostTipo(TipoServicio tipo)
        {
            _context.TipoServicio.Add(tipo);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetTipo),
                new { id = tipo.Id },
                tipo);
        }

        // PUT: api/Tipo/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTipo(int id, TipoServicio tipo)
        {
            if (id != tipo.Id)
                return BadRequest();

            _context.Entry(tipo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.TipoServicio.Any(t => t.Id == id))
                    return NotFound();

                throw;
            }

            return NoContent();
        }

        // DELETE: api/Tipo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTipo(int id)
        {
            var tipo = await _context.TipoServicio.FindAsync(id);

            if (tipo == null)
                return NotFound();

            _context.TipoServicio.Remove(tipo);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}