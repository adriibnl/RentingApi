namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer
{
    /// <summary>
    /// Output port for creating a customer use case.
    /// </summary>
    public interface ICreateCustomerOutputPort : IOutputPortStandard<CreateCustomerOutput>, IOutputPortNotFound
    {
        /// <summary>
        /// Handles the case when a customer with the same DNI already exists.
        /// </summary>
        /// <param name="message">The error message.</param>
        void DNIAlreadyExistsHandle(string message);
    }
}
