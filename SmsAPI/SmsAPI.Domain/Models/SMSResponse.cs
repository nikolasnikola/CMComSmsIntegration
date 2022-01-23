using System;

namespace SmsAPI.Domain.Models
{
    public class SMSResponse
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMSResponse"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toUserId"></param>
        public SMSResponse(string message, string toUserPhoneNumber, string senderName, string messageStatus)
        {
            Id = Guid.NewGuid();
            Message = message;
            ToUserPhoneNumber = toUserPhoneNumber;
            SenderName = senderName;
            MessageStatus = messageStatus;
        }

        /// <summary>
        /// Gets Id.
        /// </summary>
        public Guid Id { get; }

        /// <summary>
        /// Gets SMS message.
        /// </summary>
        public string Message { get; private set; }

        /// <summary>
        /// Gets Sender name.
        /// </summary>
        public string SenderName { get; private set; }

        /// <summary>
        /// Gets Message status.
        /// </summary>
        public string MessageStatus { get; private set; }

        /// <summary>
        /// Gets message reciever user ID.
        /// </summary>
        public string ToUserPhoneNumber { get; private set; }
    }
}
