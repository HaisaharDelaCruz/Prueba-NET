using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;
using Models.Modelos;

namespace Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulos { get; set; }
        public DbSet<TiendaArticulo> TiendaArticulos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
