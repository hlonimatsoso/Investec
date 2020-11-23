using AnyCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Implementations
{
    public class ValidateCustomerFromUK : IValidateCustomer
    {
        public bool ValidateCustomer(Customer customer, Order order)
        {
            if (customer == null)
                throw new ArgumentNullException("customer", "Failed to validate customer: Customer may not be NULL");

            if (order == null)
                throw new ArgumentNullException("order", "Failed to validate customers: Customers Order may not be NULL");

            if (customer.Country == "UK")
                order.VAT = 0.2d;
            else
                order.VAT = 0;

            return true;
        }
    }
}
