using System;
using System.Linq;

namespace Project0.Logic
{
    public class BusinessCustomer
    {
        private const int maxNameLength = 30;
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
                firstName = char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }
        public string LastName
        {
            get => lastName;
            set
            {
                ValidateCustomerLastName(value);
                lastName = char.ToUpper(value[0]) + value.Substring(1).ToLower();
            }
        }

        private void ValidateCustomerFirstName(string first)
        {
            if (first.Length == 0) throw new BusinessCustomerException("[!] First name is empty");
            else if (first.Length > maxNameLength) throw new BusinessCustomerException($"[!] First name is longer than {maxNameLength} characters");
            else if (!first.All(Char.IsLetter)) throw new BusinessCustomerException("[!] First name is not alphabetical");
        }

        private void ValidateCustomerLastName(string last)
        {
            if (last.Length == 0) throw new BusinessCustomerException("[!] Last name is empty");
            else if (last.Length > maxNameLength) throw new BusinessCustomerException($"[!] Last name is longer than {maxNameLength} characters");
            else if (!last.All(Char.IsLetter)) throw new BusinessCustomerException("[!] Last name is not alphabetical");
        }

        public override string ToString()
        {
            return $"[Customer {Id}] {FirstName} {LastName}";
        }
    }
}
