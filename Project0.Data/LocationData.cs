using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    public class LocationData
    {
        public static List<Location> GetLocations()
        {
            return MemoryStore.Locations;
        }
    }
}
