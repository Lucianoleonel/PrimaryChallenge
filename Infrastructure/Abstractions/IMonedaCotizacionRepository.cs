using Primary.Domain.DTO;
using Project.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary.Infrastructure.Abstractions
{

    public interface IMonedaCotizacionRepository
    {
        Task<List<MonedaCotizacionDTO>> GetAllMonedaCotizacionAsync();
        Task<MonedaCotizacionDTO> GetMonedaCotizacionByIdAsync(int id);
    }
}
