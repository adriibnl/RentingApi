using System.Collections.Generic;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Telemetry interface for tracking events and metrics.
    /// </summary>
    public interface ITelemetry
    {
        /// <summary>
        /// Tracks an event with optional properties and metrics.
        /// </summary>
        /// <param name="eventName">The name of the event to track.</param>
        /// <param name="properties">Optional properties associated with the event.</param>
        /// <param name="metrics">Optional metrics associated with the event.</param>
        void TrackEvent(string eventName, IDictionary<string, string> properties = null, IDictionary<string, double> metrics = null);

        /// <summary>
        /// Tracks a metric with optional properties.
        /// </summary>
        /// <param name="name">The name of the metric to track.</param>
        /// <param name="value">The value of the metric.</param>
        /// <param name="properties">Optional properties associated with the metric.</param>
        void TrackMetric(string name, double value, IDictionary<string, string> properties = null);
    }
}
