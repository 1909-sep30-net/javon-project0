using System;
using System.Collections.Generic;

namespace Project0.Logic
{
    public class Order
    {
        private const int maxQtySize = 10;
        public Location StoreLocation { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Dictionary<Product, int> LineItems { get; set; } = new Dictionary<Product, int>();
        public void ValidateItemNotTooLarge(Product product, int qty)
        {
            if (qty > maxQtySize)
            {
                throw new OrderException($"{product} of quantity {qty} item too large");
            }
        }
        public void AddProduct(Product product, int qty)
        {
            ValidateItemNotTooLarge(product, qty);
            LineItems.Add(product, qty);
        }
    }
}
