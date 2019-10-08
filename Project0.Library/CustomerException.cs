using System;

namespace Project0.Logic
{
    public class CustomerException : Exception
    {
        public CustomerException(string message)
           : base(message)
        {
        }
    }
}