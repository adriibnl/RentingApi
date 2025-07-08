using System;
using System.Threading.Tasks;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer;
using GtMotive.Estimate.Microservice.Domain.Entities;
using GtMotive.Estimate.Microservice.Domain.Interfaces;
using Moq;
using Xunit;

namespace GtMotive.Estimate.Microservice.FunctionalTests.UseCases
{
    public class CreateCustomerUseCaseTests
    {
        [Fact]
        public async Task ExecuteValidInputCallsOutputPortWithSuccess()
        {
            var customerFactory = new Mock<ICustomerFactory>();
            var fakeCustomer = new Mock<ICustomer>();
            fakeCustomer.SetupGet(c => c.Id).Returns(Guid.NewGuid());
            fakeCustomer.SetupGet(c => c.DNI).Returns("12345678A");
            fakeCustomer.SetupGet(c => c.Name).Returns("Test Name");
            fakeCustomer.SetupGet(c => c.Email).Returns("test@email.com");
            customerFactory
                .Setup(f => f.NewCustomer(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(fakeCustomer.Object);
            var repo = new Mock<ICustomerRepository>();
            repo.Setup(r => r.DNIExists(It.IsAny<string>())).ReturnsAsync(false);
            var outputPort = new Mock<ICreateCustomerOutputPort>();
            var unitOfWork = new Mock<IUnitOfWork>();
            var useCase = new CreateCustomerUseCase(
                customerFactory.Object,
                repo.Object,
                outputPort.Object,
                unitOfWork.Object);
            var input = new CreateCustomerInput("Test Name", "12345678A", "test@email.com");

            await useCase.Execute(input);

            outputPort.Verify(o => o.StandardHandle(It.IsAny<CreateCustomerOutput>()), Times.Once);
        }
    }
}
