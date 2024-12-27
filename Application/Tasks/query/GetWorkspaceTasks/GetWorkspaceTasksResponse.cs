namespace Application.Tasks.query.GetWorkspaceTasks;

public record GetWorkspaceTasksResponse(
    string Id,
    string Name,
    string? Description,
    DateOnly CreatedAt,
    string Priority,
    bool IsCompleted,
    DateOnly? StartDate,
    DateOnly? EndDate
);

public record GetWorkspaceTasksPriorityResponse(
    int Value,
    string Name
);