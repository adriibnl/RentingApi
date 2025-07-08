using System;
using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;

#pragma warning disable CA1515
namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public sealed class GenericInfrastructureTestServerFixture : IDisposable
    {
        public GenericInfrastructureTestServerFixture()
        {
            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseEnvironment("IntegrationTest")
                .UseDefaultServiceProvider(options => { options.ValidateScopes = true; })
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: false);
                    builder.AddEnvironmentVariables();
                })
                .UseStartup<Startup>();

            Server = new TestServer(hostBuilder);
        }

        internal TestServer Server { get; }

        internal HttpClient Client => Server.CreateClient();

        /// <inheritdoc />
        public void Dispose()
        {
            Server?.Dispose();
        }
    }
}
#pragma warning restore CA1515
