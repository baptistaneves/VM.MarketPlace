namespace VM.Marketplace.Domain.Entities;

public class Subcategory : Entity
{
    
    public string Description { get; private set; }
    public Guid CategoryId { get; private set; }
    public Subcategory(string description, Guid categoryId)
    {
        Description = description;
        CategoryId = categoryId;
    }

    //MongoDb Rel.
    public Subcategory() {}

    public void Update(string  description, Guid categoryId)
    {
        Description = description;
        CategoryId = categoryId;
    }
}
