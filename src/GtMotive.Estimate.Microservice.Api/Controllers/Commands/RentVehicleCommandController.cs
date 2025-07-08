using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentVehicleCommandController(
        IRentVehicleUseCase rentVehicleUseCase,
        IRentVehicleOutputPort outputPort) : ControllerBase
    {
        private readonly IRentVehicleUseCase _rentVehicleUseCase = rentVehicleUseCase;
        private readonly IRentVehicleOutputPort _outputPort = outputPort;

        [HttpPost]
        public async Task<IActionResult> Rent([FromBody] RentVehicleRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            if (request.CustomerId is null || request.VehicleId is null || request.StartDate is null)
            {
                return BadRequest("All fields are required.");
            }

            var input = new RentVehicleInput(
                request.VehicleId.Value,
                request.CustomerId.Value,
                request.StartDate.Value);

            await _rentVehicleUseCase.Execute(input);
            var presenter = (IWebApiPresenter)_outputPort;
            return presenter.ActionResult;
        }
    }
}
