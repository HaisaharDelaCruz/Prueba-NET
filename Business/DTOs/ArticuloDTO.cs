using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bussiness.DTOs
{
    public class ArticuloDTO
    {
        public int Id { get; set; }
        public string Codigo { get; set; } = string.Empty;
        public string? Descripcion { get; set; }
        public float Precio { get; set; }
        public int Stock { get; set; }
        public byte[]? Imagen { get; set; }
        public string? ImagenBase64 { get; set; }
    }
}
