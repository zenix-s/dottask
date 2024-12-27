using System.Data;
using Domain.Repository;
using Infrastructure.Repositories;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IDbConnection>(_ => new SqliteConnection("Data Source=dottask.sqlite"));

        services.AddScoped<IWorkspaceRepository, WorkspaceRepository>();
        services.AddScoped<ITasksRepository, TasksRepository>();
        
        return services;
    }
}