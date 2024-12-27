using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Repository;


namespace Application.Workspaces.Commands.CreateWorkspace;

internal sealed class CreateWorkspaceCommandHandler(IWorkspaceRepository workspaceRepository)
    : ICommandHandler<CreateWorkspaceCommand>
{
    public async Task<Result> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        Workspace workspace = Workspace.NewWorkspace(request.Name, request.Description);

        var rows = await workspaceRepository.AddAsync(workspace);

        if (rows <= 0)
            return Result.Failure(new Error(ErrorCodes.Error, "There was an error creating the workspace"));

        return Result.Success();
    }
}