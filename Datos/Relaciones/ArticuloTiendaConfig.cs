using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Models.Modelos;

namespace Datos.Relaciones
{
    public class ArticuloTiendaConfig : IEntityTypeConfiguration<TiendaArticulo>
    {
        public void Configure(EntityTypeBuilder<TiendaArticulo> builder)
        {
            builder.HasKey(ta => ta.Id);

            builder.HasOne(ta => ta.Tienda)
                .WithMany(t => t.TiendaArticulos)
                .HasForeignKey(ta => ta.TiendaId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ta => ta.Articulo)
                .WithMany(a => a.TiendaArticulos)
                .HasForeignKey(ta => ta.ArticuloId)
                .OnDelete(DeleteBehavior.Cascade);
    }
}
}
