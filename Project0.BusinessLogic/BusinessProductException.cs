using System;

namespace Project0.App
{
    /// <summary>
    /// Exception related to the BusinessProduct class.
    /// </summary>
    public class BusinessProductException : Exception
    {
        /// <summary>
        /// Base exception constructor
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public BusinessProductException(string message) : base(message)
        {
        }
    }
}
