using BankAppIdentityProject.BusinessLayer.Abstract;
using BankAppIdentityProject.DataAccessLayer.Abstract;
using BankAppIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.BusinessLayer.Concrete
{
    public class GenericManager<T> : IGenericService<T> where T : class
    {
        private readonly IGenericDal<T> _customerAccountDal;

        public GenericManager(IGenericDal<T> customerAccountDal)
        {
            _customerAccountDal = customerAccountDal;
        }

        public async Task TAddAsync(T t)
        {
            await _customerAccountDal.AddAsync(t);
        }

        public void TDelete(T t)
        {
            _customerAccountDal.Delete(t);
        }

        public async Task<IEnumerable<T>> TGetAllAsync()
        {
            return await _customerAccountDal.GetAllAsync();
        }

        public async Task<T> TGetByIdAsync(int id)
        {
            return await _customerAccountDal.GetByIdAsync(id);
        }

        public void TUpdate(T t)
        {
            _customerAccountDal.Update(t);
        }
    }
}
