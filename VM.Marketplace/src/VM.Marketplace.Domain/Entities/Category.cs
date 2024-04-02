namespace VM.Marketplace.Domain.Entities;

public class Category : Entity
{
    public string Description { get; private set; }
    public Guid GroupId { get; private set; }

    //EF Rel.
    public Group Group { get; private set; }
    public IEnumerable<Subcategory> Subcategories { get; private set; }
}
