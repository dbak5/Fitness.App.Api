using Fitness.App.Api.Application.Pb.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.App.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PbController : ControllerBase
    {

        private readonly ILogger<PbController> _logger;
        private readonly IMediator _mediator;
        public PbController(ILogger<PbController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreatePb")]
        public async Task<AddPbResult> Create([FromBody] AddPbCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}