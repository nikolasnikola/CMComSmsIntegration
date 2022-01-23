using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmsAPI.Application.Queries
{
    /// <summary>
    /// Queries to get user data.
    /// </summary>
    public interface IUserQueries
    {
        /// <summary>
        /// Gets user phone number by list of user ids.
        /// </summary>
        /// <param name="userIds">.</param>
        /// <returns>List of user phone numbers.</returns>
        Task<IEnumerable<string>> GetUserPhoneNumbersByIds(IEnumerable<int> userIds);
    }
}
