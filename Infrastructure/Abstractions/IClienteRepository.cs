using Primary.Domain;
using Primary.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary.Infrastructure.Abstractions
{

    public interface IClienteRepository
    {
        Task<Tuple<bool, Cliente>> InsertClientAsync(Cliente cliente);
        Task<List<Cliente>> GetAllClientesAsync();
        Task<Cliente> GetClienteByIdAsync(int id);
        Task<bool> ExistClienteAsync(int id);
    }
}
