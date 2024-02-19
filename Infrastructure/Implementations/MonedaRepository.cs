using Microsoft.EntityFrameworkCore;
using Primary.Domain;
using Primary.Domain.DTO;
using Primary.Infrastructure.Abstractions;

namespace Primary.Infrastructure.Implementations
{

    public class MonedaRepository : IMonedaRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public MonedaRepository(ApplicationDbContext dbContext)
        {
            _ApplicationDbContext = dbContext;
        }
        public async Task<List<Moneda>> GetAllMonedaAsync()
        {
            return await _ApplicationDbContext.Moneda.ToListAsync();
        }

        public async Task<Moneda> GetMonedaByIdAsync(int id)
        {
            return await _ApplicationDbContext.Moneda.FirstOrDefaultAsync(i => i.Id == id);
        }
    }
}
