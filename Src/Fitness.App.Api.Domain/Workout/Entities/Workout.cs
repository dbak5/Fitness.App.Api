namespace Fitness.App.Api.Domain.Workout.Entities;

public partial class Workout
{
    public int WorkoutId { get; set; }

    public required string WorkoutName { get; set; }

    public int? Exercise { get; set; }

    public int? Equipment { get; set; }

    public int? Sets { get; set; }

    public int? Reps { get; set; }

    public int? Weight { get; set; }

    public string? Note { get; set; }

    public bool? MadeLift { get; set; }

    public DateOnly? Date { get; set; }

    public virtual Equipment.Entities.Equipment? EquipmentNavigation { get; set; }

    public virtual Exercise.Entities.Exercise? ExerciseNavigation { get; set; }

    public virtual ICollection<Pb.Entities.Pb> Pbs { get; set; } = new List<Pb.Entities.Pb>();
}
