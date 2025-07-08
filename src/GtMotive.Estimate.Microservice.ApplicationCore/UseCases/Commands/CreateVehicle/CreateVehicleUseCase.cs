using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle
{
    /// <summary>
    /// Implementation of the create vehicle use case.
    /// </summary>
    /// <param name="vehicleFactory">The vehicle factory.</param>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    public class CreateVehicleUseCase(
        IVehicleFactory vehicleFactory,
        IVehicleRepository vehicleRepository,
        ICreateVehicleOutputPort outputPort,
        IUnitOfWork unitOfWork) : ICreateVehicleUseCase
    {
        /// <summary>
        /// Executes the create vehicle use case.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(CreateVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                if (await vehicleRepository.LicensePlateExists(input.LicensePlate))
                {
                    outputPort.LicensePlateAlreadyExistsHandle($"License plate {input.LicensePlate} already exists.");
                    return;
                }

                var vehicle = vehicleFactory.NewVehicle(
                    input.LicensePlate,
                    input.Brand,
                    input.Model,
                    input.ManufacturingYear);

                if (vehicle.IsOlderThanFiveYears())
                {
                    outputPort.VehicleTooOldHandle($"Vehicle with manufacturing year {input.ManufacturingYear} is too old (more than 5 years).");
                    return;
                }

                await vehicleRepository.AddAsync(vehicle);
                await unitOfWork.Save();

                var output = new CreateVehicleOutput(
                    vehicle.Id,
                    vehicle.LicensePlate,
                    vehicle.Brand,
                    vehicle.Model,
                    vehicle.ManufacturingYear);

                outputPort.StandardHandle(output);
            }
            catch (VehicleNotFoundException)
            {
                outputPort.NotFoundHandle("Vehicle not found.");
            }
        }
    }
}
