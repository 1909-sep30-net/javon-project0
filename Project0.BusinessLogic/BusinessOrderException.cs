using System;

namespace Project0.BusinessLogic
{
    public class BusinessOrderException : Exception
    {
        public BusinessOrderException(string message) : base(message)
        {
        }
    }
}
