using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bussiness.Interfaces;
using Datos;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;

namespace Business.Services
{
    public class ClienteService : IClienteService
    {
        private readonly ApplicationDbContext _context;
        public ClienteService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Clientes>> ObtenerTodos()
            => await _context.Clientes.ToListAsync();

        public async Task<Clientes> ObtenerPorId(int id)
            => await _context.Clientes.Include(c => c.ClienteArticulos).FirstOrDefaultAsync(c => c.Id == id);

        public async Task<Clientes> Crear(Clientes cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<Clientes> Actualizar(Clientes cliente)
        {
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return cliente;
        }

        public async Task<bool> Eliminar(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
