using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer
{
    /// <summary>
    /// Output data for creating a customer.
    /// </summary>
    /// <param name="customerId">The customer's unique identifier.</param>
    /// <param name="dni">The customer's DNI.</param>
    /// <param name="name">The customer's name.</param>
    /// <param name="email">The customer's email.</param>
    public class CreateCustomerOutput(Guid customerId, string dni, string name, string email) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the customer's unique identifier.
        /// </summary>
        public Guid CustomerId { get; } = customerId;

        /// <summary>
        /// Gets the customer's DNI.
        /// </summary>
        public string DNI { get; } = dni;

        /// <summary>
        /// Gets the customer's name.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the customer's email.
        /// </summary>
        public string Email { get; } = email;
    }
}
