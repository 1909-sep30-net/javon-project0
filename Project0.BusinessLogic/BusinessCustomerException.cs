using System;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Exception related to the BusinessCustomer class.
    /// </summary>
    public class BusinessCustomerException : Exception
    {
        /// <summary>
        /// Base exception constructor
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public BusinessCustomerException(string message) : base(message)
        {
        }
    }
}
