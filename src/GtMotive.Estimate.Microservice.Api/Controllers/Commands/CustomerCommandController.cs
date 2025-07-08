using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerCommandController(
        ICreateCustomerUseCase createCustomerUseCase,
        ICreateCustomerOutputPort outputPort) : ControllerBase
    {
        private readonly ICreateCustomerUseCase _createCustomerUseCase = createCustomerUseCase;
        private readonly ICreateCustomerOutputPort _outputPort = outputPort;

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCustomerRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            var input = new CreateCustomerInput(
                request.Dni,
                request.Name,
                request.Email);

            await _createCustomerUseCase.Execute(input);
            var presenter = (IWebApiPresenter)_outputPort;
            return presenter.ActionResult;
        }
    }
}
