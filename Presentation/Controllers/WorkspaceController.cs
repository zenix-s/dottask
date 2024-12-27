using System.ComponentModel.DataAnnotations;
using Application.Tasks.query.GetBoardTasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
[Route("workspace/tasks")]
public class WorkspaceController(ILogger<WorkspaceController> logger, ISender sender) : ControllerBase
{
    private readonly ILogger<WorkspaceController> _logger = logger;

    [HttpGet("{workspaceId}")]
    public async Task<IActionResult> Get([Required] string workspaceId)
    {
        var result = await sender.Send(new GetBoardTasksQuery(workspaceId));

        return Ok(result);
    }
}