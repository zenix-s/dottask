using System.Data;
using Dapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Infrastructure.SQL;
using Task = Domain.Entities.Task;

namespace Infrastructure.Repositories;

public class TasksRepository(IDbConnection connection) : ITasksRepository
{
    public async Task<IEnumerable<Task>> GetWorkspaceTasksAsync(Workspace workspace)
    {
        DynamicParameters parameters = new();
        parameters.Add("workspace_id", workspace.Id.ToString());

        const string sql = TasksRepositorySql.GetTasksFromWorkspace;
        var queryResult = await connection.QueryAsync<dynamic>(sql, parameters);

        var result = queryResult.Select(row =>
            new Task(
                Guid.Parse(row.id), 
                row.name, 
                DateOnly.Parse(row.creation_date), 
                Priority.FromName(row.name),
                row.is_completed != 0, 
                row.description, 
                row.start_date != null ? DateOnly.Parse(row.start_date) : null, 
                row.end_date != null ? DateOnly.Parse(row.end_date) : null
            )
        );

        return result;
    }

    public async Task<int> AddWorkspaceTaskAsync(Workspace workspace, Task task)
    {
        const string sql = TasksRepositorySql.AddTask;
        DynamicParameters parameters = new();
        
        parameters.Add("workspace_id", workspace.Id.ToString());
        parameters.Add("id", task.Id.ToString());
        parameters.Add("name", task.Name);
        parameters.Add("description", task.Description);
        parameters.Add("creation_date", task.CreatedAt.ToString("yyyy-MM-dd"));
        if (task.StartDate != null)
        {
            var date = task.StartDate.Value;
            parameters.Add("start_date", date.ToString("yyyy-MM-dd"));
        }
        else
        {
            parameters.Add("start_date");
        }

        if (task.EndDate != null)
        {
            var date = task.EndDate.Value;
            parameters.Add("end_date", date.ToString("yyyy-MM-dd"));
        }
        else
        {
            parameters.Add("end_date");
        }
        parameters.Add("priority", task.Priority?.Name);
        parameters.Add("is_completed", task.IsCompleted);
        
        return await connection.ExecuteAsync(sql, parameters);
    }
}