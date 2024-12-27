namespace Application.Tasks.query.GetWorkspaces;

public record GetWorkspacesResponse
(
     string Id, 
     string Name, 
     string? Description, 
     DateOnly CreationDate
);