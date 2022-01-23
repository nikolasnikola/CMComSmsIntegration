using CM.Text;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmsAPI.Infrastructure.CMDotCom
{
    /// <summary>
    /// A client to send SMS messages. 
    /// </summary>
    public interface ICmTextClient
    {
        /// <summary>
        /// Sends SMS messages to users.
        /// </summary>
        /// <param name="messageText">Message text.</param>
        /// <param name="senderName">Sender name.</param>
        /// <param name="phoneNumbers">Recievers phone numbers.</param>
        /// <returns></returns>
        Task<TextClientResult> SendMessages(string messageText, string senderName, IEnumerable<string> phoneNumbers);
    }
}
