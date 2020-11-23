using AnyCompany.Implementations;
using AnyCompany.Interfaces;
using System;

namespace AnyCompany
{
    public class OrderService : IOrderService
    {
        public IInvestecRepo Repo { get; set; }



        public OrderService()
        {
            this.Repo = InvestecFactory.GetInvestecRepo();
        }


        public bool PlaceOrder(Order order, int customerId)
        {
            bool isValidCustomer, isValidOrder;
            bool result = false;
            Customer customer = null;
            try
            {

                // Validate order
                isValidOrder = Repo.ProcessOrderValidations(order);

                //load customer
                customer = this.Repo.LoadCustomer(customerId);

                // Validate customer
                isValidCustomer = Repo.ProcessCustomerValidations(customer, order);

                // Save order
                if (isValidCustomer && isValidOrder)
                    Repo.Save(order);
            }
            catch (System.Exception ex)
            {

                throw new Exception($"Error placing order ID '{order?.OrderId}' for customer {customer?.Name} (customer ID: {customerId})", ex);
            }

            return true;
        }

    }
}
