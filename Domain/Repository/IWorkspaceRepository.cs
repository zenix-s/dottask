using System.Collections;
using Domain.Entities;
using Task = Domain.Entities.Task;

namespace Domain.Repository;

public interface IWorkspaceRepository
{
    /// <summary>
    /// Returns all the workspaces
    /// </summary>
    /// <returns>List of <see cref="Workspace"/></returns>
    Task<IEnumerable<Workspace>> GetAllAsync();
    
    /// <summary>
    /// Return workspace based on id
    /// </summary>
    /// <param name="id">id</param>
    /// <returns><see cref="Workspace"/></returns>
    Task<Workspace?> GetByIdAsync(Guid id);
    
    Task<int> AddAsync(Workspace workspace);
}