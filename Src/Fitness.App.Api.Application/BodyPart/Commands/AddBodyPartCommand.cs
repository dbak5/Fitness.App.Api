using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.BodyPart.Commands
{
    public class AddBodyPartCommand : IRequest<AddBodyPartResult>
    {
        public required string BodyPartName { get; set; }
        public required int BodyPartId{ get; set; }
    }

    public record AddBodyPartResult(string Result);

    public class AddBodyPartCommandHandler : IRequestHandler<AddBodyPartCommand, AddBodyPartResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddBodyPartCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddBodyPartResult> Handle(AddBodyPartCommand request, CancellationToken cancellationToken)
        {
           var bodyPart = new Domain.BodyPart.Entities.BodyPart
           {
               BodyPartId = request.BodyPartId,
               BodyPartName = request.BodyPartName
           };

           await _dbContext.BodyParts.AddAsync(bodyPart, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddBodyPartResult("done");
        }
    }
}