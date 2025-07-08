using System;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Factories
{
    public class RentalFactory : IRentalFactory
    {
        public IRental NewRental(Guid customerId, Guid vehicleId, DateTime startDate)
        {
            return new Rental(customerId, vehicleId, startDate);
        }
    }
}
