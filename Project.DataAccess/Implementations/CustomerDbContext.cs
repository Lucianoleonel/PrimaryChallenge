using Project.DataAccess.Abstractions;
using Project.Entities.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DataAccess.Implementations
{
    public class CustomerDbContext : DbContext<CustomerEntity>, ICustomerDbContext
    {
        protected ApiDbContext _ctx;
        public CustomerDbContext(ApiDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        #region Implemented Methods
        public async Task<IEnumerable<CustomerEntity>> GetbyCustomer(string nombre)
            => _ctx.Customer.Where(n => n.Name == nombre);


        #endregion

    }
}
