namespace VM.Marketplace.Domain.Entities;

public class Subcategory : Entity
{
    public string Description { get; private set; }
    public Guid CategoryId { get; private set; }

    //EF Rel.
    public Category Category { get; private set; }
    public IEnumerable<Product> Products { get; private set; }
}
