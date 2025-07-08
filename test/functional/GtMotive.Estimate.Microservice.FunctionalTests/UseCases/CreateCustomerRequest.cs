using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.FunctionalTests.UseCases
{
    internal sealed class CreateCustomerRequest
    {
        [Required]
        public string DNI { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
