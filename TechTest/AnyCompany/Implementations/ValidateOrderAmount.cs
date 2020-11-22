using AnyCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Implementations
{
    public class ValidateOrderAmount : IValidateOrder
    {
        public Order UpdateOrderVAT(Order order, double amount)
        {
            order.VAT = amount;
            return order;
        }

        public bool ValidateOrder(Order order)
        {
            if (order == null)
                throw new ArgumentNullException("order", "Failed to Validate orders amount: Order may not be NULL");
            
            return order.Amount > 0;
        }
    }
}
