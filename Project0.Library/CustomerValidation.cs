using System;
using System.Linq;

namespace Project0.Logic
{
    public static class CustomerValidation
    {
        private const int maxNameLength = 20;
        public static CustomerValidationMessage ValidateCustomerName(string firstName, string lastName)
        {
            if (firstName.Length == 0) return CustomerValidationMessage.FirstNameEmpty;
            else if (lastName.Length == 0) return CustomerValidationMessage.LastNameEmpty;
            else if (firstName.Length > maxNameLength) return CustomerValidationMessage.FirstNameTooLong;
            else if (lastName.Length > maxNameLength) return CustomerValidationMessage.LastNameTooLong;
            else if (!firstName.All(Char.IsLetter)) return CustomerValidationMessage.FirstNameNotAlpha;
            else if (!lastName.All(Char.IsLetter)) return CustomerValidationMessage.LastNameNotAlpha;
            
            return CustomerValidationMessage.Valid;
        }
    }
}
