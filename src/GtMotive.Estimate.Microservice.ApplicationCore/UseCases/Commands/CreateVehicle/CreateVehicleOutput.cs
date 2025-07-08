using System;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output data for creating a vehicle.
    /// </summary>
    /// <param name="vehicleId">The vehicle's unique identifier.</param>
    /// <param name="licensePlate">The vehicle's license plate.</param>
    /// <param name="brand">The vehicle's brand.</param>
    /// <param name="model">The vehicle's model.</param>
    /// <param name="manufacturingYear">The vehicle's manufacturing year.</param>
    public class CreateVehicleOutput(Guid vehicleId, string licensePlate, string brand, string model, int manufacturingYear) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the vehicle's unique identifier.
        /// </summary>
        public Guid VehicleId { get; } = vehicleId;

        /// <summary>
        /// Gets the vehicle's license plate.
        /// </summary>
        public string LicensePlate { get; } = licensePlate;

        /// <summary>
        /// Gets the vehicle's brand.
        /// </summary>
        public string Brand { get; } = brand;

        /// <summary>
        /// Gets the vehicle's model.
        /// </summary>
        public string Model { get; } = model;

        /// <summary>
        /// Gets the vehicle's manufacturing year.
        /// </summary>
        public int ManufacturingYear { get; } = manufacturingYear;
    }
}
