using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when the EmailTooLongException occurs.
    /// </summary>
    public class EmailTooLongException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTooLongException"/> class.
        /// </summary>
        public EmailTooLongException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTooLongException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public EmailTooLongException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailTooLongException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public EmailTooLongException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
