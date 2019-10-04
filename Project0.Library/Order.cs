using System;
using System.Collections.Generic;
using System.Text;

namespace Project0.Library
{
    class Order
    {
        public string StoreLocation { get; set; }
        public Customer Customer { get; set; }
        public string OrderTime { get; set; }
        public List<Product> Products { get; set; }
        public bool ValidateOrderNotTooLarge()
        {
            return true;
        }
    }
}
