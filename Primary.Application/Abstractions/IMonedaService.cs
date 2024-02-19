using Primary.Domain.DTO;

namespace Primary.Application.Abstractions
{
    public interface IMonedaService
    {
        Task<List<MonedaDTO>> GetAllMonedasAsync();
        Task<MonedaDTO> GetMonedaByIdAsync(int id);
    }
}
