using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Models
{
    /// <summary>
    /// Request model for renting a vehicle.
    /// </summary>
    public class RentVehicleRequest
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        [Required]
        public Guid? VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier.
        /// </summary>
        [Required]
        public Guid? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        [Required]
        public DateTime? StartDate { get; set; }
    }
}
