using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.Equipment.Commands
{
    public class AddEquipmentCommand : IRequest<AddEquipmentResult>
    {
        public string? EquipmentName { get; set; }
    }

    public record AddEquipmentResult(string Result);

    public class AddEquipmentCommandHandler : IRequestHandler<AddEquipmentCommand, AddEquipmentResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddEquipmentCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddEquipmentResult> Handle(AddEquipmentCommand request, CancellationToken cancellationToken)
        {
           var equipment = new Domain.Equipment.Entities.Equipment
           {
               EquipmentName = request.EquipmentName
           };

           await _dbContext.Equipment.AddAsync(equipment, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddEquipmentResult("done");
        }
    }
}