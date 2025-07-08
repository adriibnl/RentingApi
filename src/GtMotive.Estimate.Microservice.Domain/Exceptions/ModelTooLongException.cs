using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when the ModelTooLongException occurs.
    /// </summary>
    public class ModelTooLongException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelTooLongException"/> class.
        /// </summary>
        public ModelTooLongException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelTooLongException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public ModelTooLongException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelTooLongException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public ModelTooLongException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
