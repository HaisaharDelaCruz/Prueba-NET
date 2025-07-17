using Datos;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Modelos.Modelos;

namespace API_Tienda.Controllers
{
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("api/auth/login")]
        public IActionResult Login([FromBody] Clientes cliente)
        {
            var clienteExistente = _context.Clientes
                .FirstOrDefault(c => c.Nombre == cliente.Nombre && c.Contrasena == cliente.Contrasena);

            if (clienteExistente !=null)
            {
                return Ok(new
                {
                    id = clienteExistente.Id,
                    nombreUsuario = cliente.Nombre,
                    expiracion = DateTime.UtcNow.AddHours(1)
                });
            }
            return Unauthorized();
        }
        [HttpPost("api/auth/register")]
        public IActionResult Register([FromBody] RegisterRequest request)
        {
            // Aquí iría la lógica de registro
            // Por simplicidad, retornamos un mensaje de éxito
            return Ok(new { Message = "Usuario registrado exitosamente" });
        }
    }
}
