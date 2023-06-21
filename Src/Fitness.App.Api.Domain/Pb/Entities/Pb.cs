namespace Fitness.App.Api.Domain.Pb.Entities;

public partial class Pb
{
    public int PbId { get; set; }
    public required string PbName { get; set; }

    public int? Workout { get; set; }

    public int? Exercise { get; set; }

    public virtual Exercise.Entities.Exercise? ExerciseNavigation { get; set; }

    public virtual Workout.Entities.Workout? WorkoutNavigation { get; set; }
}
