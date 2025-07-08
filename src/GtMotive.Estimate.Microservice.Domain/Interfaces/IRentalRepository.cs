using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Repository interface for rental operations.
    /// </summary>
    public interface IRentalRepository
    {
        /// <summary>
        /// Gets a rental by its identifier.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the rental.</returns>
        Task<IRental> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets the active rental for a customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the active rental.</returns>
        Task<IRental> GetActiveRentalByCustomerAsync(Guid customerId);

        /// <summary>
        /// Gets the active rental for a vehicle.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the active rental.</returns>
        Task<IRental> GetActiveRentalByVehicleAsync(Guid vehicleId);

        /// <summary>
        /// Gets all rentals for a customer.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of rentals.</returns>
        Task<IEnumerable<IRental>> GetByCustomerAsync(Guid customerId);

        /// <summary>
        /// Gets all rentals for a vehicle.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of rentals.</returns>
        Task<IEnumerable<IRental>> GetByVehicleAsync(Guid vehicleId);

        /// <summary>
        /// Gets all rentals.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of all rentals.</returns>
        Task<IEnumerable<IRental>> GetAllAsync();

        /// <summary>
        /// Adds a new rental.
        /// </summary>
        /// <param name="rental">The rental to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(IRental rental);

        /// <summary>
        /// Updates an existing rental.
        /// </summary>
        /// <param name="rental">The rental to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(IRental rental);

        /// <summary>
        /// Deletes a rental by its identifier.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Checks if a rental exists by its identifier.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the rental exists.</returns>
        Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Checks if a customer has an active rental.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the customer has an active rental.</returns>
        Task<bool> CustomerHasActiveRental(Guid customerId);

        /// <summary>
        /// Checks if a vehicle has an active rental.
        /// </summary>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the vehicle has an active rental.</returns>
        Task<bool> VehicleHasActiveRentalAsync(Guid vehicleId);
    }
}
