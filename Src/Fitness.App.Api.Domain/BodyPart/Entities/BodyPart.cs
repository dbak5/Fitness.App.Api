namespace Fitness.App.Api.Domain.BodyPart.Entities;

public partial class BodyPart
{
    public required int BodyPartId { get; set; }

    public required string BodyPartName { get; set; }

    public virtual ICollection<Exercise.Entities.Exercise> Exercises { get; set; } = new List<Exercise.Entities.Exercise>();
}
