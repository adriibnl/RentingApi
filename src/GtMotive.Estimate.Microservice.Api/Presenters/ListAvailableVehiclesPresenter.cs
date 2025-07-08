using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ListAvailableVehicles;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Presenter for list available vehicles use case.
    /// </summary>
    public class ListAvailableVehiclesPresenter : IListAvailableVehiclesOutputPort, IWebApiPresenter
    {
        /// <summary>
        /// Gets the action result.
        /// </summary>
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <summary>
        /// Handles the standard output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void StandardHandle(ListAvailableVehiclesOutput output)
        {
            ActionResult = new OkObjectResult(output);
        }

        /// <summary>
        /// Handles the not found case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void HandleNotFound(string message)
        {
            ActionResult = new NotFoundObjectResult(message);
        }

        /// <summary>
        /// Handles the standard output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void HandleStandard(ListAvailableVehiclesOutput output)
        {
            ActionResult = new OkObjectResult(output);
        }
    }
}
