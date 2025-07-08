using GtMotive.Estimate.Microservice.Api.Presenters;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.Api.DependencyInjection
{
    public static class UserInterfaceExtensions
    {
        public static IServiceCollection AddPresenters(this IServiceCollection services)
        {
            services.AddScoped<CreateVehiclePresenter>();
            services.AddScoped<CreateCustomerPresenter>();
            services.AddScoped<ListAvailableVehiclesPresenter>();
            services.AddScoped<RentVehiclePresenter>();
            services.AddScoped<ReturnVehiclePresenter>();

            return services;
        }

        public static IServiceCollection AddApiOutputPorts(this IServiceCollection services)
        {
            services.AddScoped<GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer.ICreateCustomerOutputPort, CreateCustomerPresenter>();
            services.AddScoped<GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle.ICreateVehicleOutputPort, CreateVehiclePresenter>();
            services.AddScoped<GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles.IListAvailableVehiclesOutputPort, ListAvailableVehiclesPresenter>();
            services.AddScoped<GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle.IRentVehicleOutputPort, RentVehiclePresenter>();
            services.AddScoped<GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle.IReturnVehicleOutputPort, ReturnVehiclePresenter>();
            return services;
        }
    }
}
