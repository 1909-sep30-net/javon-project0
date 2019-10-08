using System;
using System.Linq;

namespace Project0.Logic
{
    public static class CustomerValidation
    {
        private const int maxNameLength = 20;
        public static CustomerFirstNameValidationMessage ValidateCustomerFirstName(string firstName)
        {
            if (firstName.Length == 0) return CustomerFirstNameValidationMessage.FirstNameEmpty;
            else if (firstName.Length > maxNameLength) return CustomerFirstNameValidationMessage.FirstNameTooLong;
            else if (!firstName.All(Char.IsLetter)) return CustomerFirstNameValidationMessage.FirstNameNotAlpha;
            
            return CustomerFirstNameValidationMessage.Valid;
        }

        public static CustomerLastNameValidationMessage ValidateCustomerLastName(string lastName)
        {
            if (lastName.Length == 0) return CustomerLastNameValidationMessage.LastNameEmpty;
            else if (lastName.Length > maxNameLength) return CustomerLastNameValidationMessage.LastNameTooLong;
            else if (!lastName.All(Char.IsLetter)) return CustomerLastNameValidationMessage.LastNameNotAlpha;

            return CustomerLastNameValidationMessage.Valid;
        }
    }
}
