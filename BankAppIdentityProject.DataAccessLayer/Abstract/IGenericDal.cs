using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task AddAsync(T t);
        Task<IEnumerable<T>> GetAllAsync();
        void Update(T t);
        void Delete(T t);
        Task<T> GetByIdAsync(int id);
    }
}
