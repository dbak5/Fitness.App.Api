using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.BodyPart.Commands
{
    public class AddBodyPartCommand : IRequest<AddBodyPartResult>
    {
        public string? EquipmentName { get; set; }
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
           var equipment = new Domain.Equipment.Entities.Equipment
           {
               EquipmentName = request.EquipmentName
           };

           await _dbContext.Equipment.AddAsync(equipment, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddBodyPartResult("done");
        }
    }
}