namespace User.Application.Models.Todos;

public class TodoViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateTime DoDateUtc { get; set; } 
    public bool IsDone { get; set; }
}