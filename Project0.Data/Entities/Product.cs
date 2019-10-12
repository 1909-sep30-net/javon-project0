using System;
using System.Collections.Generic;

namespace Project0.Data.Entities
{
    public partial class Product
    {
        public Product()
        {
            Inventory = new HashSet<Inventory>();
            LineItem = new HashSet<LineItem>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public virtual ICollection<Inventory> Inventory { get; set; }
        public virtual ICollection<LineItem> LineItem { get; set; }
    }
}
