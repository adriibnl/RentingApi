using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle
{
    /// <summary>
    /// Implementation of the return vehicle use case.
    /// </summary>
    /// <param name="vehicleRepository">The vehicle repository.</param>
    /// <param name="customerRepository">The customer repository.</param>
    /// <param name="rentalRepository">The rental repository.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    public class ReturnVehicleUseCase(
        IVehicleRepository vehicleRepository,
        ICustomerRepository customerRepository,
        IRentalRepository rentalRepository,
        IReturnVehicleOutputPort outputPort,
        IUnitOfWork unitOfWork) : IReturnVehicleUseCase
    {
        /// <summary>
        /// Executes the return vehicle use case.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(ReturnVehicleInput input)
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

                if (!vehicle.IsRented)
                {
                    outputPort.VehicleNotRentedHandle($"Vehicle {vehicle.LicensePlate} is not currently rented.");
                    return;
                }

                var rental = await rentalRepository.GetActiveRentalByVehicleAsync(input.VehicleId);
                if (rental == null)
                {
                    outputPort.VehicleNotRentedHandle($"No active rental found for vehicle {vehicle.LicensePlate}.");
                    return;
                }

                if (rental.IsCompleted)
                {
                    outputPort.RentalAlreadyCompletedHandle($"Rental {rental.Id} is already completed.");
                    return;
                }

                if (input.EndDate <= rental.StartDate)
                {
                    outputPort.InvalidEndDateHandle("End date must be after start date.");
                    return;
                }

                var customer = await customerRepository.GetByIdAsync(rental.CustomerId);
                if (customer == null)
                {
                    outputPort.NotFoundHandle($"Customer with ID {rental.CustomerId} not found.");
                    return;
                }

                rental.Complete(input.EndDate);

                vehicle.ReturnVehicle();

                customer.EndRental();

                await rentalRepository.UpdateAsync(rental);
                await vehicleRepository.UpdateAsync(vehicle);
                await customerRepository.UpdateAsync(customer);
                await unitOfWork.Save();

                var output = new ReturnVehicleOutput(
                    rental.Id,
                    rental.VehicleId,
                    rental.CustomerId,
                    rental.StartDate,
                    rental.EndDate.Value,
                    rental.GetDuration());

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
            catch (VehicleNotRentedException ex)
            {
                outputPort.VehicleNotRentedHandle(ex.Message);
            }
            catch (RentalAlreadyCompletedException ex)
            {
                outputPort.RentalAlreadyCompletedHandle(ex.Message);
            }
            catch (InvalidEndDateException ex)
            {
                outputPort.InvalidEndDateHandle(ex.Message);
            }
        }
    }
}
