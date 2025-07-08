using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Customer entity interface.
    /// </summary>
    public interface ICustomer
    {
        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the customer DNI.
        /// </summary>
        string DNI { get; }

        /// <summary>
        /// Gets the customer name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the customer email.
        /// </summary>
        string Email { get; }

        /// <summary>
        /// Gets a value indicating whether the customer has an active rental.
        /// </summary>
        bool HasActiveRental { get; }

        /// <summary>
        /// Starts a rental for the customer.
        /// </summary>
        void StartRental();

        /// <summary>
        /// Ends the active rental for the customer.
        /// </summary>
        void EndRental();
    }
}
