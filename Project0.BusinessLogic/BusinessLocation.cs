using System.Collections.Generic;
using System.Linq;

namespace Project0.BusinessLogic
{
    public class BusinessLocation
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Zipcode { get; set; }
        public string State { get; set; }
        public Dictionary<BusinessProduct, int> inventory = new Dictionary<BusinessProduct, int>();

        public void AddProduct(BusinessProduct bProduct, int stock)
        {
            inventory.Add(bProduct, stock);
        }

        public override string ToString()
        {
            return $"[Location {Id}] {Address}, {City}, {State}, {Zipcode}";
        }

        public string ToStringInventory()
        {
            string str = $"[Inventory]\n";
            foreach (KeyValuePair<BusinessProduct, int> item in inventory)
            {
                str += $"{item.Key} [Quantity] {item.Value}\n";
            }
            return str;
        }

        public void DecrementStock(BusinessProduct bProduct, int qty)
        {
            if (!inventory.Keys.Any(p => p.Id == bProduct.Id))
            {
                throw new BusinessLocationException($"[!] Location does not have {bProduct} in stock");
            }

            BusinessProduct selectedProduct = inventory.Keys.Where(p => p.Id == bProduct.Id).FirstOrDefault();

            if (qty > inventory[selectedProduct])
            {
                throw new BusinessLocationException($"[!] Location {Id} does not have {selectedProduct} with {qty} stock, only has {inventory[selectedProduct]} in stock");
            }
            inventory[selectedProduct] -= qty;
        }
    }
}
