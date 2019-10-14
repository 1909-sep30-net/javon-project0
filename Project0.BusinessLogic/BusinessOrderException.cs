using System;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Exception related to the BusinessOrder class.
    /// </summary>
    public class BusinessOrderException : Exception
    {
        /// <summary>
        /// Base exception constructor
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public BusinessOrderException(string message) : base(message)
        {
        }
    }
}
