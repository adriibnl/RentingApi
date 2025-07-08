using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Output data for listing available vehicles.
    /// </summary>
    /// <param name="vehicles">The collection of available vehicles.</param>
    public class ListAvailableVehiclesOutput(IEnumerable<VehicleDetails> vehicles) : IUseCaseOutput
    {
        /// <summary>
        /// Gets the collection of available vehicles.
        /// </summary>
        public IEnumerable<VehicleDetails> Vehicles { get; } = vehicles;
    }
}
