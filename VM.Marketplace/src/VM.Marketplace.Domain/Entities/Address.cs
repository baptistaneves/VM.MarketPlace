namespace VM.Marketplace.Domain.Entities;

public class Address : Entity
{
    public Guid CityId { get; private set; }
    public string Description { get; private set; }
    public string Street { get; private set; }

    public Address(Guid cityId, string description, string street)
    {
        CityId = cityId;
        Description = description;
        Street = street;
    }

    //MongoDb Rel
    public Address() {}

    public void Update(Guid cityId, string description, string street)
    {
        CityId = cityId;
        Description = description;
        Street = street;
    }
}
