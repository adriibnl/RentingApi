using System;
using System.Threading;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Repositories;
using GtMotive.Estimate.Microservice.Infrastructure.MongoDb.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.UnitTests.Domain
{
    public class CustomerRepositoryTests
    {
        [Fact]
        public async Task DNIExists_ReturnsTrue_WhenCustomerExists()
        {
            var mockCollection = new Mock<IMongoCollection<Customer>>();
            var mockCursor = new Mock<IAsyncCursor<Customer>>();
            mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>())).Returns(true).Returns(false);
            mockCursor.Setup(x => x.Current).Returns(new[] { new Customer() });
            mockCollection.Setup(x => x.FindAsync(
                It.IsAny<FilterDefinition<Customer>>(),
                It.IsAny<FindOptions<Customer, Customer>>(),
                It.IsAny<CancellationToken>()))
                .ReturnsAsync(mockCursor.Object);

            var mongoService = new MockMongoService(mockCollection.Object);
            var options = Options.Create(new MongoDbSettings { MongoDbDatabaseName = "test" });
            var repo = new CustomerRepository(mongoService, options);

            var exists = await repo.DNIExists("12345678A");

            Assert.True(exists);
        }

        private class MockMongoService : GtMotive.Estimate.Microservice.Infrastructure.MongoDb.MongoService
        {
            private readonly IMongoCollection<Customer> _collection;
            public MockMongoService(IMongoCollection<Customer> collection) : base(null)
            {
                _collection = collection;
            }
            public override IMongoClient MongoClient => new MockMongoClient(_collection);
        }
        private class MockMongoClient : IMongoClient
        {
            private readonly IMongoCollection<Customer> _collection;
            public MockMongoClient(IMongoCollection<Customer> collection) { _collection = collection; }
            public IMongoDatabase GetDatabase(string name, MongoDatabaseSettings settings = null) => new MockMongoDatabase(_collection);
        }
        private class MockMongoDatabase : IMongoDatabase
        {
            private readonly IMongoCollection<Customer> _collection;
            public MockMongoDatabase(IMongoCollection<Customer> collection) { _collection = collection; }
            public IMongoCollection<TDocument> GetCollection<TDocument>(string name, MongoCollectionSettings settings = null) => (IMongoCollection<TDocument>)_collection;
        }
    }
} 