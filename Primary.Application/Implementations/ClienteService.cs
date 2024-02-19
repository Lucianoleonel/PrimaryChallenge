using Primary.Application.Abstractions;
using Primary.Domain;
using Primary.Domain.DTO;
using Primary.Infrastructure.Abstractions;

namespace Primary.Application.Implementations
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        #region Implementations IClienteService
        public async Task<Tuple<bool, Cliente>> InsertClientAsync(Cliente cliente)
        {
            return await _clienteRepository.InsertClientAsync(cliente);
        }

        public async Task<List<Cliente>> GetAllClientesAsync()
        {
            return await _clienteRepository.GetAllClientesAsync();
        }
        public async Task<Cliente> GetClienteByIdAsync(int id)
        {
            return await _clienteRepository.GetClienteByIdAsync(id);
        }

        #endregion
    }


}
