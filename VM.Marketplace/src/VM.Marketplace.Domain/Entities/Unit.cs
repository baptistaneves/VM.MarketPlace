namespace VM.Marketplace.Domain.Entities;

public class Unit : Entity
{
    public string Description { get; private set; }

    //EF Rel.
    public IEnumerable<Product> Products { get; private set; }
}