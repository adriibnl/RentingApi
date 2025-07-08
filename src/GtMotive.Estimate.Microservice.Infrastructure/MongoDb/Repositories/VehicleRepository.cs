using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories
{
    public class VehicleRepository : IVehicleRepository
    {
        private readonly IMongoCollection<Vehicle> _vehicles;

        public VehicleRepository(MongoService mongoService, IOptions<MongoDbSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(settings);

            var database = mongoService.MongoClient.GetDatabase(settings.Value.MongoDbDatabaseName);
            _vehicles = database.GetCollection<Vehicle>("vehicles");
        }

        public async Task<IVehicle> GetByIdAsync(Guid id)
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, id);
            var vehicle = await _vehicles.Find(filter).FirstOrDefaultAsync();
            return vehicle;
        }

        public async Task<IEnumerable<IVehicle>> GetAvailableVehiclesAsync()
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.Status, VehicleStatus.Available);
            return await _vehicles.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<IVehicle>> GetAllAsync()
        {
            return await _vehicles.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(IVehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            if (vehicle is Vehicle vehicleEntity)
            {
                await _vehicles.InsertOneAsync(vehicleEntity);
            }
        }

        public async Task UpdateAsync(IVehicle vehicle)
        {
            ArgumentNullException.ThrowIfNull(vehicle);

            if (vehicle is Vehicle vehicleEntity)
            {
                var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, vehicle.Id);
                await _vehicles.ReplaceOneAsync(filter, vehicleEntity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, id);
            await _vehicles.DeleteOneAsync(filter);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var filter = Builders<Vehicle>.Filter.Eq(v => v.Id, id);
            return await _vehicles.Find(filter).AnyAsync();
        }

        public async Task<bool> LicensePlateExists(string licensePlate)
        {
            ArgumentNullException.ThrowIfNull(licensePlate);

            var filter = Builders<Vehicle>.Filter.Eq(v => v.LicensePlate, licensePlate);
            return await _vehicles.Find(filter).AnyAsync();
        }
    }
}
