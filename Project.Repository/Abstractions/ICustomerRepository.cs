using Project.Abtractions;
using Project.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository.Abstractions
{
    public interface ICustomerRepository : IRepository<CustomerEntity>
    {
        Task<IEnumerable<CustomerEntity>> GetbyCustomer(string city);
    }
}
