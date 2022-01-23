using CM.Text;
using Microsoft.Extensions.Options;
using SmsAPI.Infrastructure.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace SmsAPI.Infrastructure.CMDotCom
{
    /// <inheritdoc />
    public class CmTextClient : ICmTextClient
    {
        private readonly ITextClient _textClient;

        /// <summary>
        /// Initializes a new instance of the <see cref="CmTextClient"/> class.
        /// </summary>
        /// <param name="cmOptions">.</param>
        public CmTextClient(
            [NotNull] IOptions<CMClientOptions> cmOptions)
        {
            _textClient = new TextClient(new Guid(cmOptions.Value.ApiKey));
        }

        /// <inheritdoc />
        public async Task<TextClientResult> SendMessages(string messageText, string senderName, IEnumerable<string> phoneNumbers)
        {
            return await _textClient.SendMessageAsync(messageText, senderName, phoneNumbers.Select(p => ReformatPhoneNumber(p)), string.Empty).ConfigureAwait(false);
        }

        private string ReformatPhoneNumber(string phoneNumber)
        {
            GuardPhoneNumber(phoneNumber);
            return phoneNumber.StartsWith('+') ? "00" + phoneNumber.Substring(1) : phoneNumber;
        }

        private void GuardPhoneNumber(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }
        }
    }
}
