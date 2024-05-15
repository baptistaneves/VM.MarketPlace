namespace VM.Marketplace.Domain.Entities;

public class RoleClaim
{
    public string Type { get; private set; }
    public string Value { get; private set; }

    public RoleClaim(string claimType, string claimValue)
    {
        Type = claimType;
        Value = claimValue;
    }
}
