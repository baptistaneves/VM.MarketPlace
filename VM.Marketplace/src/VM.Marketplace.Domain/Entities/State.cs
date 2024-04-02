namespace VM.Marketplace.Domain.Entities;

public class State : Entity
{
    public string Name { get; private set; }

    //EF Rel.
    public IEnumerable<City> Cities { get; private set; }
}