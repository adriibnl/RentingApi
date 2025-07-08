using System.Threading.Tasks;

namespace GtMotive.Estimate.Microservice.Domain.Interfaces
{
    /// <summary>
    /// Unit of work interface for managing transactions.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Saves all changes made in this unit of work.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the number of affected records.</returns>
        Task<int> Save();
    }
}
