using System;

namespace Project0.BusinessLogic
{
    public class BusinessCustomerException : Exception
    {
        public BusinessCustomerException(string message) : base(message)
        {
        }
    }
}