using Primary.Domain;

namespace Primary.Infrastructure.Abstractions
{

    public interface IMonedaRepository
    {
        Task<List<Moneda>> GetAllMonedaAsync();
        Task<Moneda> GetMonedaByIdAsync(int id);
    }
}
