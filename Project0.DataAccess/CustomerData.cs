using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using Serilog;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    /// <summary>
    /// DataAccess static class for retrieving and updating the Customer objects in the database.
    /// </summary>
    public static class CustomerData
    {
        /// <summary>
        /// Retrieves the customer with the given customer id.
        /// </summary>
        /// <param name="customerId">The id of the customer</param>
        /// <returns>
        /// BusinessCustomer object that the Customer maps to with the given customer id
        /// </returns>
        public static BusinessCustomer GetCustomerWithId(int customerId)
        {
            Log.Information($"Called the Data Access method to get the customer with customer id {customerId}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            Customer customer = context.Customer.Where(c => c.Id == customerId).FirstOrDefault();
            if (customer is null)
            {
                return null;
            }

            BusinessCustomer bCustomer = new BusinessCustomer()
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            return bCustomer;
        }

        /// <summary>
        /// Retrieves the customers with the given last name
        /// </summary>
        /// <param name="lastName">The last name of the customer</param>
        /// <returns>BusinessCustomer object that the Customer maps to with the given last name</returns>
        public static ICollection<BusinessCustomer> GetCustomersWithLastName(string lastName)
        {
            Log.Information($"Called the Data Access method to get the customers with last name {lastName}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessCustomer> customersWithLastName = new List<BusinessCustomer>();
            foreach (Customer customer in context.Customer.Where(c => c.LastName.ToLower() == lastName.ToLower()))
            {
                BusinessCustomer bCustomer = GetCustomerWithId(customer.Id);
                customersWithLastName.Add(bCustomer);
            }
            return customersWithLastName;
        }

        /// <summary>
        /// Adds a customer to the database.
        /// </summary>
        /// <param name="bCustomer">The customer to add to the database</param>
        public static void AddCustomer(BusinessCustomer bCustomer)
        {
            Log.Information($"Called the Data Access method to add the customer {bCustomer}");
            using var context = new TThreeTeasContext(SQLOptions.options);

            Customer additionalCustomer = new Customer()
            {
                FirstName = bCustomer.FirstName,
                LastName = bCustomer.LastName
            };
            context.Customer.Add(additionalCustomer);
            context.SaveChanges();
        }
    }
}
