using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer
{
    /// <summary>
    /// Implementation of the customer creation use case.
    /// </summary>
    /// <param name="customerFactory">The customer factory.</param>
    /// <param name="customerRepository">The customer repository.</param>
    /// <param name="outputPort">The output port.</param>
    /// <param name="unitOfWork">The unit of work.</param>
    public class CreateCustomerUseCase(
        ICustomerFactory customerFactory,
        ICustomerRepository customerRepository,
        ICreateCustomerOutputPort outputPort,
        IUnitOfWork unitOfWork) : ICreateCustomerUseCase
    {
        /// <summary>
        /// Executes the create customer use case.
        /// </summary>
        /// <param name="input">The input data.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task Execute(CreateCustomerInput input)
        {
            ArgumentNullException.ThrowIfNull(input);

            try
            {
                if (await customerRepository.DNIExists(input.DNI))
                {
                    outputPort.DNIAlreadyExistsHandle($"Customer with DNI {input.DNI} already exists.");
                    return;
                }

                var customer = customerFactory.NewCustomer(input.DNI, input.Name, input.Email);

                await customerRepository.AddAsync(customer);
                await unitOfWork.Save();

                var output = new CreateCustomerOutput(
                    customer.Id,
                    customer.DNI,
                    customer.Name,
                    customer.Email);

                outputPort.StandardHandle(output);
            }
            catch (CustomerNotFoundException)
            {
                outputPort.NotFoundHandle("Customer not found.");
            }
        }
    }
}
