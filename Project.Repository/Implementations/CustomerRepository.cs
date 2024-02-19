using Project.DataAccess.Abstractions;
using Project.Entities.Model;
using Project.Repository.Abstractions;

namespace Project.Repository.Implementations
{

    public class CustomerRepository : Repository<CustomerEntity>, ICustomerRepository
    {
        ICustomerDbContext _ctx;

        public CustomerRepository(ICustomerDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<CustomerEntity>> GetbyCustomer(string nombre)
            => await _ctx.GetbyCustomer(nombre);

    }
}
