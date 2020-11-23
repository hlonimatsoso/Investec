using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany
{
    public static class Constants
    {
        // TODO: Move to config file
        public static string CustomersConnectionString = @"Data Source=(local);Database=Customers;User Id=admin;Password=password;";


        public static string OrdersConnectionString = @"Data Source=(local);Database=Orders;User Id=admin;Password=password;";

        
        public static string LoadCustomersQuery = "SELECT * FROM Customer C  WHERE CustomerId = ";
    }
}
