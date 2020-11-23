using AnyCompany.Implementations;
using AnyCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public static class InvestecFactory
    {
        internal static OrderRepository GetOrderRepository()
        {
            return new OrderRepository();
        }

        public static IValidateCustomer GetValidateCustomerFromUSValidator()
        {
            return new ValidateCustomerFromUK();
        }


        public static IValidateOrder GetValidateOrderAmountValidator()
        {
            return new ValidateOrderAmount();
        }


        public static IInvestecRepo GetInvestecRepo()
        {
            return new InvestecRepo();
        }

    }
}
