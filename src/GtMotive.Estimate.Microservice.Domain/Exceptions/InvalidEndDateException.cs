﻿using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when the InvalidEndDateException occurs.
    /// </summary>
    public class InvalidEndDateException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEndDateException"/> class.
        /// </summary>
        public InvalidEndDateException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEndDateException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public InvalidEndDateException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InvalidEndDateException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public InvalidEndDateException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
