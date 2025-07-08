namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Input data for creating a vehicle.
    /// </summary>
    /// <param name="licensePlate">The vehicle's license plate.</param>
    /// <param name="brand">The vehicle's brand.</param>
    /// <param name="model">The vehicle's model.</param>
    /// <param name="manufacturingYear">The vehicle's manufacturing year.</param>
    public class CreateVehicleInput(string licensePlate, string brand, string model, int manufacturingYear) : IUseCaseInput
    {
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
