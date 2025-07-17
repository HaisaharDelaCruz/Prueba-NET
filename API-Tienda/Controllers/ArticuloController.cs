using Bussiness.DTOs;
using Bussiness.Interfaces;
using Datos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;
using Models.Modelos;

namespace API_Tienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticuloController : ControllerBase
    {
        private readonly IArticuloService _service;
        private readonly ApplicationDbContext _context;
        public ArticuloController(IArticuloService service , ApplicationDbContext context)
        {
            _service = service;
            _context = context;
        }

        [HttpGet("obtenerArticulos")]
        public async Task<IActionResult> ObtenerTodos()
        {
            var articulos = await _service.ObtenerTodos();

            var resultados = articulos.Select(a => new ArticuloDTO
            {
                Id = a.Id,
                Codigo = a.Codigo,
                Descripcion = a.Descripcion,
                Precio = a.Precio,
                Stock = a.Stock,
                ImagenBase64 = a.Imagen != null
                    ? $"data:image/png;base64,{Convert.ToBase64String(a.Imagen)}"
                    : null
            });
            return Ok(resultados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var articulo = await _service.ObtenerPorId(id);
            if (articulo == null) return NotFound();
            return Ok(articulo);
        }

        [HttpPost("crearArticulo")]
        public async Task<IActionResult> Crear([FromForm] ArticuloDTO dto, IFormFile imagen)
        {
            if (imagen != null && imagen.Length > 0)
            {
                using var ms = new MemoryStream();
                await imagen.CopyToAsync(ms);
                dto.Imagen = ms.ToArray();
            }

            var articulo = new Articulos
            {
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Imagen = dto.Imagen
            };

            var creado = await _service.Crear(articulo);
            return Ok(creado);
        }

        [HttpPut("editarArticulo/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromForm] ArticuloDTO dto, IFormFile? imagen)
        {
            if (id != dto.Id) return BadRequest();

            byte[]? imagenBytes = null;

            if (imagen != null && imagen.Length > 0)
            {
                using var ms = new MemoryStream();
                await imagen.CopyToAsync(ms);
                imagenBytes = ms.ToArray();
            }

            var articulo = new Articulos
            {
                Id = dto.Id,
                Codigo = dto.Codigo,
                Descripcion = dto.Descripcion,
                Precio = dto.Precio,
                Stock = dto.Stock,
                Imagen = imagenBytes
            };

            var actualizado = await _service.Actualizar(articulo);
            return Ok(actualizado);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var resultado = await _service.Eliminar(id);
            return resultado ? Ok() : NotFound();
        }

        [HttpPost("asignarArticulo")]
        public async Task<IActionResult> AsignarArticulo([FromBody] AsignarArticuloDto dto)
        {
            var existe = await _context.TiendaArticulos
                .AnyAsync(t => t.TiendaId == dto.TiendaId && t.ArticuloId == dto.ArticuloId);

            if (existe)
                return BadRequest("El artículo ya está asignado a la tienda.");

            var entidad = new TiendaArticulo
            {
                TiendaId = dto.TiendaId,
                ArticuloId = dto.ArticuloId
            };

            _context.TiendaArticulos.Add(entidad);
            await _context.SaveChangesAsync();

            return Ok(new { mensaje = "Artículo asignado correctamente." });
        }

        [HttpGet("mostrarTiendaArticulo")]
        public async Task<IActionResult> ObtenerTiendaArticulo()
        {
            var articulos = await _context.TiendaArticulos.Select(ta => new TiendaArticulosDTO
            {
                NombreTienda = ta.Tienda.Sucursal,
                NombreArticulo = ta.Articulo.Codigo,
                Precio = ta.Articulo.Precio
            }).ToListAsync();

            return Ok(articulos);
        }
    }
}
