namespace Fitness.App.Api.Domain.BodyPart.Entities;

public partial class BodyPart
{
    public int BodyPartId { get; set; }

    public string? BodyPartName { get; set; }

    public virtual ICollection<Exercise.Entities.Exercise> Exercises { get; set; } = new List<Exercise.Entities.Exercise>();
}
