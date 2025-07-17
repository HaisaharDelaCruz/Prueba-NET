using Datos;
using Modelos.Modelos;
using Models.Modelos;

namespace API_Tienda.SeedData
{
    public class SeedDatos
    {
        public static async Task<string> InicializarDatosAsync(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Articulos.Any() || context.Tiendas.Any() || context.Clientes.Any())
            {
            return "Los datos ya han sido inicializados previamente.";
            }

            var articulos = new List<Articulos>
            {
                new Articulos { Codigo = "ART-001", Descripcion = "Laptop", Precio = 15000, Stock = 10 },
                new Articulos { Codigo = "ART-002", Descripcion = "Mouse", Precio = 250, Stock = 50 },
                new Articulos { Codigo = "ART-003", Descripcion = "Teclado", Precio = 600, Stock = 30 }
            };
            context.Articulos.AddRange(articulos);

            var tiendas = new List<Tienda>
            {
                new Tienda { Sucursal = "Centro", Direccion = "Av. Principal 123" },
                new Tienda { Sucursal = "Norte", Direccion = "Calle 5 #32" }
            };
            context.Tiendas.AddRange(tiendas);

            var clientes = new List<Clientes>
            {
                new Clientes { Nombre = "Luis", Apellido = "Pérez", Direccion = "Col. Reforma", Correo = "luis@mail.com", Contrasena = "123" },
                new Clientes { Nombre = "Ana", Apellido = "Gómez", Direccion = "Col. Centro", Correo = "ana@mail.com", Contrasena = "456" }
            };
            context.Clientes.AddRange(clientes);

            context.SaveChanges();

            var cliente = context.Clientes.First();
            var articulo = context.Articulos.First();

            var compras = new List<ClienteArticulo>
            {
                new ClienteArticulo { ClienteId = cliente.Id, ArticuloId = articulo.Id, Fecha = DateTime.UtcNow }
            };
            context.ClienteArticulos.AddRange(compras);
            await context.SaveChangesAsync();
            return "Datos iniciales insertados correctamente.";
        }
    }
}
