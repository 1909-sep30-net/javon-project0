using System;
using System.Collections.Generic;

namespace Project0.Logic
{
    public class Order
    {
        private const int maxQtySize = 10;
        public int Id { get; set; }
        public Location StoreLocation { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDateTime { get; set; }
        public Dictionary<Product, int> LineItems { get; set; } = new Dictionary<Product, int>();
        public double Total
        {
            get
            {
                double sum = 0;
                foreach (var li in LineItems) sum += li.Key.Price * li.Value;
                return sum;
            }
        }
        private void ValidateItemNotTooLarge(Product product, int qty)
        {
            if (qty > maxQtySize)
            {
                throw new OrderException($"[!] {product} of quantity {qty} item too large");
            }
        }
        public void AddLineItem(Product product, int qty)
        {
            ValidateItemNotTooLarge(product, qty);
            LineItems.Add(product, qty);
        }

        public override String ToString()
        {
            String header = $"[Order] ({Id})\n" +
                            $"[Location] {StoreLocation}\n" +
                            $"[Customer] {Customer}\n" +
                            $"[Datetime] {OrderDateTime}\n";
            String body = "";
            foreach (var li in LineItems)
            {
                body += $"[Product] ({li.Key.Id}) [Name] {li.Key.Name} [Price] ${li.Key.Price} [Quantity] {li.Value}\n";
            }
            String footer = $"Total: ${Total}";
            return header + body + footer;
        }
    }
}
