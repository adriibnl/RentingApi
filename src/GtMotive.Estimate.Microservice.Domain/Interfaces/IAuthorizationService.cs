using System.Security.Claims;
using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Authorization service interface for checking user permissions.
    /// </summary>
    public interface IAuthorizationService
    {
        /// <summary>
        /// Authorizes a user against a resource with a specific policy.
        /// </summary>
        /// <param name="user">The user to authorize.</param>
        /// <param name="resource">The resource to authorize against.</param>
        /// <param name="policyName">The name of the policy to check.</param>
        /// <returns>A task that represents the asynchronous operation. The task result indicates whether the user is authorized.</returns>
        Task<bool> Authorize(ClaimsPrincipal user, object resource, string policyName);
    }
}
