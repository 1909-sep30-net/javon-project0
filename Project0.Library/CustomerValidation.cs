using Project0.Data;
using System;

namespace Project0.Logic
{
    public static class CustomerValidation
    {
        public static void AddCustomer(string firstName, string lastName)
        {
            if (firstName == "")
            {
                Console.WriteLine("First name is empty");
            }
            else if (lastName == "")
            {
                Console.WriteLine("Last name is empty");
            }
            else
            {
                CustomerData.AddCustomer(firstName, lastName);
            }

        }

        public static Customer GetCustomerByFirstAndLastName(string firstName, string lastName)
        {
            if (firstName == "")
            {
                Console.WriteLine("Cannot search for empty first name");
            }
            else if (lastName == "")
            {
                Console.WriteLine("Cannot search for empty last name");
            }
            else
            {
                return CustomerData.GetCustomerByFirstAndLastName(firstName, lastName);
            }

            return null;
        }
    }
}
