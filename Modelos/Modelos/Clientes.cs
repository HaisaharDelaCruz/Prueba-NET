using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Modelos;

namespace Modelos.Modelos
{
    public class Clientes
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Direccion { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }

        public List<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
    }
}
