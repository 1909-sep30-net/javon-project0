using System;

namespace Project0.BusinessLogic
{
    internal class BusinessOrderException : Exception
    {
        public BusinessOrderException(string message) : base(message)
        {
        }
    }
}