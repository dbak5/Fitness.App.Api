using Fitness.App.Api.Application.Category.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Fitness.App.Api.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoryController : ControllerBase
    {

        private readonly ILogger<CategoryController> _logger;
        private readonly IMediator _mediator;
        public CategoryController(ILogger<CategoryController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateCategory")]
        public async Task<AddCategoryResult> Create([FromBody] AddCategoryCommand command)
        {
            var result = await _mediator.Send(command);
            return result;
        }
    }
}