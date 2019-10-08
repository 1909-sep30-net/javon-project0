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

        public static List<Customer> GetCustomersByLastName(string lastName)
        {
            List<Customer> customersWithLastName = new List<Customer>();
            foreach (Customer customer in MemoryStore.Customers)
            {
                if (customer.LastName.Equals(lastName))
                {
                    customersWithLastName.Add(customer);
                }
            }

            return customersWithLastName;
        }
    }
}