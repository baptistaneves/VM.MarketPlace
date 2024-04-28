namespace VM.Marketplace.Domain.Entities;

public class Product : Entity
{
    public Guid SubcategoryId { get; private set; }
    public Guid UnitId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string TechnicalSpecifications { get; private set; }
    public string MainPhoto { get; private set; }
    public decimal Price { get; private set; }
    public double PromotionalPrice { get; private set; }
    public decimal StockQuantity { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsMedidine { get; set; }
    public string BatchNumber { get; set; }
    public DateTime ExpiryDate { get; set; }
}
