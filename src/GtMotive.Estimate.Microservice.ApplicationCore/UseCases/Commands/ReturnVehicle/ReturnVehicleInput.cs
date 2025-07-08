using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Input data for returning a vehicle.
    /// </summary>
    /// <param name="vehicleId">The vehicle's unique identifier.</param>
    /// <param name="endDate">The rental end date.</param>
    public class ReturnVehicleInput(Guid vehicleId, DateTime endDate) : IUseCaseInput
    {
        /// <summary>
        /// Gets the vehicle's unique identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the rental end date.
        /// </summary>
        public DateTime EndDate { get; } = endDate;
    }
}
