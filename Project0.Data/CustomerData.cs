using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    public class CustomerData
    {
        public static void AddCustomer(Customer cust)
        {
            MemoryStore.Customers.Add(cust);
        }

        public static List<Customer> GetCustomersByFirstAndLastName(string firstName, string lastName)
        {
            List<Customer> customers = new List<Customer>();
            foreach (Customer customer in MemoryStore.Customers)
            {
                if (customer.FirstName.Equals(firstName) && customer.LastName.Equals(lastName))
                {
                    customers.Add(customer);
                }
            }

            return customers;
        }
    }
}