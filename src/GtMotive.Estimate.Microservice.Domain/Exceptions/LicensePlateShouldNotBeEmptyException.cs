using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when a license plate is empty or null.
    /// </summary>
    public class LicensePlateShouldNotBeEmptyException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlateShouldNotBeEmptyException"/> class.
        /// </summary>
        public LicensePlateShouldNotBeEmptyException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlateShouldNotBeEmptyException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public LicensePlateShouldNotBeEmptyException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="LicensePlateShouldNotBeEmptyException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public LicensePlateShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
