using Application.Abstractions.Messaging;

namespace Application.Tasks.query.GetWorkspaceTasks;

public record GetWorkspaceTasksQuery
(
    string WorkspaceId
) : IQuery<IEnumerable<GetWorkspaceTasksResponse>>;