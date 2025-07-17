using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Modelos;

namespace Models.Modelos
{
    public  class TiendaArticulo
    {
        public int Id { get; set; }
        public int TiendaId { get; set; }
        public int ArticuloId { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

        public Articulos Articulo { get; set; } = null!;
        public Tienda Tienda { get; set; } = null!;

    }
}
