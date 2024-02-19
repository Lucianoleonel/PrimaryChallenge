//using Primary.Domain.DTO;
//using Primary.Domain.Entities;
//using TransaccionDTO = Project.Shared.TransaccionDTO;

using Project.Shared;

namespace Primary.Application.Abstractions
{
    public interface ITransaccionService
    {
        Task<Tuple<bool, TransaccionDTO>> InsertTransactionAsync(TransaccionDTO transaccion);
        Task<TransaccionDTO> GetTransactionByIdAsync(int id);
        Task<List<TransaccionDTO>> GetTransactionsAsync();
        Task<IEnumerable<TransaccionDTO>> GetTransactionByClienteAsync(int id);
    }
}
