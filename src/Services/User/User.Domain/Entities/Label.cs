using User.Domain.Common;

namespace User.Domain.Entities;

public class Label : EntityBase
{
    public int RedColor { get; set; }
    public int GreenColor { get; set; }
    public int BlueColor { get; set; }
    public string Name { get; set; }
    public List<Todo> Todos { get; set; }
}