using System;

namespace Project0.Logic
{
    public class BusinessCustomerException : Exception
    {
        public BusinessCustomerException(string message) : base(message)
        {
        }
    }
}