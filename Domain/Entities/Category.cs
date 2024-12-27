namespace Domain.Entities;

public class Category
{
    public Category(Guid id, string name, string description, string color, DateOnly creationDate)
    {
        Id = id;
        Name = name;
        Description = description;
        Color = color;
        CreationDate = creationDate;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public string Color { get; set; }
    public DateOnly CreationDate { get; set; }
}