namespace VM.Marketplace.Domain.Dtos;

public class ProductDto
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }
    public string CategoryName { get; set; }
    public string UserFullName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string TechnicalSpecifications { get; set; }
    public string MainPhoto { get; set; }
    public decimal Price { get; set; }
    public decimal PromotionalPrice { get; set; }
    public bool IsDeleted { get; set; }
    public bool IsActive { get; set; }
    public bool IsMedicine { get; set; }
    public DateTime? ExpiryDate { get; set; }

}
