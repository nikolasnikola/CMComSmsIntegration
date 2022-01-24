using SmsAPI.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmsAPI.Infrastructure.Repositories
{
    /// <inheritdoc/>
    public class SMSResponseRepository : ISMSResponseRepository
    {
        private readonly SMSApiContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="SMSResponseRepository"/> class.
        /// </summary>
        /// <param name="context">ctx.</param>
        public SMSResponseRepository(SMSApiContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task AddSmsResponseRangeAsync(IEnumerable<SMSResponse> smsResponses, CancellationToken cancellationToken)
        {
            await _context.SMSResponses
                .AddRangeAsync(smsResponses, cancellationToken)
                .ConfigureAwait(false);
        }

        public async Task SaveChanges(CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }
    }
}
