using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Repository interface for customer operations.
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Gets a customer by its identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the customer.</returns>
        Task<ICustomer> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets a customer by DNI.
        /// </summary>
        /// <param name="dni">The DNI of the customer.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the customer.</returns>
        Task<ICustomer> GetByDNIAsync(string dni);

        /// <summary>
        /// Gets all customers.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of all customers.</returns>
        Task<IEnumerable<ICustomer>> GetAllAsync();

        /// <summary>
        /// Adds a new customer.
        /// </summary>
        /// <param name="customer">The customer to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(ICustomer customer);

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        /// <param name="customer">The customer to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(ICustomer customer);

        /// <summary>
        /// Deletes a customer by its identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Checks if a customer exists by its identifier.
        /// </summary>
        /// <param name="id">The customer identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the customer exists.</returns>
        Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Checks if a DNI already exists.
        /// </summary>
        /// <param name="dni">The DNI to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the DNI exists.</returns>
        Task<bool> DNIExists(string dni);
    }
}
