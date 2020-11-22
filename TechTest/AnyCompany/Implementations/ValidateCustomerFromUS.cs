using AnyCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Implementations
{
    public class ValidateCustomerFromUS : IValidateCustomer
    {
        public bool ValidateCustomer(Customer customer, Order order)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Failed to validate customers VAT: Customer may not be NULL");
            
            if (customer.Country == "US")
                order.VAT = 1;
            else
                order.VAT = 0;

            return true;
        }
    }
}
