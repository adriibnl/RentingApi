namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Output port for returning a vehicle use case.
    /// </summary>
    public interface IReturnVehicleOutputPort : IOutputPortStandard<ReturnVehicleOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case when the vehicle is not rented.
        /// </summary>
        /// <param name="message">The error message.</param>
        void VehicleNotRentedHandle(string message);

        /// <summary>
        /// Handles the case when the end date is invalid.
        /// </summary>
        /// <param name="message">The error message.</param>
        void InvalidEndDateHandle(string message);

        /// <summary>
        /// Handles the case when the rental is already completed.
        /// </summary>
        /// <param name="message">The error message.</param>
        void RentalAlreadyCompletedHandle(string message);
    }
}
