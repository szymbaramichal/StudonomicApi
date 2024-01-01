namespace User.Domain.Common;

public abstract class EntityBase
{
    public int Id { get; protected set; }
    public string CreatedBy { get; set; } = string.Empty;
    public DateTime CreatedDateUtc { get; set; }
    public string ModifiedBy { get; set; } = string.Empty;
    public DateTime? ModifiedDateUtc { get; set; }

}