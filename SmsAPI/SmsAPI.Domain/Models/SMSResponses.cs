using System;

namespace SmsAPI.Domain.Models
{
    public class SMSResponses
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SMSResponses"/> class.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="toUserId"></param>
        public SMSResponses(string message, int toUserId)
        {
            Id = Guid.NewGuid();
            Message = message;
            ToUserId = toUserId;
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
        /// Gets message reciever user ID.
        /// </summary>
        public int ToUserId { get; private set; }
    }
}
