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
        public Dictionary<Product, int> Products { get; set; } = new Dictionary<Product, int>();
        public void ValidateOrderNotTooLarge()
        {
            foreach (KeyValuePair<Product, int> entry in Products)
            {
                if (entry.Value > maxQtySize)
                {
                    throw new OrderException($"{entry.Key} order too large");
                }
            }
        }
        public void AddProduct(Product product, int qty)
        {
            try
            {
                ValidateOrderNotTooLarge();
                Products.Add(product, qty);
            }
            catch (OrderException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
