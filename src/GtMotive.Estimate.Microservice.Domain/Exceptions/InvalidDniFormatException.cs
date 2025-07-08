using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when the InvalidDniFormatException occurs.
    /// </summary>
    public class InvalidDniFormatException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDniFormatException"/> class.
        /// </summary>
        public InvalidDniFormatException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDniFormatException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidDniFormatException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidDniFormatException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidDniFormatException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
