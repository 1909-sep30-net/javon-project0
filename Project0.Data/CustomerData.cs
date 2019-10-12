using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project0.Data.Entities;
using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    public static class CustomerData
    {
        public static readonly ILoggerFactory AppLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        //public static void AddCustomer(Customer cust)
        //{
        //    MemoryStore.Customers.Add(cust);
        //}

        public static ICollection<BusinessCustomer> GetCustomersByLastName(BusinessCustomer customer)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
            .UseSqlServer(SecretConfiguration.ConnectionString)
            .UseLoggerFactory(AppLoggerFactory)
            .Options;
            using var context = new TThreeTeasContext(options);

            List<BusinessCustomer> customersWithLastName = new List<BusinessCustomer>();
            foreach (Customer c in context.Customer)
            {
                if (c.LastName.ToLower() == customer.LastName.ToLower())
                {
                    customersWithLastName.Add(new BusinessCustomer() {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    });
                }
            }
            return customersWithLastName;
        }
    }
}