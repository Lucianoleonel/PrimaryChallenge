using Project.Abtractions;
using Project.Entities.Model;

namespace Project.DataAccess.Abstractions
{
    public interface ICustomerDbContext : IDbContext<CustomerEntity>
    {
        Task<IEnumerable<CustomerEntity>> GetbyCustomer(string nombre);
    }
}
