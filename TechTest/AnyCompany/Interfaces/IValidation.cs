using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Interfaces
{
   public interface IValidation
    {
        IList<IValidateCustomer> CustomerValidations { get; set; }

        IList<IValidateOrder> OrderValidations { get; set; }

        bool ProcessCustomerValidations(Customer customer, Order order);

        bool ProcessOrderValidations(Order customer);


    }
}
