using System;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Rental entity interface.
    /// </summary>
    public interface IRental
    {
        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        Guid Id { get; }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        Guid CustomerId { get; }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        Guid VehicleId { get; }

        /// <summary>
        /// Gets the start date of the rental.
        /// </summary>
        DateTime StartDate { get; }

        /// <summary>
        /// Gets the end date of the rental.
        /// </summary>
        DateTime? EndDate { get; }

        /// <summary>
        /// Gets the status of the rental.
        /// </summary>
        RentalStatus Status { get; }

        /// <summary>
        /// Gets a value indicating whether the rental is active.
        /// </summary>
        bool IsActive { get; }

        /// <summary>
        /// Gets a value indicating whether the rental is completed.
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Completes the rental with the specified end date.
        /// </summary>
        /// <param name="endDate">The end date of the rental.</param>
        void Complete(DateTime endDate);

        /// <summary>
        /// Gets the duration of the rental.
        /// </summary>
        /// <returns>The duration of the rental.</returns>
        TimeSpan GetDuration();
    }
}
