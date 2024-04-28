namespace VM.Marketplace.Domain.Entities;

public class Category : Entity
{
    public string Description { get; private set; }
    public Guid GroupId { get; private set; }

    public Category(string description, Guid groupId)
    {
        Description = description;
        GroupId = groupId;
    }

    //For MongoDb Rel.
    public Category() { }

    public void Update(string description, Guid groupId)
    {
        Description = description;
        GroupId = groupId;  
    }
}
