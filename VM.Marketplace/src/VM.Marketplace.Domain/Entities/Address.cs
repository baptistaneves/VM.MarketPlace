namespace VM.Marketplace.Domain.Entities;

public class Address : Entity
{
    public Guid CityId { get; private set; }
    public string Description { get; private set; }
    public string Street { get; private set; }

    //EF Rel.
    public City City { get; set; }
}
