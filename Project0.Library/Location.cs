﻿using System;
using System.Collections.Generic;

namespace Project0.Logic
{
    public class Location
    {
        private int id;
        private string address;
        private string city;
        private int zipcode;
        private USState state;
        private Dictionary<Product, int> inventory = new Dictionary<Product, int>();
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        public string Address
        {
            get => address;
            set
            {
                address = value;
            }
        }
        public string City
        {
            get => city;
            set
            {
                city = value;
            }
        }
        public int Zipcode
        {
            get => zipcode;
            set
            {
                zipcode = value;
            }
        }
        public USState State
        {
            get => state;
            set
            {
                state = value;
            }
        }
        public void AddProduct(Product product, int stock)
        {
            inventory.Add(product, stock);
        }

        public override string ToString()
        {
            String str = $"[Location {Id}] {Address}, {City}, {State}, {Zipcode}\n" +
                   $"[Inventory]\n";
            foreach (var stock in inventory)
            {
                str += $"{stock.Key} [Quantity] {stock.Value}\n";
            }

            return str;
        }

        internal void DecrementStock(Product product, int qty)
        {
            if (inventory.ContainsKey(product))
            {
                throw new LocationException($"[!] Location does not have {product} in stock");
            }

            if (inventory[product] < qty)
            {
                throw new LocationException($"[!] Location does not have {product} with {qty} stock, only has {inventory[product]} in stock");
            }
            inventory[product] -= qty;
        }
    }
}
