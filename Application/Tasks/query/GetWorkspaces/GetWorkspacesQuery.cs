using Application.Abstractions.Messaging;

namespace Application.Tasks.query.GetWorkspaces;

public record GetWorkspacesQuery() : IQuery<IEnumerable<GetWorkspacesResponse>>;