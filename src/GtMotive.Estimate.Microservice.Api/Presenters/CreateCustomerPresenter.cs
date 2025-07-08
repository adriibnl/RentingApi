using GtMotive.Estimate.Microservice.Api.UseCases;
using GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer;
using Microsoft.AspNetCore.Mvc;

namespace GtMotive.Estimate.Microservice.Api.Presenters
{
    /// <summary>
    /// Presenter for create customer use case.
    /// </summary>
    public class CreateCustomerPresenter : ICreateCustomerOutputPort, IWebApiPresenter
    {
        /// <summary>
        /// Gets the action result.
        /// </summary>
        public IActionResult ActionResult { get; private set; } = new NoContentResult();

        /// <summary>
        /// Handles the standard output.
        /// </summary>
        /// <param name="output">The output.</param>
        public void StandardHandle(CreateCustomerOutput output)
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
        /// Handles the DNI already exists case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void DNIAlreadyExistsHandle(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }

        /// <summary>
        /// Handles the bad request case.
        /// </summary>
        /// <param name="message">The error message.</param>
        public void BadRequest(string message)
        {
            ActionResult = new BadRequestObjectResult(new { message });
        }
    }
}
