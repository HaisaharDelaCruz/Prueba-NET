using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Modelos;

namespace Bussiness.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<Clientes>> ObtenerTodos();
        Task<Clientes> ObtenerPorId(int id);
        Task<Clientes> Crear(Clientes cliente);
        Task<Clientes> Actualizar(Clientes cliente);
        Task<bool> Eliminar(int id);
    }
}
