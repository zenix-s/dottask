using Domain.Entities;
using Task = Domain.Entities.Task;

namespace Domain.Repository;

public interface ITasksRepository
{
    Task<IEnumerable<Task>> GetWorkspaceTasksAsync(Workspace workspace);
    Task<int> AddWorkspaceTaskAsync(Workspace workspace, Task task);
}