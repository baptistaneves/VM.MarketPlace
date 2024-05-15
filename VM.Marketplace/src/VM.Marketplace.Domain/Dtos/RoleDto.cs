namespace VM.Marketplace.Domain.Dtos;

public class RoleDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public IEnumerable<ClaimDto> Claims { get; set; }
}