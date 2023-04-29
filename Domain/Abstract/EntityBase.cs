namespace Persistence.Abstract;

public class EntityBase
{
    public Guid Id { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedDate { get; set; } = DateTime.Now;

    public EntityBase()
    {
    }

    public EntityBase(Guid id) : this()
    {
        Id = id;
    }
}