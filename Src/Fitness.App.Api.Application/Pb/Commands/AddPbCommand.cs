using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.Pb.Commands
{
    public class AddPbCommand : IRequest<AddPbResult>
    {
        public required string PbName { get; set; }
    }

    public record AddPbResult(string Result);

    public class AddPbCommandHandler : IRequestHandler<AddPbCommand, AddPbResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddPbCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddPbResult> Handle(AddPbCommand request, CancellationToken cancellationToken)
        {
           var pb = new Domain.Pb.Entities.Pb
           {
               PbName = request.PbName
           };

           await _dbContext.Pbs.AddAsync(pb, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddPbResult("done");
        }
    }
}