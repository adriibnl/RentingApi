using System;
using System.Reflection;
using GtMotive.Estimate.Microservice.Api;
using GtMotive.Estimate.Microservice.Api.Presenters;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure;
using GtMotive.Estimate.Microservice.Infrastructure.Factories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    internal sealed class Startup
    {
        public Startup(IWebHostEnvironment environment, IConfiguration configuration)
        {
            Environment = environment;
            Configuration = configuration;
        }

        public static IConfiguration Configuration { get; private set; }

        public IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public static void Configure(IApplicationBuilder app)
        {
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public static void ConfigureServices(IServiceCollection services)
        {
            // Obtener IConfiguration del contenedor de servicios
            var provider = services.BuildServiceProvider();
            var configuration = provider.GetService<IConfiguration>();

            services.AddMediatR(typeof(Startup).GetTypeInfo().Assembly);

            services.AddControllers(ApiConfiguration.ConfigureControllers)
                .WithApiControllers();

            services.AddBaseInfrastructure(true)
                .AddMongoDb(configuration);
            services.AddScoped<ICustomerFactory, CustomerFactory>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICreateCustomerOutputPort, CreateCustomerPresenter>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICreateCustomerUseCase, CreateCustomerUseCase>();
        }
    }
}
