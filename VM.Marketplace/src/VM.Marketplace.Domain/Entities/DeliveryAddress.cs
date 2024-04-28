﻿namespace VM.Marketplace.Domain.Entities;

public class DeliveryAddress : Entity
{
    public Guid CityId { get; private set; }
    public string Description { get; private set; }
    public string Street { get; private set; }

    public DeliveryAddress(Guid cityId, string description, string street)
    {
        CityId = cityId;
        Description = description;
        Street = street;
    }

    //MongoDb Rel.
    public DeliveryAddress() { }

    public void Update(Guid cityId, string description, string street)
    {
        CityId = CityId;
        Description = description;
        Street = street;
    }
}
