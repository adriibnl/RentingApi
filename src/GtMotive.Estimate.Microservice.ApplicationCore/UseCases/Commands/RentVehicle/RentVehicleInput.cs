using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Input data for renting a vehicle.
    /// </summary>
    /// <param name="vehicleId">The vehicle's unique identifier.</param>
    /// <param name="customerId">The customer's unique identifier.</param>
    /// <param name="startDate">The rental start date.</param>
    public class RentVehicleInput(Guid vehicleId, Guid customerId, DateTime startDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle's unique identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the customer's unique identifier.
        /// </summary>
        public Guid CustomerId { get; } = customerId;

        /// <summary>
        /// Gets the rental start date.
        /// </summary>
        public DateTime StartDate { get; } = startDate;
    }
}
