using Primary.Domain.DTO;
using Primary.Domain.Entities;

namespace Primary.Infrastructure.Abstractions
{
    public interface ITransaccionRepository
    {
        Task<Tuple<bool, Transaccion>> InsertTransactionAsync(Transaccion transaccion); 
        Task<Transaccion> GetTransactionByIdAsync(int id);
        Task<IQueryable<Transaccion>> GetTransactionByClienteAsync(int id);
        Task<List<Transaccion>> GetTransactionsAsync();
    }
}
