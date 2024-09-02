namespace VM.Marketplace.Domain.Entities;

public class Category : Entity
{
    public string Description { get; private set; }
    public string ImageUrl { get; private set; }

    public Category(string description, string imageUrl)
    {
        Description = description;
        ImageUrl = imageUrl;
    }

    //For MongoDb Rel.
    public Category() { }

    public void Update(string description, string imageUrl)
    {
        Description = description;
        ImageUrl = imageUrl;  
    }
}
