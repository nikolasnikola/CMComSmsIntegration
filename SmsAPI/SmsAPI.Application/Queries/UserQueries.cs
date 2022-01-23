using SmsAPI.Infrastructure;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmsAPI.Application.Queries
{
    /// <inheritdoc/>
    public class UserQueries : IUserQueries
    {
        private readonly SMSApiContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserQueries"/> class.
        /// </summary>
        /// <param name="context">ctx.</param>
        public UserQueries(SMSApiContext context)
        {
            _context = context;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<string>> GetUserPhoneNumbersByIds(IEnumerable<int> userIds)
        {
            // TODO remove mocked data and add finding phone numbers by id list after implementing identity.

            await Task.Delay(1).ConfigureAwait(false);

            return new List<string>
            {
                "00123456789",
                "+987654321",
            };
        }
    }
}
