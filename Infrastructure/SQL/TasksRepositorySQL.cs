namespace Infrastructure.SQL;

internal static class TasksRepositorySql
{
    public const string GetTasksFromWorkspace =
        """
             SELECT
                 *
             FROM
                 tasks
             WHERE
                 tasks.workspace_id = :workspace_id
        """;

    public const string AddTask =
        """
            insert into tasks(id, name, description, creation_date, start_date, end_date, is_completed, workspace_id, priority) 
            values (:id, :name, :description, :creation_date, :start_date, :end_date, :is_completed, :workspace_id, :priority) 
        """;
}