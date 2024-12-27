using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers;

[ApiController]
public class TasksController(ISender _sender) : ControllerBase
{   
    
}