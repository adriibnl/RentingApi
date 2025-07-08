using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.MongoDb
{
    public class UnitOfWork : IUnitOfWork
    {
        public Task<int> Save()
        {
            return Task.FromResult(1);
        }
    }
}
