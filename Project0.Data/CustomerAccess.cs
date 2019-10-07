using Project0.Logic;
using System.Collections.Generic;

namespace Project0.Data
{
    public class CustomerAccess
    {
        public static void AddCustomer(string firstName, string lastName)
        {
            Customer customer = new Customer(firstName, lastName);
            MemoryStore.Customers.Add(customer);
        }

        public static void RemoveCustomer(int id)
        {
            //MemoryStore.Customers.remove(id);
        }

        public static Customer GetCustomerById(int id)
        {
            //return MemoryStore.Customers.get(id);
            return null;
        }

        public static int GetNumberOfCustomers()
        {
            return MemoryStore.Customers.Count;
        }
    }
}