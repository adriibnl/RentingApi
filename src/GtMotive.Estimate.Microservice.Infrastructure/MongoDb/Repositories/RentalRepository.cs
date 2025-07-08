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
    public class RentalRepository : IRentalRepository
    {
        private readonly IMongoCollection<Rental> _rentals;

        public RentalRepository(MongoService mongoService, IOptions<MongoDbSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(settings);

            var database = mongoService.MongoClient.GetDatabase(settings.Value.MongoDbDatabaseName);
            _rentals = database.GetCollection<Rental>("rentals");
        }

        public async Task<IRental> GetByIdAsync(Guid id)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.Id, id);
            return await _rentals.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IRental> GetActiveRentalByCustomerAsync(Guid customerId)
        {
            var filter = Builders<Rental>.Filter.And(
                Builders<Rental>.Filter.Eq(r => r.CustomerId, customerId),
                Builders<Rental>.Filter.Eq(r => r.IsActive, true))
            ;
            return await _rentals.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IRental> GetActiveRentalByVehicleAsync(Guid vehicleId)
        {
            var filter = Builders<Rental>.Filter.And(
                Builders<Rental>.Filter.Eq(r => r.VehicleId, vehicleId),
                Builders<Rental>.Filter.Eq(r => r.IsActive, true));
            return await _rentals.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<IRental>> GetByCustomerAsync(Guid customerId)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.CustomerId, customerId);
            return await _rentals.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<IRental>> GetByVehicleAsync(Guid vehicleId)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.VehicleId, vehicleId);
            return await _rentals.Find(filter).ToListAsync();
        }

        public async Task<IEnumerable<IRental>> GetAllAsync()
        {
            return await _rentals.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(IRental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            if (rental is Rental rentalEntity)
            {
                await _rentals.InsertOneAsync(rentalEntity);
            }
        }

        public async Task UpdateAsync(IRental rental)
        {
            ArgumentNullException.ThrowIfNull(rental);

            if (rental is Rental rentalEntity)
            {
                var filter = Builders<Rental>.Filter.Eq(r => r.Id, rental.Id);
                await _rentals.ReplaceOneAsync(filter, rentalEntity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.Id, id);
            await _rentals.DeleteOneAsync(filter);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var filter = Builders<Rental>.Filter.Eq(r => r.Id, id);
            return await _rentals.Find(filter).AnyAsync();
        }

        public async Task<bool> CustomerHasActiveRental(Guid customerId)
        {
            var filter = Builders<Rental>.Filter.And(
                Builders<Rental>.Filter.Eq(r => r.CustomerId, customerId),
                Builders<Rental>.Filter.Eq(r => r.IsActive, true));
            return await _rentals.Find(filter).AnyAsync();
        }

        public async Task<bool> VehicleHasActiveRentalAsync(Guid vehicleId)
        {
            var filter = Builders<Rental>.Filter.And(
                Builders<Rental>.Filter.Eq(r => r.VehicleId, vehicleId),
                Builders<Rental>.Filter.Eq(r => r.IsActive, true));
            return await _rentals.Find(filter).AnyAsync();
        }
    }
}
