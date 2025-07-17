using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Modelos;

namespace Modelos.Modelos
{
    public class Articulos
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public float Precio { get; set; }
        public byte[]? Imagen { get; set; }
        public int Stock { get; set; }

        public List<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
        public List<TiendaArticulo> TiendaArticulos { get; set; } = new List<TiendaArticulo>();
    }
}
