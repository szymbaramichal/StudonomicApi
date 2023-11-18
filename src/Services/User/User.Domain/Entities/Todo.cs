using User.Domain.Common;

namespace User.Domain.Entities;

public class Todo : EntityBase
{
    public string Title { get; set; } = string.Empty;
    public DateTime DoDateUtc { get; set; } 
    public bool IsDone { get; set; }
}