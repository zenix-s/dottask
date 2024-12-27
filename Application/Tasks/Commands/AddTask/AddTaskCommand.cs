using Application.Abstractions.Messaging;

namespace Application.Tasks.Commands.AddTask;

public record AddTaskCommand
(
    string WorkspaceId
) : ICommand;