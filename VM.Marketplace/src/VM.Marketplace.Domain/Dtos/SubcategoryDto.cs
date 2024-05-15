namespace VM.Marketplace.Domain.Dtos;

public class SubcategoryDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public string Description { get; set; }
    public string CategoryDescription { get; set; }
}
