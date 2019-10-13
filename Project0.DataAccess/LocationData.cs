using Microsoft.EntityFrameworkCore;
using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class LocationData
    {
        public static ICollection<BusinessLocation> GetLocations()
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(CustomerData.AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            List<BusinessLocation> bLocations = new List<BusinessLocation>();
            foreach (Location l in context.Location)
            {
                bLocations.Add(new BusinessLocation()
                {
                    Id = l.Id,
                    Address = l.Address,
                    City = l.City,
                    Zipcode = l.Zipcode,
                    State = l.State
                });
            }
            return bLocations;
        }

        public static bool LocationExistsById(int lId)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(CustomerData.AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            Location location = context.Location.Where(l => l.Id == lId).FirstOrDefault();
            return !(location is null);
        }
    }
}
