using AnyCompany.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Implementations
{
    class InvestecRepo : IInvestecRepo
    {
        OrderRepository _orderRepo;



        public InvestecRepo()
        {
            this._orderRepo = InvestecFactory.GetOrderRepository();

            this.CustomerValidations = new List<IValidateCustomer> { InvestecFactory.GetValidateCustomerFromUSValidator() };
            this.OrderValidations = new List<IValidateOrder> { InvestecFactory.GetValidateOrderAmountValidator() };

        }

        public IList<IValidateCustomer> CustomerValidations { get; set; }
        public IList<IValidateOrder> OrderValidations { get; set; }

        public Customer LoadCustomer(int customerId)
        {
            return CustomerRepository.Load(customerId);
        }

        public bool ProcessCustomerValidations(Customer customer,  Order order)
        {
            bool result = default;

            foreach (IValidateCustomer validation in this.CustomerValidations)
            {
                result = validation.ValidateCustomer(customer, order);
                if (!result)
                    return false;
            }


            return result;
        }

        public bool ProcessOrderValidations(Order customer)
        {

            bool result = default;

            foreach (IValidateOrder validation in this.OrderValidations)
            {
                result = validation.ValidateOrder(customer);
                if (!result)
                    return false;
            }

            return result;
        }

        public void Save(Order order)
        {
            this._orderRepo.Save(order);
        }

    }
}
