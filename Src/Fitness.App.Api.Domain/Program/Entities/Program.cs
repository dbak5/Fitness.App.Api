namespace Fitness.App.Api.Domain.Program.Entities;

public partial class Program
{
    public int ProgramId { get; set; }

    public string ProgramName { get; set; } = null!;

    public int Day { get; set; }

    public int Exercise { get; set; }

    public int? Equipment { get; set; }

    public int? Sets { get; set; }

    public int? Reps { get; set; }

    public int? Weight { get; set; }

    public virtual Equipment.Entities.Equipment? EquipmentNavigation { get; set; }

    public virtual Exercise.Entities.Exercise ExerciseNavigation { get; set; } = null!;
}
