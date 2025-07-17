using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelos.Modelos;

namespace Bussiness.Interfaces
{
    public interface ITiendaService
    {
        Task<List<Tienda>> GetAllAsync();
        Task<Tienda> GetByIdAsync(int id);
        Task<Tienda> CreateAsync(Tienda tienda);
        Task<Tienda> UpdateAsync(Tienda tienda);
        Task<bool> DeleteAsync(int id);
    }
}
