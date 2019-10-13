using System;

namespace Project0.App
{
    public class BusinessProductException : Exception
    {
        public BusinessProductException(string message) : base(message)
        {
        }
    }
}
