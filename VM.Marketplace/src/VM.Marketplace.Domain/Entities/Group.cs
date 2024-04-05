namespace VM.Marketplace.Domain.Entities;

public class Group : Entity
{
    public string Description { get; private set; }
    public bool IsActive { get; private set; }

    public Group(string description, bool isActive)
    {
        Description = description;
        IsActive = isActive;
    }
}
