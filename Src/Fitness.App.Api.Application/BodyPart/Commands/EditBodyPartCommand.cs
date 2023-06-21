using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.BodyPart.Commands
{
    public class EditBodyPartCommand : IRequest<EditBodyPartResult>
    {
        public required string BodyPartName { get; set; }
        public required int BodyPartId{ get; set; }
    }

    public record EditBodyPartResult(string Result);

    public class EditBodyPartCommandHandler : IRequestHandler<EditBodyPartCommand, EditBodyPartResult>
    {
        private readonly FitnessAppContext _dbContext;

        public EditBodyPartCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<EditBodyPartResult> Handle(EditBodyPartCommand request, CancellationToken cancellationToken)
        {
            
            var bodyPart = new Domain.BodyPart.Entities.BodyPart
            {
                BodyPartName = request.BodyPartName,
                BodyPartId = request.BodyPartId
            };

             _dbContext.BodyParts.Update(bodyPart);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new EditBodyPartResult("done");
        }
    }
}