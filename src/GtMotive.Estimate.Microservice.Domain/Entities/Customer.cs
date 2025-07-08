using System;
using System.Text.RegularExpressions;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Customer entity representing a customer in the system.
    /// </summary>
    public partial class Customer : ICustomer
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class.
        /// </summary>
        /// <param name="dni">The DNI of the customer.</param>
        /// <param name="name">The name of the customer.</param>
        /// <param name="email">The email of the customer.</param>
        public Customer(string dni, string name, string email)
        {
            Id = Guid.NewGuid();
            DNI = ValidateDNI(dni);
            Name = ValidateName(name);
            Email = ValidateEmail(email);
            HasActiveRental = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Customer"/> class for MongoDB.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <param name="dni">The DNI of the customer.</param>
        /// <param name="name">The name of the customer.</param>
        /// <param name="email">The email of the customer.</param>
        [BsonConstructor]
        public Customer(Guid id, string dni, string name, string email)
        {
            Id = id;
            DNI = ValidateDNI(dni);
            Name = ValidateName(name);
            Email = ValidateEmail(email);
            HasActiveRental = false;
        }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        [BsonId]
        public Guid Id { get; }

        /// <summary>
        /// Gets the DNI of the customer.
        /// </summary>
        [BsonElement("dni")]
        public string DNI { get; }

        /// <summary>
        /// Gets the name of the customer.
        /// </summary>
        [BsonElement("name")]
        public string Name { get; }

        /// <summary>
        /// Gets the email of the customer.
        /// </summary>
        [BsonElement("email")]
        public string Email { get; }

        /// <summary>
        /// Gets a value indicating whether the customer has an active rental.
        /// </summary>
        [BsonElement("hasActiveRental")]
        public bool HasActiveRental { get; private set; }

        /// <summary>
        /// Starts a rental for the customer.
        /// </summary>
        public void StartRental()
        {
            if (HasActiveRental)
            {
                throw new CustomerAlreadyHasActiveRentalException($"Customer {Id} already has an active rental.");
            }

            HasActiveRental = true;
        }

        /// <summary>
        /// Ends the active rental for the customer.
        /// </summary>
        public void EndRental()
        {
            if (!HasActiveRental)
            {
                throw new CustomerNoActiveRentalException($"Customer {Id} has no active rental.");
            }

            HasActiveRental = false;
        }

        /// <summary>
        /// Validates the DNI format.
        /// </summary>
        /// <param name="dni">The DNI to validate.</param>
        /// <returns>The validated DNI.</returns>
        private static string ValidateDNI(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new DniShouldNotBeEmptyException("DNI cannot be empty.");
            }

            var regex = DniRegex();
            return !regex.IsMatch(dni)
                ? throw new InvalidDniFormatException($"DNI {dni} has invalid format. Expected format: 12345678A")
                : dni.ToUpperInvariant();
        }

        /// <summary>
        /// Gets the DNI regex pattern.
        /// </summary>
        /// <returns>The DNI regex pattern.</returns>
        [GeneratedRegex(@"^[0-9]{8}[A-Z]$")]
        private static partial Regex DniRegex();

        /// <summary>
        /// Validates the name format.
        /// </summary>
        /// <param name="name">The name to validate.</param>
        /// <returns>The validated name.</returns>
        private static string ValidateName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new NameShouldNotBeEmptyException("Name cannot be empty.");
            }

            if (name.Length > 100)
            {
                throw new NameTooLongException("Name cannot be longer than 100 characters.");
            }

            return name.Trim();
        }

        /// <summary>
        /// Validates the email format.
        /// </summary>
        /// <param name="email">The email to validate.</param>
        /// <returns>The validated email.</returns>
        private static string ValidateEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new EmailShouldNotBeEmptyException("Email cannot be empty.");
            }

            var regex = EmailRegex();
            return !regex.IsMatch(email)
                ? throw new InvalidEmailFormatException($"Email {email} has invalid format.")
                : email.ToUpperInvariant().Trim();
        }

        /// <summary>
        /// Gets the email regex pattern.
        /// </summary>
        /// <returns>The email regex pattern.</returns>
        [GeneratedRegex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$")]
        private static partial Regex EmailRegex();
    }
}
