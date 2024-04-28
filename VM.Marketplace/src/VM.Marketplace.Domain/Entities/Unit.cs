namespace VM.Marketplace.Domain.Entities;

public class Unit : Entity
{
    public string Description { get; private set; }
    public Unit(string description)
    {
        Description = description;
    }

    //MongoDb Rel
    public Unit() { }

    public void Update(string description)
    {
        Description = description;
    }

}