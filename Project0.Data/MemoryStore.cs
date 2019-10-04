using System.Collections.Generic;
using Project0;

namespace Project0.Logic
{
    static class MemoryStore
    {
        static public List<Customer> Customers { get; set; }
        static public List<Location> Locations { get; set; }
        static public List<Order> Orders { get; set; }
        static public List<Product> Products { get; set; }
    }
}
