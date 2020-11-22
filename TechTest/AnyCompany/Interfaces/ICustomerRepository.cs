using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Interfaces
{
    public interface ICustomerRepository
    {
         Customer LoadCustomer(int customerId);

        bool ValidateCustomer(Customer customer);
    }
}
