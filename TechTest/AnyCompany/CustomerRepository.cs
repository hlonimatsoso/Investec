using System;
using System.Data.SqlClient;

namespace AnyCompany
{
    public static class CustomerRepository
    {
        private static string ConnectionString = Constants.CustomersConnectionString;

        public static Customer Load(int customerId)
        {
            Customer customer = new Customer();
            OrderRepository ordersRepo = InvestecFactory.GetOrderRepository();

            SqlConnection connection = default;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand(Constants.LoadCustomersQuery + customerId,
                    connection);
                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    customer.Name = reader["Name"].ToString();
                    customer.DateOfBirth = DateTime.Parse(reader["DateOfBirth"].ToString());
                    customer.Country = reader["Country"].ToString();
                    customer.Orders = ordersRepo.LoadOrdersForCustomer(customerId);
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading customerId '{customerId}'. Error Message: {ex.Message}", ex);
            }
            finally
            {
                connection?.Close();

            }


            return customer;
        }
    }
}
