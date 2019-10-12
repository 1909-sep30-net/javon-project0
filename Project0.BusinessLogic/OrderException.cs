using System;

namespace Project0.BusinessLogic
{
    internal class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        {
        }
    }
}