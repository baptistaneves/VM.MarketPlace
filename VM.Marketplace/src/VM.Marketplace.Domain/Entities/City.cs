namespace VM.Marketplace.Domain.Entities;

public class City : Entity
{
    public string Name { get; private set; }
    public Guid StateId { get; private set; }

    //EF Rel.
    public State State { get; set; }

    public IEnumerable<Address> Addresses { get; private set; }
}
