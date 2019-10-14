using Project0.BusinessLogic;
using Project0.DataAccess.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Project0.DataAccess
{
    public static class CustomerData
    {
        public static BusinessCustomer GetCustomerWithId(int customerId)
        {
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

        public static ICollection<BusinessCustomer> GetCustomersWithLastName(string lastName)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            List<BusinessCustomer> customersWithLastName = new List<BusinessCustomer>();
            foreach (Customer customer in context.Customer.Where(c => c.LastName.ToLower() == lastName.ToLower()))
            {
                BusinessCustomer bCustomer = GetCustomerWithId(customer.Id);
                customersWithLastName.Add(bCustomer);
            }
            return customersWithLastName;
        }

        public static void AddCustomer(BusinessCustomer customer)
        {
            using var context = new TThreeTeasContext(SQLOptions.options);

            Customer additionalCustomer = new Customer()
            {
                FirstName = customer.FirstName,
                LastName = customer.LastName
            };
            context.Customer.Add(additionalCustomer);
            context.SaveChanges();
        }
    }
}
