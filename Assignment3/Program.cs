//GROUP 3 - OOP-2
//    Name: Paolo Bermudez | Romer John De Lina | Jonathan Buccat | Jeffry Ancheta
//    Date: March 23, 2024
//    Code Version 1.5


using System;

namespace Assignment3
{
    internal class Program
    {
        public static void Main(string[] args) { }
    }
    public class CannotRemoveException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the CannotRemoveException class.
        /// </summary>
        public CannotRemoveException()
        {
        }

        /// <summary>
        /// Initializes a new instance of the CannotRemoveException class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public CannotRemoveException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the CannotRemoveException class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">The exception that is the cause of the current exception, or a null reference if no inner exception is specified.</param>
        public CannotRemoveException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

}
