using System.Data;
using Dapper;
using Domain.Entities;
using Domain.Repository;
using Infrastructure.Models;
using Infrastructure.SQL;
using Task = Domain.Entities.Task;

namespace Infrastructure.Repositories;

public class WorkspaceRepository(IDbConnection dbConnection) : IWorkspaceRepository
{
    public async Task<IEnumerable<Workspace>> GetAllAsync()
    {
        const string sql = WorkspaceRepositorySql.GetAllWorkspaces;

        var queryResult = (await dbConnection.QueryAsync<WorkspaceDB>(sql)).ToList();

        if (queryResult.Count == 0) return [];

        return queryResult.Select(row =>
            new Workspace(Guid.Parse(row.id), row.name, row.description, DateOnly.Parse(row.creation_date),
                row.archived != 0));
    }

    public async Task<Workspace?> GetByIdAsync(Guid id)
    {
        const string sql = WorkspaceRepositorySql.GetWorkspaceById;

        DynamicParameters parameters = new();
        parameters.Add("workspace_id", id.ToString());

        WorkspaceDB? queryResult = await dbConnection.QueryFirstOrDefaultAsync<WorkspaceDB>(sql, parameters);

        if (queryResult == null) return null;

        Workspace workspace = new(Guid.Parse(queryResult.id), queryResult.name, queryResult.description,
            DateOnly.Parse(queryResult.creation_date), queryResult.archived != 0);

        return workspace;
    }

    public Task<int> AddAsync(Workspace workspace)
    {
        const string sql = WorkspaceRepositorySql.Add;

        DynamicParameters parameters = new();
        parameters.Add("id", workspace.Id.ToString());
        parameters.Add("name", workspace.Name);
        parameters.Add("description", workspace.Description);
        parameters.Add("creation_date", workspace.CreationDate.ToString("yyyy-MM-dd"));
        parameters.Add("archived", workspace.Archived ? 1 : 0);

        return dbConnection.ExecuteAsync(sql, parameters);
    }
}