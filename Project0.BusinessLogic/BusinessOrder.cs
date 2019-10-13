using System;
using System.Collections.Generic;

namespace Project0.BusinessLogic
{
    public class BusinessOrder
    {
        private const int maxQtySize = 20;
        private const int maxLines = 50;
        public int Id { get; set; }
        public BusinessLocation StoreLocation { get; set; }
        public BusinessCustomer Customer { get; set; }
        public DateTime OrderTime { get; set; }
        public Dictionary<BusinessProduct, int> LineItems { get; set; } = new Dictionary<BusinessProduct, int>();
        public decimal Total
        {
            get
            {
                decimal sum = 0;
                foreach (var li in LineItems) sum += li.Key.Price * li.Value;
                return sum;
            }
        }
        private void ValidateEnoughLines()
        {
            if (LineItems.Keys.Count > maxLines)
            {
                throw new BusinessOrderException($"[!] Too many lines for this order");
            }
        }
        private void ValidateItemNotTooLarge(BusinessProduct product, int qty)
        {
            if (qty > maxQtySize)
            {
                throw new BusinessOrderException($"[!] {product} of quantity {qty} item too large");
            }
        }
        private void ValidateDecrementStock(BusinessProduct product, int qty)
        {
            StoreLocation.DecrementStock(product, qty);
        }
        public void AddLineItem(BusinessProduct product, int qty)
        {
            ValidateEnoughLines();
            ValidateItemNotTooLarge(product, qty);
            //ValidateDecrementStock(product, qty);
            LineItems.Add(product, qty);
        }

        public override string ToString()
        {
            String header = $"[Order {Id}]\n" +
                            $"{StoreLocation}\n" +
                            $"{Customer}\n" +
                            $"[Datetime] {OrderTime}\n";
            String body = "";
            foreach (var li in LineItems)
            {
                body += $"{li.Key} [Quantity] {li.Value}\n";
            }
            String footer = $"Sale Total: ${Total}";
            return $"{header}{body}{footer}\n";
        }
    }
}
