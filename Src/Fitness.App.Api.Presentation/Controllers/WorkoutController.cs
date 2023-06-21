using Fitness.App.Api.Application.Workout.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.App.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkoutController : ControllerBase
    {

        private readonly ILogger<WorkoutController> _logger;
        private readonly IMediator _mediator;
        public WorkoutController(ILogger<WorkoutController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateWorkout")]
        public async Task<AddWorkoutResult> Create([FromBody] AddWorkoutCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}