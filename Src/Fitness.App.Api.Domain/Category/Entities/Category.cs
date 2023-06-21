namespace Fitness.App.Api.Domain.Category.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public required string CategoryName { get; set; }

    public virtual ICollection<Exercise.Entities.Exercise> Exercises { get; set; } = new List<Exercise.Entities.Exercise>();
}
