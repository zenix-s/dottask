namespace Infrastructure.Models;

public class WorkspaceDB
{
    public string id { get; set; }
    public string name { get; set; } = string.Empty;
    public string? description { get; set; }
    public string creation_date { get; set; } = string.Empty;
    public int archived { get; set; } = 0;
}