using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output data for renting a vehicle.
    /// </summary>
    /// <param name="rentalId">The rental's unique identifier.</param>
    /// <param name="vehicleId">The vehicle's unique identifier.</param>
    /// <param name="customerId">The customer's unique identifier.</param>
    /// <param name="startDate">The rental start date.</param>
    public class RentVehicleOutput(Guid rentalId, Guid vehicleId, Guid customerId, DateTime startDate) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the rental's unique identifier.
        /// </summary>
        public Guid RentalId { get; } = rentalId;

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
