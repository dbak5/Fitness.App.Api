namespace Fitness.App.Api.Domain.Equipment.Entities;

public partial class Equipment
{
    public int EquipmentId { get; set; }

    public string? EquipmentName { get; set; }

    public virtual ICollection<Program.Entities.Program> Programs { get; set; } = new List<Program.Entities.Program>();

    public virtual ICollection<Workout.Entities.Workout> Workouts { get; set; } = new List<Workout.Entities.Workout>();
}
