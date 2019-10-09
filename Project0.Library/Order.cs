﻿using System;
using System.Collections.Generic;

namespace Project0.Logic
{
    public class Order
    {
        public Location StoreLocation { get; set; }
        public Customer Customer { get; set; }
        public DateTime OrderDateTime { get; set; }
        public List<Product> Products { get; set; }
        public bool ValidateOrderNotTooLarge()
        {
            return Products.Count > 20;
        }
        public void AddProduct(Product product)
        {
            Products.Add(product);
        }
    }
}
