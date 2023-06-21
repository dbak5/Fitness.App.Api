using Fitness.App.Api.Application.Program.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.App.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProgramController : ControllerBase
    {

        private readonly ILogger<ProgramController> _logger;
        private readonly IMediator _mediator;
        public ProgramController(ILogger<ProgramController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateProgram")]
        public async Task<AddProgramResult> Create([FromBody] AddProgramCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}