using Fitness.App.Api.Persistence;
using MediatR;

namespace Fitness.App.Api.Application.Workout.Commands
{
    public class AddWorkoutCommand : IRequest<AddWorkoutResult>
    {
        public required string WorkoutName { get; set; }
    }

    public record AddWorkoutResult(string Result);

    public class AddWorkoutCommandHandler : IRequestHandler<AddWorkoutCommand, AddWorkoutResult>
    {
        private readonly FitnessAppContext _dbContext;

        public AddWorkoutCommandHandler(FitnessAppContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AddWorkoutResult> Handle(AddWorkoutCommand request, CancellationToken cancellationToken)
        {
           var workout = new Domain.Workout.Entities.Workout
           {
               WorkoutName = request.WorkoutName
           };

           await _dbContext.Workouts.AddAsync(workout, cancellationToken);
           await _dbContext.SaveChangesAsync(cancellationToken);
           return new AddWorkoutResult("done");
        }
    }
}