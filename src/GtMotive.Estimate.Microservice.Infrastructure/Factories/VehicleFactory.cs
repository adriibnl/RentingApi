using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Factories
{
    public class VehicleFactory : IVehicleFactory
    {
        public IVehicle NewVehicle(string licensePlate, string brand, string model, int manufacturingYear)
        {
            return new Vehicle(licensePlate, brand, model, manufacturingYear);
        }
    }
}
