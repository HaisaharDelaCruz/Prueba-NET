using Bussiness.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Modelos.Modelos;

namespace API_Tienda.Controllers
{
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;

        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpGet ("api/clientes/obtenerClientes")]
        public async Task<IActionResult> ObtenerTodos()
            => Ok(await _service.ObtenerTodos());

        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerPorId(int id)
        {
            var cliente = await _service.ObtenerPorId(id);
            return cliente == null ? NotFound() : Ok(cliente);
        }

        [HttpPost ("api/clientes/crearCliente")]
        public async Task<IActionResult> Crear([FromBody] Clientes cliente)
            => Ok(await _service.Crear(cliente));

        [HttpPut("api/clientes/editarCliente/{id}")]
        public async Task<IActionResult> Actualizar(int id, [FromBody] Clientes cliente)
        {
            if (id != cliente.Id) return BadRequest();
            return Ok(await _service.Actualizar(cliente));
        }

        [HttpDelete("api/clientes/eliminarCliente/{id}")]
        public async Task<IActionResult> Eliminar(int id)
        {
            var eliminado = await _service.Eliminar(id);
            return eliminado ? NoContent() : NotFound();
        }
    }
}
