using System.Collections.Generic;
using Project0.Logic;

namespace Project0.Data
{
    public static class MemoryStore
    {
        static public List<Customer> Customers { get; set; } = new List<Customer>();
        static public List<Location> Locations { get; set; }
        static public List<Order> Orders { get; set; }
        static public List<Product> Products { get; set; }
    }
}
