using Application.Abstractions.Messaging;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Task = Domain.Entities.Task;

namespace Application.Tasks.Commands.AddTask;

internal sealed class AddTaskCommandHandler : ICommandHandler<AddTaskCommand>
{
    private readonly ITasksRepository _tasksRepository;
    private readonly IWorkspaceRepository _workspaceRepository;

    public AddTaskCommandHandler(ITasksRepository tasksRepository, IWorkspaceRepository workspaceRepository)
    {
        _tasksRepository = tasksRepository;
        _workspaceRepository = workspaceRepository;
    }


    public async Task<Result> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Workspace? workspace = await _workspaceRepository.GetByIdAsync(Guid.Parse(request.WorkspaceId));

            if (workspace == null)
                return Result.Failure(new Error("NotFound", "Workspace not found"));

            Task task = workspace.AddTask("Task", Priority.None, null, null, null);

            await _tasksRepository.AddWorkspaceTaskAsync(workspace, task);

            return Result.Success();
        }
        catch (Exception ex)
        {
            return Result.Failure(new Error("Error", ex.Message));
        }
    }
}