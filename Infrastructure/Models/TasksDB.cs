namespace Infrastructure.Models;

public class TasksDB
{
    public string id { get; set; }
    public string name { get; set; }
    public string? description { get; set; }
    public string priority { get; set; }
    public string creation_date { get; set; }
    public string? start_date { get; set; }
    public string? end_date { get; set; }
    public int is_completed { get; set; }
    public string workspace_id { get; set; }
}