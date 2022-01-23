using CM.Text;
using MediatR;
using SmsAPI.Application.Queries;
using SmsAPI.Domain.Models;
using SmsAPI.Infrastructure.CMDotCom;
using SmsAPI.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SmsAPI.Application.Commands
{
    /// <inheritdoc/>
    public class SendSMSCommandHandler : IRequestHandler<SendSMSCommand, TextClientResult>
    {
        private readonly IUserQueries _userQueries;
        private readonly ICmTextClient _cmTextClient;
        private readonly ISMSResponseRepository _smsResponseRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="SendSMSCommandHandler"/> class.
        /// </summary>
        /// <param name="userQueries"><see cref="IUserQueries"/>.</param>
        /// <param name="cmTextClient"><see cref="ICmTextClient"/>.</param>
        /// <param name="smsResponseRepository"><see cref="ISMSResponseRepository"/>.</param>
        public SendSMSCommandHandler(
            IUserQueries userQueries,
            ICmTextClient cmTextClient,
            ISMSResponseRepository smsResponseRepository)
        {
            _userQueries = userQueries;
            _cmTextClient = cmTextClient;
            _smsResponseRepository = smsResponseRepository;
        }

        /// <inheritdoc/>
        public async Task<TextClientResult> Handle(SendSMSCommand request, CancellationToken cancellationToken)
        {
            var phoneNumbers = await _userQueries
                .GetUserPhoneNumbersByIds(request.ToUserIds)
                .ConfigureAwait(false);

            var result = await _cmTextClient
                .SendMessages(request.Message, request.SenderName, phoneNumbers)
                .ConfigureAwait(false);

            await CreateResponseRecords(request, result, cancellationToken)
                .ConfigureAwait(false);

            return result;
        }

        private async Task CreateResponseRecords(SendSMSCommand request, TextClientResult result, CancellationToken cancellationToken)
        {
            List<SMSResponse> responses = new List<SMSResponse>();

            foreach (var item in result.details)
            {
                var response = new SMSResponse(request.Message, item.to, request.SenderName, item.status);
                responses.Add(response);
            }

            await _smsResponseRepository
                .AddSmsResponseRangeAsync(responses, cancellationToken)
                .ConfigureAwait(false);
        }

    }
}
