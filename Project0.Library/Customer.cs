using System;
using System.Linq;

namespace Project0.Logic
{
    public class Customer
    {
        private const int maxNameLength = 20;
        private int id;
        private string firstName;
        private string lastName;
        public int Id
        {
            get => id;
            set
            {
                id = value;
            }
        }
        public string FirstName
        {
            get => firstName;
            set
            {
                ValidateCustomerFirstName(value);
                firstName = value.ToLower();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                ValidateCustomerLastName(value);
                lastName = value.ToLower();
            }
        }

        private void ValidateCustomerFirstName(string first)
        {
            if (first.Length == 0) throw new CustomerException("First name is empty");
            else if (first.Length > maxNameLength) throw new CustomerException($"First name is longer than {maxNameLength} characters");
            else if (!first.All(Char.IsLetter)) throw new CustomerException("First name is not alphabetical");
        }

        private void ValidateCustomerLastName(string last)
        {
            if (last.Length == 0) throw new CustomerException("Last name is empty");
            else if (last.Length > maxNameLength) throw new CustomerException($"Last name is longer than {maxNameLength} characters");
            else if (!last.All(Char.IsLetter)) throw new CustomerException("Last name is not alphabetical");
        }
    }
}
