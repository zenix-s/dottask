namespace Infrastructure.SQL;

internal static class WorkspaceRepositorySql
{
    public const string GetAllWorkspaces = 
        """
            SELECT
                *
            FROM
                workspaces
        """;

    public const string GetWorkspaceById =
        """
            SELECT
                *
            FROM
                workspaces
            WHERE 
                workspaces.id = :workspace_id
        """;

    public const string Add =
        """
            insert into workspaces(id, name, description, creation_date, archived)
            values (:id, :name, :description, :creation_date, :archived);
        """;
}