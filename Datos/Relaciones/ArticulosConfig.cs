using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Modelos.Modelos;

namespace Datos.Relaciones
{
    public class ArticulosConfig : IEntityTypeConfiguration<Articulos>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Articulos> builder)
        {
            builder.HasKey(a => a.Id);

            // Configuración de relaciones
            builder.HasMany(a => a.ClienteArticulos)
                .WithOne(ca => ca.Articulo)
                .HasForeignKey(ca => ca.ArticuloId);

            builder.HasMany(a => a.TiendaArticulos)
                .WithOne(ta => ta.Articulo)
                .HasForeignKey(ta => ta.ArticuloId);
        }
    }
}
