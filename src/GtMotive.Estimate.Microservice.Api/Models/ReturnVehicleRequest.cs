using System;
using System.ComponentModel.DataAnnotations;

namespace GtMotive.Estimate.Microservice.Api.Models
{
    /// <summary>
    /// Request model for returning a vehicle.
    /// </summary>
    public class ReturnVehicleRequest
    {
        /// <summary>
        /// Gets or sets the vehicle identifier.
        /// </summary>
        [Required]
        public Guid? VehicleId { get; set; }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        [Required]
        public DateTime? EndDate { get; set; }
    }
}
