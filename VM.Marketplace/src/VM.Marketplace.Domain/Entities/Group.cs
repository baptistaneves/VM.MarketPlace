namespace VM.Marketplace.Domain.Entities;

public class Group : Entity
{
    public string Description { get; private set; }
    public bool IsActive { get; private set; }

    //EF Rel.
    public IEnumerable<Category> Categories { get; private set; }
}
