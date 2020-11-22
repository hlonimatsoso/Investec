using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Interfaces
{
    public interface IValidateOrder
    {
        bool ValidateOrder(Order oder);
        Order UpdateOrderVAT(Order order, double amount);
    }
}
