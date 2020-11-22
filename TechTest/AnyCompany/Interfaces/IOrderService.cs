using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Interfaces
{
    public interface IOrderService
    {
        IInvestecRepo Repo { get; set; }
        bool PlaceOrder(Order order, int customerId);
    }
}
