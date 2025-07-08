using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle
{
    /// <summary>
    /// Implementation of the rent vehicle use case.
    /// </summary>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="customerRepository">The customer repository.</param>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="rentalFactory">The rental factory.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    public class RentVehicleUseCase(
        IVehicleRepository vehicleRepository,
        ICustomerRepository customerRepository,
        IRentalRepository rentalRepository,
        IRentalFactory rentalFactory,
        IRentVehicleOutputPort outputPort,
        IUnitOfWork unitOfWork) : IRentVehicleUseCase
    {
        /// <summary>
        /// Executes the rent vehicle use case.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(RentVehicleInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                var vehicle = await vehicleRepository.GetByIdAsync(input.VehicleId);
                if (vehicle == null)
                {
                    outputPort.NotFoundHandle($"Vehicle with ID {input.VehicleId} not found.");
                    return;
                }

                var customer = await customerRepository.GetByIdAsync(input.CustomerId);
                if (customer == null)
                {
                    outputPort.NotFoundHandle($"Customer with ID {input.CustomerId} not found.");
                    return;
                }

                if (vehicle.IsOlderThanFiveYears())
                {
                    outputPort.VehicleTooOldHandle($"Vehicle {vehicle.LicensePlate} is too old (more than 5 years).");
                    return;
                }

                if (!vehicle.IsAvailable)
                {
                    outputPort.VehicleNotAvailableHandle($"Vehicle {vehicle.LicensePlate} is not available for rent.");
                    return;
                }

                if (customer.HasActiveRental)
                {
                    outputPort.CustomerAlreadyHasActiveRentalHandle($"Customer {customer.Name} already has an active rental.");
                    return;
                }

                if (await rentalRepository.VehicleHasActiveRentalAsync(input.VehicleId))
                {
                    outputPort.VehicleNotAvailableHandle($"Vehicle {vehicle.LicensePlate} is already rented.");
                    return;
                }

                var rental = rentalFactory.NewRental(input.CustomerId, input.VehicleId, input.StartDate);

                vehicle.Rent();

                customer.StartRental();

                await rentalRepository.AddAsync(rental);
                await vehicleRepository.UpdateAsync(vehicle);
                await customerRepository.UpdateAsync(customer);
                await unitOfWork.Save();

                var output = new RentVehicleOutput(
                    rental.Id,
                    rental.VehicleId,
                    rental.CustomerId,
                    rental.StartDate);

                outputPort.StandardHandle(output);
            }
            catch (VehicleNotFoundException)
            {
                outputPort.NotFoundHandle("Vehicle not found.");
            }
            catch (CustomerNotFoundException)
            {
                outputPort.NotFoundHandle("Customer not found.");
            }
            catch (VehicleNotAvailableException ex)
            {
                outputPort.VehicleNotAvailableHandle(ex.Message);
            }
            catch (CustomerAlreadyHasActiveRentalException ex)
            {
                outputPort.CustomerAlreadyHasActiveRentalHandle(ex.Message);
            }
        }
    }
}
