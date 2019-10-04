using System.Collections.Generic;

namespace Project0.Logic
{
    public class Order
    {
        public string StoreLocation { get; set; }
        public Customer Customer { get; set; }
        public string OrderDateTime { get; set; }
        public List<Product> Products { get; set; }
        public bool ValidateOrderNotTooLarge()
        {
            return Products.Count > 20;
        }

        public Order(string storeLocation, Customer customer, string orderDateTime)
        {
            this.StoreLocation = storeLocation;
            this.Customer = customer;
            this.OrderDateTime = orderDateTime;
        }

        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
