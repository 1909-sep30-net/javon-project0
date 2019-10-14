using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    /// <summary>
    /// DataAccess static class for retrieving and updating the Location objects in the database.
    /// </summary>
    public static class LocationData
    {
        /// <summary>
        /// Retrieves the location with the given location id.
        /// </summary>
        /// <param name="locationId">The id of the location</param>
        /// <returns>
        /// The BusinessLocation object that maps to the location with the given location id
        /// </returns>
        public static BusinessLocation GetLocationWithId(int locationId)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            Location location = context.Location.Where(l => l.Id == locationId).FirstOrDefault();
            if (location is null)
            {
                return null;
            }

            BusinessLocation bLocation = new BusinessLocation()
            {
                Id = location.Id,
                Address = location.Address,
                City = location.City,
                Zipcode = location.Zipcode,
                State = location.State
            };

            List<Inventory> inventories = context.Inventory.Where(i => i.LocationId == location.Id).ToList();
            foreach (Inventory inventory in inventories)
            {
                Product product = context.Product.Where(p => p.Id == inventory.ProductId).FirstOrDefault();
                BusinessProduct bProduct = new BusinessProduct()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Price = product.Price
                };
                bLocation.AddProduct(bProduct, inventory.Stock);
            }

            return bLocation;
        }

        /// <summary>
        /// Retrieves all of the locations in the database.
        /// </summary>
        /// <returns>All BusinessLocation objects in the database</returns>
        public static ICollection<BusinessLocation> GetLocations()
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessLocation> bLocations = new List<BusinessLocation>();
            foreach (Location location in context.Location)
            {
                BusinessLocation bLocation = GetLocationWithId(location.Id);
                bLocations.Add(bLocation);
            }
            return bLocations;
        }
    }
}
