using Microsoft.EntityFrameworkCore;
using Primary.Domain;
using Primary.Domain.DTO;
using Primary.Domain.Entities;
using Primary.Infrastructure.Abstractions;

namespace Primary.Infrastructure.Implementations
{

    public class ClienteRepository : IClienteRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public ClienteRepository(ApplicationDbContext dbContext)
        {
            _ApplicationDbContext = dbContext;
        }
        public async Task<List<Cliente>> GetAllClientesAsync()
            => await _ApplicationDbContext.Cliente.ToListAsync();
        

        public async Task<Cliente> GetClienteByIdAsync(int id)
            => await _ApplicationDbContext.Cliente.FirstOrDefaultAsync(i => i.Id == id);


        public Task<bool> ExistClienteAsync(int id)
        {   
            return Task.FromResult(_ApplicationDbContext.Cliente.Any(i => i.Id == id));
        }

        public async Task<Tuple<bool, Cliente>> InsertClientAsync(Cliente cliente)
        {
            await _ApplicationDbContext.Cliente.AddAsync(cliente);
            int resultInsert = await _ApplicationDbContext.SaveChangesAsync();
            return Tuple.Create(resultInsert > 0, cliente);
        }


    }
}
