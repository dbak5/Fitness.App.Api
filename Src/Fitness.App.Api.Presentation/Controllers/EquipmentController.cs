using Fitness.App.Api.Application.Equipment.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.App.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentController : ControllerBase
    {

        private readonly ILogger<EquipmentController> _logger;
        private readonly IMediator _mediator;
        public EquipmentController(ILogger<EquipmentController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateEquipment")]
        public async Task<AddEquipmentResult> Create([FromBody]AddEquipmentCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}