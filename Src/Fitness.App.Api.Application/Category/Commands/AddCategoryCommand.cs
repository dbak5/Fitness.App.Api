using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.Category.Commands
{
    public class AddCategoryCommand : IRequest<AddCategoryResult>
    {
        public required string CategoryName { get; set; }
    }

    public record AddCategoryResult(string Result);

    public class AddCategoryCommandHandler : IRequestHandler<AddCategoryCommand, AddCategoryResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddCategoryCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddCategoryResult> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
        {
           var category = new Domain.Category.Entities.Category
           {
               CategoryName = request.CategoryName
           };

           await _dbContext.Categories.AddAsync(category, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddCategoryResult("done");
        }
    }
}