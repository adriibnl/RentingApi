using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Vehicle entity interface.
    /// </summary>
    public interface IVehicle
    {
        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        /// <returns>The vehicle identifier.</returns>
        Guid Id { get; }

        /// <summary>
        /// Gets the license plate of the vehicle.
        /// </summary>
        /// <returns>The license plate of the vehicle.</returns>
        string LicensePlate { get; }

        /// <summary>
        /// Gets the brand of the vehicle.
        /// </summary>
        /// <returns>The brand of the vehicle.</returns>
        string Brand { get; }

        /// <summary>
        /// Gets the model of the vehicle.
        /// </summary>
        /// <returns>The model of the vehicle.</returns>
        string Model { get; }

        /// <summary>
        /// Gets the manufacturing year of the vehicle.
        /// </summary>
        /// <returns>The manufacturing year of the vehicle.</returns>
        int ManufacturingYear { get; }

        /// <summary>
        /// Gets the status of the vehicle.
        /// </summary>
        /// <returns>The status of the vehicle.</returns>
        VehicleStatus Status { get; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is available.
        /// </summary>
        /// <returns>True if the vehicle is available; otherwise, false.</returns>
        bool IsAvailable { get; }

        /// <summary>
        /// Gets a value indicating whether the vehicle is rented.
        /// </summary>
        /// <returns>True if the vehicle is rented; otherwise, false.</returns>
        bool IsRented { get; }

        /// <summary>
        /// Rents the vehicle.
        /// </summary>
        void Rent();

        /// <summary>
        /// Returns the vehicle.
        /// </summary>
        void ReturnVehicle();

        /// <summary>
        /// Checks if the vehicle is older than five years.
        /// </summary>
        /// <returns>True if the vehicle is older than five years; otherwise, false.</returns>
        bool IsOlderThanFiveYears();
    }
}
