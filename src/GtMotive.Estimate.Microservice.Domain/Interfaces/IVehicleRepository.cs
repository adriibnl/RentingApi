using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Repository interface for vehicle operations.
    /// </summary>
    public interface IVehicleRepository
    {
        /// <summary>
        /// Gets a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the vehicle.</returns>
        Task<IVehicle> GetByIdAsync(Guid id);

        /// <summary>
        /// Gets all available vehicles.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of available vehicles.</returns>
        Task<IEnumerable<IVehicle>> GetAvailableVehiclesAsync();

        /// <summary>
        /// Gets all vehicles.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the collection of all vehicles.</returns>
        Task<IEnumerable<IVehicle>> GetAllAsync();

        /// <summary>
        /// Adds a new vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task AddAsync(IVehicle vehicle);

        /// <summary>
        /// Updates an existing vehicle.
        /// </summary>
        /// <param name="vehicle">The vehicle to update.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateAsync(IVehicle vehicle);

        /// <summary>
        /// Deletes a vehicle by its identifier.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteAsync(Guid id);

        /// <summary>
        /// Checks if a vehicle exists by its identifier.
        /// </summary>
        /// <param name="id">The vehicle identifier.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the vehicle exists.</returns>
        Task<bool> ExistsAsync(Guid id);

        /// <summary>
        /// Checks if a license plate already exists.
        /// </summary>
        /// <param name="licensePlate">The license plate to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the license plate exists.</returns>
        Task<bool> LicensePlateExists(string licensePlate);
    }
}
