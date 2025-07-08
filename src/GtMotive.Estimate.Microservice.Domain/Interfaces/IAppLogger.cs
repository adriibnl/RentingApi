namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Application logger interface for logging operations.
    /// </summary>
    /// <typeparam name="T">The type of the logger category.</typeparam>
    public interface IAppLogger<T>
    {
        /// <summary>
        /// Logs an information message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message.</param>
        void LogInformation(string message, params object[] args);

        /// <summary>
        /// Logs a warning message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message.</param>
        void LogWarning(string message, params object[] args);

        /// <summary>
        /// Logs an error message with exception details.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message.</param>
        void LogError(string message, params object[] args);

        /// <summary>
        /// Logs a debug message.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="args">The arguments to format the message.</param>
        void LogDebug(string message, params object[] args);
    }
}
