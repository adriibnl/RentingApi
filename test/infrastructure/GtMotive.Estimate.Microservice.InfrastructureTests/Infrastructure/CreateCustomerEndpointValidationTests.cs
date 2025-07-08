using System.Net;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xunit;

namespace GtMotive.Estimate.Microservice.InfrastructureTests.Infrastructure
{
    public class CreateCustomerEndpointValidationTests(GenericInfrastructureTestServerFixture fixture)
        : IClassFixture<GenericInfrastructureTestServerFixture>
    {
        private readonly GenericInfrastructureTestServerFixture _fixture = fixture;

        [Fact]
        public async Task PostCustomerWithInvalidModelReturnsBadRequest()
        {
            var invalidRequest = new { Name = string.Empty };

            var response = await _fixture.Client.PostAsJsonAsync("/api/customer", invalidRequest);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
