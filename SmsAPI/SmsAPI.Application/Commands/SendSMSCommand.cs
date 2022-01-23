using CM.Text;
using MediatR;
using System.Collections.Generic;

namespace SmsAPI.Application.Commands
{
    public class SendSMSCommand : IRequest<TextClientResult>
    {
        /// <summary>
        /// Gets or sets SMS Message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets UserId.
        /// </summary>

        public IEnumerable<int> ToUserIds { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets SMS Sender name.
        /// </summary>
        public string SenderName { get; set; }
    }
}
