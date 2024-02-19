using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Primary.Infrastructure.Abstractions
{

    public interface ICrudAsync<T>
    {
        Task<Tuple<int, T>> SaveAsync(T entity);
        Task<IList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> DeleteAsync(int id);
        Task<int> UpdateAsync(T entity);
        Task<Tuple<int, T>> UpdateReturnResultAsync(T entity);
    }

    public interface ICrud<T> : ICrudAsync<T>
    {
        Tuple<int, T> Save(T entity);
        IList<T> GetAll();
        T GetById(int id);
        int Delete(int id);
        int Update(T entity);
        Tuple<int, T> UpdateReturnResult(T entity);
    }
}
