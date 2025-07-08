using GtMotive.Estimate.Microservice.Api.Models;
using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateVehicle;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    /// <summary>
    /// Controller for vehicle creation operations.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CreateVehicleCommandController(
        ICreateVehicleUseCase createVehicleUseCase,
        ICreateVehicleOutputPort outputPort) : ControllerBase
    {
        private readonly ICreateVehicleUseCase _createVehicleUseCase = createVehicleUseCase;
        private readonly ICreateVehicleOutputPort _outputPort = outputPort;

        /// <summary>
        /// Creates a new vehicle.
        /// </summary>
        /// <param name="request">The vehicle creation request.</param>
        /// <returns>The action result.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateVehicleRequest request)
        {
            if (request == null)
            {
                return BadRequest("Request cannot be null.");
            }

            var input = new CreateVehicleInput(
                request.LicensePlate,
                request.Brand,
                request.Model,
                request.ManufacturingYear.Value);

            await _createVehicleUseCase.Execute(input);
            var presenter = (IWebApiPresenter)_outputPort;
            return presenter.ActionResult;
        }
    }
}
