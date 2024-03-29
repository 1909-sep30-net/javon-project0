﻿using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// The Order object for the Business Logic. Upon creation, validates the order data and allows
    /// methods to add lineitems to the order and validates these line items.
    /// </summary>
    public class BusinessOrder
    {
        private const int maxQuantity = 20;
        private const int maxLines = 30;
        public int Id { get; set; }
        public BusinessLocation StoreLocation { get; set; }
        public BusinessCustomer Customer { get; set; }
        public DateTime OrderTime { get; set; }
        public Dictionary<BusinessProduct, int> LineItems { get; } = new Dictionary<BusinessProduct, int>();

        /// <summary>
        /// Returns the total sale of the order.
        /// </summary>
        public decimal Total
        {
            get
            {
                decimal sum = 0;
                foreach (var li in LineItems) sum += li.Key.Price * li.Value;
                return sum;
            }
        }

        /// <summary>
        /// Validates that the order does not have too many line items. Throws an exception if it does.
        /// </summary>
        private void ValidateNotTooManyLines()
        {
            if (LineItems.Count > maxLines)
            {
                throw new BusinessOrderException($"[!] Too many lines for this order");
            }
        }

        /// <summary>
        /// Validates that the order does not have a duplicate product ID in the line items. Throws
        /// an exception if it does.
        /// </summary>
        /// <param name="productId"></param>
        private void ValidateNotDuplicateProductId(int productId)
        {
            if (LineItems.Any(l => l.Key.Id == productId))
            {
                throw new BusinessOrderException($"[!] Duplicate product Id {productId}");
            }
        }

        /// <summary>
        /// Validates the quantity of the line item is greater than zero. Throws an exception if it
        /// is not.
        /// </summary>
        /// <param name="product">The product of the line item to validate</param>
        /// <param name="qty">The quantity of the line item</param>
        private void ValidateQuantityGreaterThanZero(BusinessProduct product, int qty)
        {
            if (qty <= 0)
            {
                throw new BusinessOrderException($"[!] {product} of quantity {qty} item does not have a quantity greater than 0");
            }
        }

        /// <summary>
        /// Validates that the quantity of the line item is less than the limit. Throws an exception
        /// if it is not.
        /// </summary>
        /// <param name="product">The product of the line item to validate</param>
        /// <param name="qty">The quantity of the line item</param>
        private void ValidateQuantityBelowLimit(BusinessProduct product, int qty)
        {
            if (qty > maxQuantity)
            {
                throw new BusinessOrderException($"[!] {product} of quantity {qty} item has a quantity greater than {maxQuantity}");
            }
        }

        /// <summary>
        /// Validates that the order has at least one line. Throws an exception if it does not.
        /// </summary>
        private void ValidateHasLines()
        {
            if (LineItems.Count == 0)
            {
                throw new BusinessOrderException($"[!] Order has no lines");
            }
        }

        /// <summary>
        /// Adds a list of line items to this order and validates these line items.
        /// </summary>
        /// <param name="lineItems">The list of line items</param>
        public void AddLineItems(Dictionary<BusinessProduct, int> lineItems)
        {
            Log.Information($"Adding line items {lineItems}");
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

        /// <summary>
        /// Returns the id, store location, customer, order time, line items, and sale total in
        /// string format.
        /// </summary>
        /// <returns>The id, store location, customer, order time, line items, and sale total</returns>
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
