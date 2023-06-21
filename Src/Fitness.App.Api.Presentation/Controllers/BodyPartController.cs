using Fitness.App.Api.Application.BodyPart.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.App.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BodyPartController : ControllerBase
    {

        private readonly ILogger<BodyPartController> _logger;
        private readonly IMediator _mediator;
        public BodyPartController(ILogger<BodyPartController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateBodyPart")]
        public async Task<AddBodyPartResult> Create([FromBody] AddBodyPartCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }

        [HttpPost(Name = "EditBodyPart")]
        public async Task<EditBodyPartResult> Edit([FromBody] EditBodyPartCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}