namespace VM.Marketplace.Domain.Entities;

public class Role : Entity
{
    public string Name { get; private set; }
    public List<RoleClaim> Claims { get; private set; } = new List<RoleClaim>();

    public Role(string name)
    {
        Name = name;
    }

    //MongoDb Rel.
    public Role() { }

    public static Role UpdateRole(Guid id, string name)
    {
        return new Role 
        { 
            Id = id,
            Name = name 
        };
    }

    public void AddClaim(RoleClaim claim)
    {
        Claims.Add(claim);
    }
}