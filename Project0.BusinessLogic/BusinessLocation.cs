using System.Collections.Generic;

namespace Project0.BusinessLogic
{
    public class BusinessLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        private Dictionary<BusinessProduct, int> inventory = new Dictionary<BusinessProduct, int>();

        public void AddProduct(BusinessProduct product, int stock)
        {
            inventory.Add(product, stock);
        }

        public override string ToString()
        {
            return $"[Location {Id}] {Address}, {City}, {State}, {Zipcode}";
        }

        internal void DecrementStock(BusinessProduct product, int qty)
        {
            if (inventory.ContainsKey(product))
            {
                throw new BusinessLocationException($"[!] Location does not have {product} in stock");
            }

            if (inventory[product] < qty)
            {
                throw new BusinessLocationException($"[!] Location does not have {product} with {qty} stock, only has {inventory[product]} in stock");
            }
            inventory[product] -= qty;
        }
    }
}
