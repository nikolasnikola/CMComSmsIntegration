using System;

namespace SmsAPI.Application.DTO
{
    public class SmsResponseDto
    {
        /// <summary>
        /// Gets or sets Id.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets SMS message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets message sender name.
        /// </summary>
        public string SenderName { get; set; }

        /// <summary>
        /// Gets or sets message reciever user ID.
        /// </summary>
        public int ToUserId { get; set; }

        /// <summary>
        /// Gets or sets message reciever user name.
        /// </summary>
        public string ToUserName { get; set; }

        /// <summary>
        /// Gets or sets message reciever user phone number.
        /// </summary>
        public string ToUserPhoneNumber { get; set; }
    }
}
