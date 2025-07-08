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
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoCollection<Customer> _customers;

        public CustomerRepository(MongoService mongoService, IOptions<MongoDbSettings> settings)
        {
            ArgumentNullException.ThrowIfNull(mongoService);
            ArgumentNullException.ThrowIfNull(settings);

            var database = mongoService.MongoClient.GetDatabase(settings.Value.MongoDbDatabaseName);
            _customers = database.GetCollection<Customer>("customers");
        }

        public async Task<ICustomer> GetByIdAsync(Guid id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            return await _customers.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<ICustomer> GetByDNIAsync(string dni)
        {
            ArgumentNullException.ThrowIfNull(dni);

            var filter = Builders<Customer>.Filter.Eq(c => c.DNI, dni);
            return await _customers.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ICustomer>> GetAllAsync()
        {
            return await _customers.Find(_ => true).ToListAsync();
        }

        public async Task AddAsync(ICustomer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (customer is Customer customerEntity)
            {
                await _customers.InsertOneAsync(customerEntity);
            }
        }

        public async Task UpdateAsync(ICustomer customer)
        {
            ArgumentNullException.ThrowIfNull(customer);

            if (customer is Customer customerEntity)
            {
                var filter = Builders<Customer>.Filter.Eq(c => c.Id, customer.Id);
                await _customers.ReplaceOneAsync(filter, customerEntity);
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            await _customers.DeleteOneAsync(filter);
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            var filter = Builders<Customer>.Filter.Eq(c => c.Id, id);
            return await _customers.Find(filter).AnyAsync();
        }

        public async Task<bool> DNIExists(string dni)
        {
            ArgumentNullException.ThrowIfNull(dni);

            var filter = Builders<Customer>.Filter.Eq(c => c.DNI, dni);
            return await _customers.Find(filter).AnyAsync();
        }
    }
}
