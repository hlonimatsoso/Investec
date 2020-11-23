using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace AnyCompany
{
    internal class OrderRepository
    {
        private static string ConnectionString = Constants.OrdersConnectionString;

        public void Save(Order order)
        {
            SqlConnection connection = default;
            try
            {
                connection = new SqlConnection(ConnectionString);
                connection.Open();

                SqlCommand command = new SqlCommand("INSERT INTO Orders VALUES (@OrderId, @Amount, @VAT)", connection);

                command.Parameters.AddWithValue("@OrderId", order.OrderId);
                command.Parameters.AddWithValue("@Amount", order.Amount);
                command.Parameters.AddWithValue("@VAT", order.VAT);

                command.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Error saving order ID '{order?.OrderId}'", ex);
            }
            finally
            {
                connection?.Close();
            }

        }

        public List<Order> LoadOrdersForCustomer(int customerId)
        {
            List<Order> orders = new List<Order>();

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
                    orders.Add(new Order
                    {
                        OrderId = (int)reader["OrderID"],
                        Amount = (int)reader["Amount"],
                        VAT = (double)reader["VAT"],
                        Customer = new Customer { CustomerID = customerId }
                    });


                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error loading orders for customerId '{customerId}'. Error Message: {ex.Message}", ex);
            }
            finally
            {
                connection?.Close();

            }


            return orders;
        }
    }
}
