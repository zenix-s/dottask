using Domain.Enums;

namespace Domain.Entities;

public class Task
{
    private List<Category> _categories;
    
    public Task
    (
        Guid id, 
        string name, 
        DateOnly createdAt, 
        Priority priority, 
        bool isCompleted,
        string? description, 
        DateOnly? startDate, 
        DateOnly? endDate 
    )
    {
        Id = id;
        Name = name;
        Description = description;
        CreatedAt = createdAt;
        Priority = priority;
        StartDate = startDate;
        EndDate = endDate;
        IsCompleted = isCompleted;
    }

    public Guid Id { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }
    public DateOnly CreatedAt { get; set; }
    public Priority Priority { get; set; }
    public bool IsCompleted { get; set; }
    public DateOnly? StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
}