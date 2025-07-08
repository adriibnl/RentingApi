namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Output port for renting a vehicle use case.
    /// </summary>
    public interface IRentVehicleOutputPort : IOutputPortStandard<RentVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case when the vehicle is not available.
        /// </summary>
        /// <param name="message">The error message.</param>
        void VehicleNotAvailableHandle(string message);

        /// <summary>
        /// Handles the case when the customer already has an active rental.
        /// </summary>
        /// <param name="message">The error message.</param>
        void CustomerAlreadyHasActiveRentalHandle(string message);

        /// <summary>
        /// Handles the case when the vehicle is too old.
        /// </summary>
        /// <param name="message">The error message.</param>
        void VehicleTooOldHandle(string message);
    }
}
