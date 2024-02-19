using Microsoft.EntityFrameworkCore;
using Primary.Domain;
using Primary.Domain.DTO;
using Primary.Domain.Entities;
using Primary.Infrastructure.Abstractions;
using System.Net.WebSockets;

namespace Primary.Infrastructure.Implementations
{
    public class TransaccionRepository : ITransaccionRepository
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public TransaccionRepository(ApplicationDbContext dbContext)
        {
            _ApplicationDbContext = dbContext;
        }

        public async Task<Transaccion> GetTransactionByIdAsync(int id)
        {
            return await _ApplicationDbContext.Transaccion.FirstOrDefaultAsync(i => i.Id == id);
        }
        
        public async Task<IQueryable<Transaccion>> GetTransactionByClienteAsync(int id)
        {
            var transaccion = _ApplicationDbContext.Transaccion.Where(i => i.ClienteId == id);
            return transaccion;
        }

        public Task<List<Transaccion>> GetTransactionsAsync()
        {
            var transacciones = _ApplicationDbContext.Transaccion.ToList();
            return Task.FromResult(transacciones);
        }

        public async Task<Tuple<bool, Transaccion>> InsertTransactionAsync(Transaccion transaccion)
        {
            await _ApplicationDbContext.Transaccion.AddAsync(transaccion);
            int resultInsert  = await _ApplicationDbContext.SaveChangesAsync();
            return Tuple.Create(resultInsert > 0, transaccion);
        }

    }


}
