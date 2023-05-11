using BankAppIdentityProject.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.DataAccessLayer.Abstract
{
    public interface ICustomerAccountDal:IGenericDal<CustomerAccount>
    {
    }
}
