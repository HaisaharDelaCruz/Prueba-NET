using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Modelos.Modelos;

namespace API_Tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendasController : ControllerBase
    {
        private readonly Bussiness.Interfaces.ITiendaService _tiendaService;
        public TiendasController(Bussiness.Interfaces.ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }
        // GET: api/tiendas
        [HttpGet ("obtenerTiendas")]
        public async Task<IActionResult> GetTiendas()
        {
            var tiendas = await _tiendaService.GetAllAsync();
            return Ok(tiendas);
        }

        // GET: api/tiendas/{id}
        [HttpGet("obtenerTienda/{id}")]
        public async Task<IActionResult> GetTienda(int id)
        {
            try
            {
                var tienda = await _tiendaService.GetByIdAsync(id);
                return Ok(tienda);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
        // POST: api/tiendas
        [HttpPost ("crearTienda")]
        public async Task<IActionResult> Create(Tienda tienda) => Ok(await _tiendaService.CreateAsync(tienda));

        [HttpPut("editarTienda/{id}")]
        public async Task<IActionResult> Update(int id, Tienda tienda)
        {
            if (id != tienda.Id) return BadRequest();
            return Ok(await _tiendaService.UpdateAsync(tienda));
        }

        [HttpDelete ("eliminarTienda/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _tiendaService.DeleteAsync(id);
            if (!success) return NotFound();
            return NoContent();
        }

    }
}
