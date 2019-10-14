using System;

namespace Project0.BusinessLogic
{
    /// <summary>
    /// Exception related to the BusinessLocation class.
    /// </summary>
    public class BusinessLocationException : Exception
    {
        /// <summary>
        /// Base exception constructor
        /// </summary>
        /// <param name="message">Message of the exception</param>
        public BusinessLocationException(string message) : base(message)
        {
        }
    }
}
