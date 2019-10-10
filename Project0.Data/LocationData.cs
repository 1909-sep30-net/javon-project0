using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    class LocationData
    {
        public static List<Location> getLocations()
        {
            return MemoryStore.Locations;
        }
    }
}
