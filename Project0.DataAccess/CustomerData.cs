using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class CustomerData
    {
        public static readonly ILoggerFactory AppLoggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        public static void AddCustomer(BusinessCustomer cust)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            Customer newCustomer = new Customer()
            {
                FirstName = cust.FirstName,
                LastName = cust.LastName
            };
            context.Customer.Add(newCustomer);
            context.SaveChanges();
        }

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
                    customersWithLastName.Add(new BusinessCustomer()
                    {
                        Id = c.Id,
                        FirstName = c.FirstName,
                        LastName = c.LastName
                    });
                }
            }
            return customersWithLastName;
        }

        public static bool CustomerExistsById(int cId)
        {
            DbContextOptions<TThreeTeasContext> options = new DbContextOptionsBuilder<TThreeTeasContext>()
                .UseSqlServer(SecretConfiguration.ConnectionString)
                .UseLoggerFactory(CustomerData.AppLoggerFactory)
                .Options;
            using var context = new TThreeTeasContext(options);

            Customer customer = context.Customer.Where(c => c.Id == cId).FirstOrDefault();
            return !(customer is null);
        }
    }
}