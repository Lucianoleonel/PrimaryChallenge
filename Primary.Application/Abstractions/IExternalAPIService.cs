
using Primary.Domain.DTO;
using Project.Shared;

namespace Primary.Application.Abstractions
{
    public interface IExternalAPIService
    {
        Task<List<MonedaCotizacionDTO>> GetCotizacionMonedasFromExternalAPI();
        Task<List<MonedaCotizacionDTO>> GetCotizacionMonedasFromExternalAPI(MonedaCotizacionRequestDTO monedaCotizacionRequestDTO);
        Task<List<Project.Shared.MonedaDTO>> GetMonedasFromExternalAPI();
    }
}
