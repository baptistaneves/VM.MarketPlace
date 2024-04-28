namespace VM.Marketplace.Domain.Entities;

public class City : Entity
{
    public string Name { get; private set; }
    public Guid StateId { get; private set; }

    public City(string name, Guid stateId)
    {
        Name = name;
        StateId = stateId;
    }

    //MongoDb Rel.
    public City() {}

    public void Update(string name, Guid stateId)
    {
        Name = name;
        StateId = stateId;
    }
}
