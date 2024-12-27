using Application.Abstractions.Messaging;

namespace Application.Workspaces.Commands.CreateWorkspace;

public record CreateWorkspaceCommand
(
    string Name,
    string? Description
) : ICommand;