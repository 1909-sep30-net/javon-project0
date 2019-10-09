using System;

namespace Project0.Logic
{
    internal class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        {
        }
    }
}