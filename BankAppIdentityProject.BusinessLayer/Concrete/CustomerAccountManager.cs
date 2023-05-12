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
    public class CustomerAccountManager : GenericManager<CustomerAccount>, ICustomerAccountService
    {
        public CustomerAccountManager(IGenericDal<CustomerAccount> customerAccountDal) : base(customerAccountDal)
        {
        }
    }
}
