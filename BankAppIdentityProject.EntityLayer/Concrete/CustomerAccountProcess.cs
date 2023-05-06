using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessID { get; set; }
        public int ProcessType { get; set; }
        public decimal  Amount { get; set; }
        public DateTime ProcessDate { get; set; }
    }
}
