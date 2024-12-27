using Domain.Enums;

namespace Domain.Entities;

public class Workspace
{
    public Workspace
    (
        Guid id,
        string name,
        string? description,
        DateOnly creationDate,
        bool archived
    )
    {
        Id = id;
        Name = name;
        Description = description;
        CreationDate = creationDate;
        Archived = archived;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly CreationDate { get; set; }
    public bool Archived { get; set; }

    public Task AddTask(
        string name,
        Priority priority,
        string? description,
        DateOnly? startDate,
        DateOnly? endDate
    )
    {
        if (Archived)
            throw new InvalidOperationException("Workspace already archived");

        Task task = new(Guid.NewGuid(), name, DateOnly.FromDateTime(DateTime.Now), priority,
            false, description, startDate, endDate);

        return task;
    }

    public static Workspace NewWorkspace(string name, string? description)
    {
        return new Workspace(Guid.NewGuid(), name, description, DateOnly.FromDateTime(DateTime.Now), false);
    }
}