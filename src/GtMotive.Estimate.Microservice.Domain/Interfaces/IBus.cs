using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Bus interface for sending messages.
    /// </summary>
    public interface IBus
    {
        /// <summary>
        /// Sends a message through the bus.
        /// </summary>
        /// <param name="message">The message to send.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task Send(object message);
    }
}
