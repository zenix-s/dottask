using System.ComponentModel.DataAnnotations;
using Application.Tasks.Commands.AddTask;
using Application.Tasks.query.GetWorkspaces;
using Application.Tasks.query.GetWorkspaceTasks;
using Application.Workspaces.Commands.CreateWorkspace;
using Domain.Abstractions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("workspaces")]
public class WorkspaceController(ISender sender) : ControllerBase
{

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await sender.Send(new GetWorkspacesQuery());

        return result.IsFailure switch
        {
            true when result.Error == Error.NotFound => NoContent(),
            true => Conflict(result),
            _ => Ok(result)
        };
    }

    public record CreateWorkspaceRequest
    (
        [Required] string Name,
         string? Description
    );

    [HttpPost]
    public async Task<IActionResult> Create([Required] CreateWorkspaceRequest request)
    {
        var result = await sender.Send(new CreateWorkspaceCommand(request.Name, request.Description));

        return result.IsFailure switch
        {
            true => Conflict(result),
            _ => Created()
        };
    }

    [HttpGet("{workspaceId}/tasks")]
    public async Task<IActionResult> GetTasks([Required] string workspaceId)
    {
        var result = await sender.Send(new GetWorkspaceTasksQuery(workspaceId));
        
        if (result.IsFailure) return Conflict(result);
        
        if (result.IsSuccess && !result.Value.Any()) return NoContent();
        
        return Ok(result);
    }

    [HttpPost("{workspaceId}/tasks")]
    public async Task<IActionResult> AddTask([Required] string workspaceId)
    {
        var result = await sender.Send(new AddTaskCommand(workspaceId));
        
        if (result.IsFailure) return Conflict(result);

        return Ok(result);
    }
}