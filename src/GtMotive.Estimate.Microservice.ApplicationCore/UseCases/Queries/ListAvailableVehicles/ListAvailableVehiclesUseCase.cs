using System;
using System.Linq;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles
{
    /// <summary>
    /// Implementation of the list available vehicles use case.
    /// </summary>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPort">The output port.</param>
    public class ListAvailableVehiclesUseCase(
        IVehicleRepository vehicleRepository,
        IListAvailableVehiclesOutputPort outputPort) : IListAvailableVehiclesUseCase
    {
        /// <summary>
        /// Executes the list available vehicles use case.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(ListAvailableVehiclesInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            var availableVehicles = await vehicleRepository.GetAvailableVehiclesAsync();

            var validVehicles = availableVehicles.Where(v => !v.IsOlderThanFiveYears()).ToList();

            var vehicleDetails = validVehicles.Select(v => new VehicleDetails(
                v.Id,
                v.LicensePlate,
                v.Brand,
                v.Model,
                v.ManufacturingYear)).ToList();

            var output = new ListAvailableVehiclesOutput(vehicleDetails);
            outputPort.StandardHandle(output);
        }
    }
}
