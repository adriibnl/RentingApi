using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output data for returning a vehicle.
    /// </summary>
    /// <param name="rentalId">The rental's unique identifier.</param>
    /// <param name="vehicleId">The vehicle's unique identifier.</param>
    /// <param name="customerId">The customer's unique identifier.</param>
    /// <param name="startDate">The rental start date.</param>
    /// <param name="endDate">The rental end date.</param>
    /// <param name="duration">The rental duration.</param>
    public class ReturnVehicleOutput(Guid rentalId, Guid vehicleId, Guid customerId, DateTime startDate, DateTime endDate, TimeSpan duration) : IUseCaseOutput
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

        /// <summary>
        /// Gets the rental end date.
        /// </summary>
        public DateTime EndDate { get; } = endDate;

        /// <summary>
        /// Gets the rental duration.
        /// </summary>
        public TimeSpan Duration { get; } = duration;
    }
}
