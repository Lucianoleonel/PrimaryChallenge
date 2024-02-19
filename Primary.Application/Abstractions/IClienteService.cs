using Primary.Domain;
using Primary.Domain.DTO;

namespace Primary.Application.Abstractions
{
    public interface IClienteService
    {
        Task<Tuple<bool, Cliente>> InsertClientAsync(Cliente cliente);
        Task<List<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
    }
}
