using System;
using GtMotive.Estimate.Microservice.Domain.Entities;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Factory interface for creating rental instances.
    /// </summary>
    public interface IRentalFactory
    {
        /// <summary>
        /// Creates a new rental instance.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="startDate">The start date of the rental.</param>
        /// <returns>A new rental instance.</returns>
        IRental NewRental(Guid customerId, Guid vehicleId, DateTime startDate);
    }
}
