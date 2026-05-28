using Microsoft.AspNetCore.Mvc;
using PC1.CORE.Core.DTOs;
using PC1.CORE.Core.Interfaces;

namespace PC12310064422200111.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenServicioService _service;

        public OrdenController(IOrdenServicioService service)
        {
            _service = service;
        }

        // GET: api/Orden
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdenServicioListDTO>>> GetOrdenes()
        {
            var ordenes = await _service.GetAll();
            return Ok(ordenes);
        }

        // GET: api/Orden/5
        [HttpGet("{id}")]
        public async Task<ActionResult<OrdenServicioDTO>> GetOrden(int id)
        {
            var orden = await _service.GetById(id);

            if (orden == null)
                return NotFound();

            return Ok(orden);
        }

        // POST: api/Orden
        [HttpPost]
        public async Task<ActionResult<OrdenServicioDTO>> PostOrden(CreateOrdenServicioDTO dto)
        {
            var orden = await _service.Create(dto);

            return CreatedAtAction(
                nameof(GetOrden),
                new { id = orden.Id },
                orden);
        }

        // PUT: api/Orden/5
        [HttpPut("{id}")]
        public async Task<ActionResult<OrdenServicioDTO>> PutOrden(
            int id,
            UpdateOrdenServicioDTO dto)
        {
            var orden = await _service.Update(id, dto);

            if (orden == null)
                return NotFound();

            return Ok(orden);
        }

        // DELETE: api/Orden/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrden(int id)
        {
            var eliminado = await _service.Delete(id);

            if (!eliminado)
                return NotFound();

            return NoContent();
        }
    }
}