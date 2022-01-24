using SmsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmsAPI.Infrastructure.Repositories
{
    /// <summary>
    /// Repository for <see cref="SMSResponse"/>.
    /// </summary>
    public interface ISMSResponseRepository
    {
        /// <summary>
        /// Adds Sms responses range.
        /// </summary>
        /// <param name="smsResponses">List of sms responses to add.</param>
        /// <param name="cancellationToken">.</param>
        /// <returns>Task.</returns>
        Task AddSmsResponseRangeAsync(IEnumerable<SMSResponse> smsResponses, CancellationToken cancellationToken);

        /// <summary>
        /// Saves changes to db.
        /// </summary>
        /// <param name="cancellationToken">.</param>
        /// <returns>Task.</returns>
        Task SaveChanges(CancellationToken cancellationToken);
    }
}
