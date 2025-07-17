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
    public class ClienteArticuloConfig : IEntityTypeConfiguration<ClienteArticulo>
    {
        public void Configure(EntityTypeBuilder <ClienteArticulo> builder)
        {
            builder.HasKey(ca => ca.Id);

            builder.HasOne(ca => ca.Cliente)
                .WithMany(c => c.ClienteArticulos)
                .HasForeignKey(ca => ca.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ca => ca.Articulo)
                .WithMany(c => c.ClienteArticulos)
                .HasForeignKey(ca => ca.ArticuloId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
