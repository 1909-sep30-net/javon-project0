using System;
using Project0.Logic;

namespace Project0.Data
{
    public class CustomerAccess
    {
        public static void AddCustomer(Customer customer)
        {
            MemoryStore.Customers.Add(customer);
        }

        public static Customer GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            foreach (Customer customer in MemoryStore.Customers)
            {
                if (customer.FirstName.Equals(firstName) && customer.LastName.Equals(lastName))
                {
                    return customer;
                }
            }

            return null;
        }
    }
}