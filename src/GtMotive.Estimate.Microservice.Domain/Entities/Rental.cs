using System;
using GtMotive.Estimate.Microservice.Domain.Exceptions;
using MongoDB.Bson.Serialization.Attributes;

namespace GtMotive.Estimate.Microservice.Domain.Entities
{
    /// <summary>
    /// Rental entity representing a rental in the system.
    /// </summary>
    public class Rental : IRental
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class.
        /// </summary>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="startDate">The start date of the rental.</param>
        public Rental(Guid customerId, Guid vehicleId, DateTime startDate)
        {
            Id = Guid.NewGuid();
            CustomerId = customerId;
            VehicleId = vehicleId;
            StartDate = startDate;
            EndDate = null;
            Status = RentalStatus.Active;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Rental"/> class for MongoDB.
        /// </summary>
        /// <param name="id">The rental identifier.</param>
        /// <param name="customerId">The customer identifier.</param>
        /// <param name="vehicleId">The vehicle identifier.</param>
        /// <param name="startDate">The start date of the rental.</param>
        /// <param name="endDate">The end date of the rental.</param>
        [BsonConstructor]
        public Rental(Guid id, Guid customerId, Guid vehicleId, DateTime startDate, DateTime? endDate = null)
        {
            Id = id;
            CustomerId = customerId;
            VehicleId = vehicleId;
            StartDate = startDate;
            EndDate = endDate;
            Status = endDate.HasValue ? RentalStatus.Completed : RentalStatus.Active;
        }

        /// <summary>
        /// Gets the rental identifier.
        /// </summary>
        [BsonId]
        public Guid Id { get; }

        /// <summary>
        /// Gets the customer identifier.
        /// </summary>
        [BsonElement("customerId")]
        public Guid CustomerId { get; }

        /// <summary>
        /// Gets the vehicle identifier.
        /// </summary>
        [BsonElement("vehicleId")]
        public Guid VehicleId { get; }

        /// <summary>
        /// Gets the start date of the rental.
        /// </summary>
        [BsonElement("startDate")]
        public DateTime StartDate { get; }

        /// <summary>
        /// Gets the end date of the rental.
        /// </summary>
        [BsonElement("endDate")]
        public DateTime? EndDate { get; private set; }

        /// <summary>
        /// Gets the status of the rental.
        /// </summary>
        [BsonElement("status")]
        public RentalStatus Status { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the rental is active.
        /// </summary>
        public bool IsActive => Status == RentalStatus.Active;

        /// <summary>
        /// Gets a value indicating whether the rental is completed.
        /// </summary>
        public bool IsCompleted => Status == RentalStatus.Completed;

        /// <summary>
        /// Completes the rental with the specified end date.
        /// </summary>
        /// <param name="endDate">The end date of the rental.</param>
        public void Complete(DateTime endDate)
        {
            if (!IsActive)
            {
                throw new RentalAlreadyCompletedException($"Rental {Id} is already completed.");
            }

            if (endDate <= StartDate)
            {
                throw new InvalidEndDateException("End date must be after start date.");
            }

            EndDate = endDate;
            Status = RentalStatus.Completed;
        }

        /// <summary>
        /// Gets the duration of the rental.
        /// </summary>
        /// <returns>The duration of the rental.</returns>
        public TimeSpan GetDuration()
        {
            var endDate = EndDate ?? DateTime.UtcNow;
            return endDate - StartDate;
        }
    }
}
