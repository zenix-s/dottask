using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Repository;

namespace Application.Tasks.query.GetWorkspaceTasks;

internal sealed class GetWorkspaceTasksQueryHandler
(
    ITasksRepository tasksRepository,
    IWorkspaceRepository workspaceRepository
) : IQueryHandler<GetWorkspaceTasksQuery, IEnumerable<GetWorkspaceTasksResponse>>
{
    public async Task<Result<IEnumerable<GetWorkspaceTasksResponse>>> Handle
    (
        GetWorkspaceTasksQuery request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var workspace = await workspaceRepository.GetByIdAsync(Guid.Parse(request.WorkspaceId));

            if (workspace == null)
            {
                return Result.Failure<IEnumerable<GetWorkspaceTasksResponse>>(
                    new Error(ErrorCodes.NotFound, $"Workspace not found, for id: {request.WorkspaceId}"));
            }
            
            var queryResult = await tasksRepository.GetWorkspaceTasksAsync(workspace);

            if (!queryResult.Any())
            {
                return Result.Failure<IEnumerable<GetWorkspaceTasksResponse>>(
                    new Error(ErrorCodes.NotFound, $"Workspace with id: {request.WorkspaceId} has no tasks"));
            }

            return Result.Success(queryResult.Select(row =>
            {
                var response = new GetWorkspaceTasksResponse(
                    row.Id.ToString(),
                    row.Name,
                    row.Description,
                    row.CreatedAt,
                    row.Priority.Name,
                    row.IsCompleted,
                    row.StartDate,
                    row.EndDate
                );

                return response;
            }));
        }
        catch (Exception ex)
        {
            return Result.Failure<IEnumerable<GetWorkspaceTasksResponse>>(
                new Error(ErrorCodes.Error, ex.Message));
        }
    }
}