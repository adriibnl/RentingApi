using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.ReturnVehicle;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Presenter for return vehicle use case.
    /// </summary>
    public class ReturnVehiclePresenter : IReturnVehicleOutputPort, IWebApiPresenter
    {
        /// <summary>
        /// Gets the action result.
        /// </summary>
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <summary>
        /// Handles the standard output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void StandardHandle(ReturnVehicleOutput output)
        {
            ActionResult = new OkObjectResult(output);
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
        /// Handles the vehicle not rented case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void VehicleNotRentedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }

        /// <summary>
        /// Handles the rental already completed case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void RentalAlreadyCompletedHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }

        /// <summary>
        /// Handles the invalid end date case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void InvalidEndDateHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }
    }
}
