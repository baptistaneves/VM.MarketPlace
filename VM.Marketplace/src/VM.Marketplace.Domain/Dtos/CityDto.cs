namespace VM.Marketplace.Domain.Dtos;

public class CityDto
{
    public Guid Id { get; set; }
    public Guid StateId { get; set; }
    public string Name { get; set; }
    public string StateName { get; set; }
}