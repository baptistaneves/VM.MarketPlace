namespace VM.Marketplace.Domain.Dtos;

public class CategoryDto
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string GroupDescription { get; set; }
    public Guid GroupId { get; set; }
}