using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.RentVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Presenter for rent vehicle use case.
    /// </summary>
    public class RentVehiclePresenter : IRentVehicleOutputPort, IWebApiPresenter
    {
        /// <summary>
        /// Gets the action result.
        /// </summary>
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <summary>
        /// Handles the standard output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void StandardHandle(RentVehicleOutput output)
        {
            ActionResult = new CreatedResult(string.Empty, output);
        }

        /// <summary>
        /// Handles the not found case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void NotFoundHandle(string message)
        {
            ActionResult = new NotFoundObjectResult(new { message });
        }

        /// <summary>
        /// Handles the vehicle not available case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void VehicleNotAvailableHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }

        /// <summary>
        /// Handles the customer already has active rental case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void CustomerAlreadyHasActiveRentalHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }

        /// <summary>
        /// Handles the vehicle too old case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void VehicleTooOldHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }
    }
}
