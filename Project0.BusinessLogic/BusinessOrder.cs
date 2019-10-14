using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.BusinessLogic
{
    public class BusinessOrder
    {
        private const int maxQuantity = 20;
        private const int maxLines = 30;
        public int Id { get; set; }
        public BusinessLocation StoreLocation { get; set; }
        public BusinessCustomer Customer { get; set; }
        public DateTime OrderTime { get; set; }
        public Dictionary<BusinessProduct, int> LineItems { get; } = new Dictionary<BusinessProduct, int>();

        public decimal Total
        {
            get
            {
                decimal sum = 0;
                foreach (var li in LineItems) sum += li.Key.Price * li.Value;
                return sum;
            }
        }

        private void ValidateNotTooManyLines()
        {
            if (LineItems.Count > maxLines)
            {
                throw new BusinessOrderException($"[!] Too many lines for this order");
            }
        }

        private void ValidateNotDuplicateProductId(int productId)
        {
            if (LineItems.Any(l => l.Key.Id == productId))
            {
                throw new BusinessOrderException($"[!] Duplicate product Id {productId}");
            }
        }

        private void ValidateQuantityGreaterThanZero(BusinessProduct product, int qty)
        {
            if (qty <= 0)
            {
                throw new BusinessOrderException($"[!] {product} of quantity {qty} item does not have a quantity greater than 0");
            }
        }

        private void ValidateQuantityBelowLimit(BusinessProduct product, int qty)
        {
            if (qty > maxQuantity)
            {
                throw new BusinessOrderException($"[!] {product} of quantity {qty} item has a quantity greater than {maxQuantity}");
            }
        }

        private void ValidateHasLines()
        {
            if (LineItems.Count == 0)
            {
                throw new BusinessOrderException($"[!] Order has no lines");
            }
        }

        public void AddLineItems(Dictionary<BusinessProduct, int> lineItems)
        {
            foreach (KeyValuePair<BusinessProduct, int> lineItem in lineItems)
            {
                ValidateNotTooManyLines();
                ValidateNotDuplicateProductId(lineItem.Key.Id);
                ValidateQuantityGreaterThanZero(lineItem.Key, lineItem.Value);
                ValidateQuantityBelowLimit(lineItem.Key, lineItem.Value);
                LineItems.Add(lineItem.Key, lineItem.Value);
            }
            ValidateHasLines();
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
            return $"{header}{body}{footer}";
        }
    }
}
