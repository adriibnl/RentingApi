using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Models
{
    /// <summary>
    /// Request model for creating a customer.
    /// </summary>
    public class CreateCustomerRequest
    {
        /// <summary>
        /// Gets or sets the DNI.
        /// </summary>
        [Required]
        public string Dni { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Required]
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the email.
        /// </summary>
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
