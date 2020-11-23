using AnyCompany.Implementations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnyCompany.Tests
{
    [TestFixture]
    public class CustomerValidattionTests
    {
        [Test]
        public void TestCustomerFromUK_UK_Customer()
        {
            // Assemble

            ValidateCustomerFromUK validator = new ValidateCustomerFromUK();
            Customer customer = new Customer { Country = "UK" };
            double initialVAT = 100d;
            Order order = new Order { VAT = initialVAT};
            Order expected = new Order { VAT = 0.2d};


            // Act

            Assert.AreEqual(order.VAT, initialVAT);

            bool result = validator.ValidateCustomer(customer, order);

            // Aseert
           
            Assert.AreEqual(expected.VAT, order.VAT, $"Sorry buddy, expected {expected.VAT} for UK customers, but got {order.VAT}");

        }

        [Test]
        public void TestCustomerFromUK_SA_Customer()
        {
            // Assemble

            ValidateCustomerFromUK validator = new ValidateCustomerFromUK();
            Customer customer = new Customer { Country = "SA" };
            double initialVAT = 100d;
            Order order = new Order { VAT = initialVAT };
            Order expected = new Order { VAT = 0.0d };


            // Act

            Assert.AreEqual(order.VAT, initialVAT);

            bool result = validator.ValidateCustomer(customer, order);

            // Aseert

            Assert.AreEqual(expected.VAT, order.VAT, $"Sorry buddy, expected {expected.VAT} for SA customers, but got {order.VAT}");

        }

        [Test]
        public void TestCustomerFromUK_NullCustomer()
        {
            // Assemble

            ValidateCustomerFromUK validator = new ValidateCustomerFromUK();
            Customer customer = null;
            Order order = new Order { };
            

            // Act

            // Aseert
            // Assert.Throws<ArgumentNullException>(new TestDelegate(validator.ValidateCustomer(customer, order)),"WTF");
            
        }
    }
}
