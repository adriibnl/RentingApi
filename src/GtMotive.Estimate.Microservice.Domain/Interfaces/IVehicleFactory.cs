using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Factory interface for creating vehicle instances.
    /// </summary>
    public interface IVehicleFactory
    {
        /// <summary>
        /// Creates a new vehicle instance.
        /// </summary>
        /// <param name="licensePlate">The license plate of the vehicle.</param>
        /// <param name="brand">The brand of the vehicle.</param>
        /// <param name="model">The model of the vehicle.</param>
        /// <param name="manufacturingYear">The manufacturing year of the vehicle.</param>
        /// <returns>A new vehicle instance.</returns>
        IVehicle NewVehicle(string licensePlate, string brand, string model, int manufacturingYear);
    }
}
