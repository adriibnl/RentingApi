namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Output port for creating a vehicle use case.
    /// </summary>
    public interface ICreateVehicleOutputPort : IOutputPortStandard<CreateVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case when the vehicle is too old.
        /// </summary>
        /// <param name="message">The error message.</param>
        void VehicleTooOldHandle(string message);

        /// <summary>
        /// Handles the case when a vehicle with the same license plate already exists.
        /// </summary>
        /// <param name="message">The error message.</param>
        void LicensePlateAlreadyExistsHandle(string message);
    }
}
