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
    public class TiendaService : ITiendaService
    {
        private readonly ApplicationDbContext _context;

        public TiendaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tienda>> GetAllAsync()
        {
            return await _context.Tiendas.ToListAsync();
        }

        public async Task<Tienda> GetByIdAsync(int id)
        {
            return await _context.Tiendas.FindAsync(id) ?? throw new KeyNotFoundException("Tienda not found");
        }

        public async Task<Tienda> CreateAsync(Tienda tienda)
        {
            if (tienda == null) throw new ArgumentNullException(nameof(tienda));
            _context.Tiendas.Add(tienda);
            await _context.SaveChangesAsync();
            return tienda;
        }

        public async Task<Tienda> UpdateAsync(Tienda tienda)
        {
            if (tienda == null) throw new ArgumentNullException(nameof(tienda));
            _context.Tiendas.Update(tienda);
            await _context.SaveChangesAsync();
            return tienda;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda == null) throw new KeyNotFoundException("Tienda not found");
            _context.Tiendas.Remove(tienda);
            return await _context.SaveChangesAsync() > 0;
        }

    }
}
