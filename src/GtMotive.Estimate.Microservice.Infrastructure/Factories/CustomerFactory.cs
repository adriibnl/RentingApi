using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;

namespace GtMotive.Estimate.Microservice.Infrastructure.Factories
{
    public class CustomerFactory : ICustomerFactory
    {
        public ICustomer NewCustomer(string dni, string name, string email)
        {
            return new Customer(dni, name, email);
        }
    }
}
