﻿namespace AnyCompany
{
    public class Order
    {
        public int OrderId { get; set; }

        public double Amount { get; set; }
        
        public double VAT { get; set; }

        public Customer Customer { get; set; }
    }
}
