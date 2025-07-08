using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Factory interface for creating customer instances.
    /// </summary>
    public interface ICustomerFactory
    {
        /// <summary>
        /// Creates a new customer instance.
        /// </summary>
        /// <param name="dni">The DNI of the customer.</param>
        /// <param name="name">The name of the customer.</param>
        /// <param name="email">The email of the customer.</param>
        /// <returns>A new customer instance.</returns>
        ICustomer NewCustomer(string dni, string name, string email);
    }
}
