using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.Program.Commands
{
    public class AddProgramCommand : IRequest<AddProgramResult>
    {
        public required string ProgramName { get; set; }
    }

    public record AddProgramResult(string Result);

    public class AddProgramCommandHandler : IRequestHandler<AddProgramCommand, AddProgramResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddProgramCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddProgramResult> Handle(AddProgramCommand request, CancellationToken cancellationToken)
        {
           var program = new Domain.Program.Entities.Program
           {
               ProgramName = request.ProgramName
           };

           await _dbContext.Programs.AddAsync(program, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddProgramResult("done");
        }
    }
}