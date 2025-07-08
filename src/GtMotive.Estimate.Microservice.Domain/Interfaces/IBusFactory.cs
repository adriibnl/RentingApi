using System;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Factory interface for creating bus clients.
    /// </summary>
    public interface IBusFactory
    {
        /// <summary>
        /// Gets a bus client for the specified event type.
        /// </summary>
        /// <param name="eventType">The type of event.</param>
        /// <returns>A bus client instance.</returns>
        IBus GetClient(Type eventType);
    }
}
