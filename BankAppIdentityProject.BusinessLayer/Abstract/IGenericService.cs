using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TAddAsync(T t);
        Task<IEnumerable<T>> TGetAllAsync();
        void TUpdate(T t);
        void TDelete(T t);
        Task<T> TGetByIdAsync(int id);
    }
}
