using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    public static class CustomerData
    {
        public static void AddCustomer(Customer cust)
        {
            MemoryStore.Customers.Add(cust);
        }

        public static List<Customer> GetCustomersByLastName(Customer customer)
        {
            List<Customer> customersWithLastName = new List<Customer>();
            foreach (Customer c in MemoryStore.Customers)
            {
                if (c.LastName == customer.LastName)
                {
                    customersWithLastName.Add(c);
                }
            }

            return customersWithLastName;
        }
    }
}