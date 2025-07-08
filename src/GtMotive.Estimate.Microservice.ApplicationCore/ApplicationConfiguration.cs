using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.Extensions.DependencyInjection;
using System;

[assembly: CLSCompliant(false)]

namespace GtMotive.Estimate.Microservice.ApplicationCore
{
    /// <summary>
    /// Adds Use Cases classes.
    /// </summary>
    public static class ApplicationConfiguration
    {
        /// <summary>
        /// Adds Use Cases to the ServiceCollection.
        /// </summary>
        /// <param name="services">Service Collection.</param>
        /// <returns>The modified instance.</returns>
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<ICreateCustomerUseCase, UseCases.CreateCustomer.CreateCustomerUseCase>();

            services.AddScoped<ICreateVehicleUseCase, UseCases.CreateVehicle.CreateVehicleUseCase>();

            services
                .AddScoped<IListAvailableVehiclesUseCase,
                    UseCases.ListAvailableVehicles.ListAvailableVehiclesUseCase>();

            services.AddScoped<UseCases.RentVehicle.IRentVehicleUseCase, UseCases.RentVehicle.RentVehicleUseCase>();

            services
                .AddScoped<UseCases.ReturnVehicle.IReturnVehicleUseCase, UseCases.ReturnVehicle.ReturnVehicleUseCase>();

            return services;
        }
    }
}
