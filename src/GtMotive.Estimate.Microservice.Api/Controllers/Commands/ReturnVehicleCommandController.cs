using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReturnVehicleCommandController(
        IReturnVehicleUseCase returnVehicleUseCase,
        IReturnVehicleOutputPort outputPort) : ControllerBase
    {
        private readonly IReturnVehicleUseCase _returnVehicleUseCase = returnVehicleUseCase;
        private readonly IReturnVehicleOutputPort _outputPort = outputPort;

        [HttpPost]
        public async Task<IActionResult> Return([FromBody] ReturnVehicleRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            if (request.VehicleId is null || request.EndDate is null)
            {
                return BadRequest("VehicleId and EndDate are required.");
            }

            var input = new ReturnVehicleInput(
                request.VehicleId.Value,
                request.EndDate.Value);

            await _returnVehicleUseCase.Execute(input);
            var presenter = (IWebApiPresenter)_outputPort;
            return presenter.ActionResult;
        }
    }
}
