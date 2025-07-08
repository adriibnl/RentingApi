using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AvailableVehiclesQueryController(
        IListAvailableVehiclesUseCase listAvailableVehiclesUseCase,
        IListAvailableVehiclesOutputPort outputPort) : ControllerBase
    {
        private readonly IListAvailableVehiclesUseCase _listAvailableVehiclesUseCase = listAvailableVehiclesUseCase;
        private readonly IListAvailableVehiclesOutputPort _outputPort = outputPort;

        [HttpGet]
        public async Task<IActionResult> GetAvailableVehicles()
        {
            var input = new ListAvailableVehiclesInput();
            await _listAvailableVehiclesUseCase.Execute(input);
            var presenter = (IWebApiPresenter)_outputPort;
            return presenter.ActionResult;
        }
    }
}
