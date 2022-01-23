using CM.Text;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmsAPI.Application.Commands;
using System;
using System.Threading.Tasks;

namespace SmsAPI.Api.Controllers
{
    /// <summary>
    /// Sms controller.
    /// </summary>
    [Route("api/sms")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Initializes a new instance of the <see cref="SmsController"/> class.
        /// </summary>
        /// <param name="mediator">Instance of <see cref="IMediator"/>.</param>
        public SmsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [ProducesResponseType(typeof(TextClientResult), StatusCodes.Status200OK)]
        public async Task<TextClientResult> SendSms([FromBody] SendSMSCommand command)
        {
            GuardCommand(command);

            return await _mediator.Send(command).ConfigureAwait(false);
        }

        private void GuardCommand(SendSMSCommand command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }
        }
    }
}
