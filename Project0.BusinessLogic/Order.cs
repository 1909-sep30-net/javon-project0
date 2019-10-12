using System;
using System.Collections.Generic;

namespace Project0.BusinessLogic
{
    public class Order
    {
        private const int maxQtySize = 20;
        private const int maxLines = 50;
        public int Id { get; set; }
        public Location StoreLocation { get; set; }
        public BusinessCustomer Customer { get; set; }
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
        private void ValidateEnoughLines()
        {
            if (LineItems.Keys.Count > maxLines)
            {
                throw new OrderException($"[!] Too many lines for this order");
            }
        }
        private void ValidateItemNotTooLarge(Product product, int qty)
        {
            if (qty > maxQtySize)
            {
                throw new OrderException($"[!] {product} of quantity {qty} item too large");
            }
        }
        private void ValidateDecrementStock(Product product, int qty)
        {
            StoreLocation.DecrementStock(product, qty);
        }
        public void AddLineItem(Product product, int qty)
        {
            ValidateEnoughLines();
            ValidateItemNotTooLarge(product, qty);
            ValidateDecrementStock(product, qty);
            LineItems.Add(product, qty);
        }

        public override string ToString()
        {
            String header = $"[Order {Id}]\n" +
                            $"{StoreLocation}\n" +
                            $"{Customer}\n" +
                            $"[Datetime] {OrderDateTime}\n";
            String body = "";
            foreach (var li in LineItems)
            {
                body += $"{li.Key} [Quantity] {li.Value}\n";
            }
            String footer = $"Total: ${Total}";
            return header + body + footer;
        }
    }
}
