using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.BodyPart.Commands
{
    public class SearchBodyPartCommand : IRequest<SearchBodyPartResult>
    {
        public required string BodyPartName { get }
        public required int BodyPartId { get }
    }

    public record SearchBodyPartResult(string Result);

    public class SearchBodyPartCommandHandler : IRequestHandler<SearchBodyPartCommand, SearchBodyPartResult>
    {
        private readonly FitnessAppContext _dbContext;

        public SearchBodyPartCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<SearchBodyPartResult> Handle(SearchBodyPartCommand request, CancellationToken cancellationToken)
        {

            var bodyPart = new Domain.BodyPart.Entities.BodyPart
            {
                var sources = await _dbContext.Source
                .SingleOrDefaultAsync(x => x.BodyPartId == BodyPartId);
			return sources.First();
		};

            return new SearchBodyPartResult("done");
        }
    }
}