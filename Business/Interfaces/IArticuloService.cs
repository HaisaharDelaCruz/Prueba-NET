using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Modelos;

namespace Bussiness.Interfaces
{
    public interface IArticuloService
    {
        Task<IEnumerable<Articulos>> ObtenerTodos();
        Task<Articulos?> ObtenerPorId(int id);
        Task<Articulos> Crear(Articulos articulo);
        Task<Articulos> Actualizar(Articulos articulo);
        Task<bool> Eliminar(int id);
    }
}
