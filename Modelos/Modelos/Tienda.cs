using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Modelos;

namespace Modelos.Modelos
{
    public class Tienda
    {
        public int Id { get; set; }
        public string Sucursal { get; set; }
        public string Direccion { get; set; }

        public List<TiendaArticulo> TiendaArticulos { get; set; } = new List<TiendaArticulo>();

    }
}
