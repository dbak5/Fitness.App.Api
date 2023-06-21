using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.Exercise.Commands
{
    public class AddExerciseCommand : IRequest<AddExerciseResult>
    {
        public required string ExerciseName { get; set; }
    }

    public record AddExerciseResult(string Result);

    public class AddExerciseCommandHandler : IRequestHandler<AddExerciseCommand, AddExerciseResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddExerciseCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddExerciseResult> Handle(AddExerciseCommand request, CancellationToken cancellationToken)
        {
           var exercise = new Domain.Exercise.Entities.Exercise
           {
               ExerciseName = request.ExerciseName
           };

           await _dbContext.Exercises.AddAsync(exercise, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddExerciseResult("done");
        }
    }
}