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
    public class ArticuloService : IArticuloService
    {
        private readonly ApplicationDbContext _context;

        public ArticuloService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Articulos>> ObtenerTodos()
        {
            return await _context.Articulos.ToListAsync();
        }

        public async Task<Articulos?> ObtenerPorId(int id)
        {
            return await _context.Articulos.FindAsync(id);
        }

        public async Task<Articulos> Crear(Articulos articulo)
        {
            _context.Articulos.Add(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }

        public async Task<Articulos> Actualizar(Articulos articulo)
        {
            _context.Articulos.Update(articulo);
            await _context.SaveChangesAsync();
            return articulo;
        }

        public async Task<bool> Eliminar(int id)
        {
            var articulo = await _context.Articulos.FindAsync(id);
            if (articulo == null) return false;

            _context.Articulos.Remove(articulo);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}
