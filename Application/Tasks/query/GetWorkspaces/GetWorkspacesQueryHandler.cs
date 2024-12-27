using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Repository;

namespace Application.Tasks.query.GetWorkspaces;

internal sealed class GetWorkspacesQueryHandler
    : IQueryHandler<GetWorkspacesQuery, IEnumerable<GetWorkspacesResponse>>
{
    private readonly IWorkspaceRepository _workspaceRepository;

    public GetWorkspacesQueryHandler(IWorkspaceRepository workspaceRepository)
    {
        _workspaceRepository = workspaceRepository;
    }


    public async Task<Result<IEnumerable<GetWorkspacesResponse>>> Handle(GetWorkspacesQuery request,
        CancellationToken cancellationToken)
    {
        try
        {
            var queryResul = (await _workspaceRepository.GetAllAsync()).ToList();
            
            if (queryResul.Count == 0)
                return Result.Failure<IEnumerable<GetWorkspacesResponse>>(Error.NotFound);
            
            return Result.Success(queryResul.Select(row => new GetWorkspacesResponse(
                row.Id.ToString(),
                row.Name,
                row.Description,
                row.CreationDate
            )));
        }
        catch (Exception ex)
        {
            return Result.Failure<IEnumerable<GetWorkspacesResponse>>(Error.InternalError);
        }
    }
}