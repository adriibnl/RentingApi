﻿using System;

namespace GtMotive.Estimate.Microservice.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when the brand is too long.
    /// </summary>
    public class BrandTooLongException : DomainException
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BrandTooLongException"/> class.
        /// </summary>
        public BrandTooLongException()
            : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandTooLongException"/> class with a specified error message.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public BrandTooLongException(string message)
            : base(message)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BrandTooLongException"/> class with a specified error message and a reference to the inner exception that is the cause of this exception.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public BrandTooLongException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
