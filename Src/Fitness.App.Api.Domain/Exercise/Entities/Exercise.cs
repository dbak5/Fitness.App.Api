namespace Fitness.App.Api.Domain.Exercise.Entities;

public partial class Exercise
{
    public int ExerciseId { get; set; }

    public required string ExerciseName { get; set; }

    public DateOnly? LastActivity { get; set; }

    public int? Category { get; set; }

    public int? BodyPart { get; set; }

    public virtual BodyPart.Entities.BodyPart? BodyPartNavigation { get; set; }

    public virtual Category.Entities.Category? CategoryNavigation { get; set; }

    public virtual ICollection<Pb.Entities.Pb> Pbs { get; set; } = new List<Pb.Entities.Pb>();

    public virtual ICollection<Program.Entities.Program> Programs { get; set; } = new List<Program.Entities.Program>();

    public virtual ICollection<Workout.Entities.Workout> Workouts { get; set; } = new List<Workout.Entities.Workout>();
}
