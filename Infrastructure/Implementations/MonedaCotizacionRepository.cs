using Primary.Infrastructure.Abstractions;
using Project.Shared;

namespace Primary.Infrastructure.Implementations
{
    // Implementaciones concretas de servicios y repositorios
    public class MonedaCotizacionRepository : IMonedaCotizacionRepository
    {
        // Implementación de métodos de repositorio
        public Task<List<MonedaCotizacionDTO>> GetAllMonedaCotizacionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<MonedaCotizacionDTO> GetMonedaCotizacionByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
