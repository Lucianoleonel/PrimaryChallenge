using Project.Shared;

namespace Primary.Application.Abstractions
{
    public interface IMonedaCotizacionService
    {
        Task<List<MonedaCotizacionDTO>> GetAllCotizacionMonedaAsync();
        Task<MonedaCotizacionDTO> GetCotizacionMonedaByIdAsync(int id);
    }
}
