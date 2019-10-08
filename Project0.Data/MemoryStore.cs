using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    public static class MemoryStore
    {
        static public List<Customer> Customers { get; set; } = new List<Customer>();
        static public List<Location> Locations { get; set; } = new List<Location>()
        {
            new Location()
                {
                    Address = "8 Winding Street",
                    City = "Hilly Glory",
                    Zipcode = 71550,
                    State = USState.AK
                },
            new Location()
                {
                    Address = "32 Bull",
                    City = "Ranch Plaza",
                    Zipcode = 90235,
                    State = USState.LA
                },
            new Location()
                {
                    Address = "192 Main",
                    City = "Shining Beacon",
                    Zipcode = 89567,
                    State = USState.SD
                },
            new Location()
                {
                    Address = "1 Bulldoze",
                    City = "Tractor Mania",
                    Zipcode = 23672,
                    State = USState.WV
                },
            new Location()
                {
                    Address = "906 Medical",
                    City = "Sierra Heights",
                    Zipcode = 45760,
                    State = USState.MA
                }
        };
        static public List<Order> Orders { get; set; }
        static public List<Product> Products { get; set; }
    }
}
