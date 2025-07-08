namespace GtMotive.Estimate.Microservice.ApplicationCore.UseCases.CreateCustomer
{
    /// <summary>
    /// Input data for creating a customer.
    /// </summary>
    /// <param name="dni">The customer's DNI.</param>
    /// <param name="name">The customer's name.</param>
    /// <param name="email">The customer's email.</param>
    public class CreateCustomerInput(string dni, string name, string email) : IUseCaseInput
    {
        /// <summary>
        /// Gets the customer's DNI.
        /// </summary>
        public string DNI { get; } = dni;

        /// <summary>
        /// Gets the customer's name.
        /// </summary>
        public string Name { get; } = name;

        /// <summary>
        /// Gets the customer's email.
        /// </summary>
        public string Email { get; } = email;
    }
}
