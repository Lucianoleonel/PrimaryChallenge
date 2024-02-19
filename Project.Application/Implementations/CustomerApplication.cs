using Project.Abtractions;
using Project.Application.Abstractions;
using Project.Entities.Model;
using Project.Repository.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Project.Application.Implementations
{
    public class CustomerApplication : Application<CustomerEntity>, ICustomerApplication
    {
        ICustomerRepository _customerRepository;

        public CustomerApplication(ICustomerRepository customerRepository)
                            : base(customerRepository)
        {
            _customerRepository = customerRepository;
        }


        #region Methods Repository

        #region Delete

        public int Delete(int id)
        {
            return _customerRepository.Delete(id);
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _customerRepository.DeleteAsync(id);
        }

        #endregion

        #region GetAll

        public IList<CustomerEntity> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public async Task<IList<CustomerEntity>> GetAllAsync()
        {
            return await _customerRepository.GetAllAsync();
        }

        #endregion

        #region Gets

        public CustomerEntity GetById(int id)
            => _customerRepository.GetById(id);
        
        public async Task<CustomerEntity> GetByIdAsync(int id)
            => await _customerRepository.GetByIdAsync(id);
        
        public async Task<IEnumerable<CustomerEntity>> GetbyCustomer(string nombre)
            => await _customerRepository.GetbyCustomer(nombre);
              
     
        #endregion

        #endregion
    }
}
