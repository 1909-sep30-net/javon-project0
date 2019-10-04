using Project0.Logic;

namespace Project0.Data
{
    public class CustomerAccess
    {
        public static void AddCustomer(string firstName, string lastName)
        {
            MemoryStore.Customers.Add(new Customer(firstName, lastName));
        }

        public static void RemoveCustomer(int id)
        {
            MemoryStore.Customers.remove(id);
        }

        public static Customer GetCustomerById(int id)
        {
            return MemoryStore.Customers.get(id);
        }

        public static int GetNumberOfCustomers()
        {
            return MemoryStore.Customers.Count;
        }
    }
}