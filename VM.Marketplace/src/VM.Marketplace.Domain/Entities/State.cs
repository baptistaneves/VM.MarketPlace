namespace VM.Marketplace.Domain.Entities;

public class State : Entity
{
    public string Name { get; private set; }

    public State(string name)
    {
        Name = name;
    }

    //MongoDb Rel.
    public State(){}

    public void Update(string name)
    {
        Name = name;
    }
}