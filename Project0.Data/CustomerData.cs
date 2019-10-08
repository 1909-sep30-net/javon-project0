using System;
using Project0.Logic;

namespace Project0.Data
{
    public class CustomerData
    {
        public static void AddCustomer(string firstName, string lastName)
        {
            MemoryStore.Customers.Add(new Customer(firstName, lastName));
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