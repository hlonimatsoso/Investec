using AnyCompany.Implementations;
using AnyCompany.Interfaces;

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

            // Validate order
            isValidOrder = Repo.ProcessOrderValidations(order);

            //load customer
            Customer customer = this.Repo.LoadCustomer(customerId);

            // Validate customer
            isValidCustomer = Repo.ProcessCustomerValidations(customer, order);

            // Save order
            if (isValidCustomer && isValidOrder)
                Repo.Save(order);

            return true;
        }

    }
}
