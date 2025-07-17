using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models.Modelos;

namespace API_Tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CarritoController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("comprar")]
        public async Task<IActionResult> Comprar([FromBody] CompraRequest request)
        {
            if (request.ArticuloIds == null || request.ArticuloIds.Count == 0)
                return BadRequest("No se enviaron artículos");

            var compras = request.ArticuloIds.Select(articuloId => new ClienteArticulo
            {
                ClienteId = request.ClienteId,
                ArticuloId = articuloId,
                Fecha = DateTime.UtcNow
            });

            foreach (var articuloId in request.ArticuloIds)
            {
                var articulo = await _context.Articulos.FindAsync(articuloId);
                if (articulo == null)
                    return NotFound($"Artículo con ID {articuloId} no encontrado.");

                if (articulo.Stock <= 0)
                    return BadRequest($"No hay stock disponible para el artículo {articulo.Codigo}.");

                articulo.Stock--; // Descontar el stock
            }

            await _context.ClienteArticulos.AddRangeAsync(compras);
            await _context.SaveChangesAsync();

            return Ok(compras);
        }

        [HttpGet("obtenerComprasCliente/{clienteId}")]
        public async Task<IActionResult> obtenerCompras(int clienteId)
        {
            var compras = await _context.ClienteArticulos
                .Where(ca => ca.ClienteId == clienteId)
                .Include(ca => ca.Articulo) // Trae detalles del artículo
                .Select(ca => new
                {
                    ca.Articulo.Codigo,
                    ca.Articulo.Descripcion,
                    ca.Articulo.Precio,
                    ca.Fecha
                })
                .ToListAsync();

            return Ok(compras);
        }
        public class CompraRequest
        {
            public int ClienteId { get; set; }
            public List<int> ArticuloIds { get; set; }
        }
    }
}
