namespace VM.Marketplace.Domain.Entities;

public class Product : Entity
{
    public Guid SubcategoryId { get; private set; }
    public Guid UnitId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string TechnicalSpecifications { get; private set; }
    public string MainPhoto { get; private set; }
    public double Price { get; private set; }
    public double PromotionalPrice { get; private set; }
    public int StockQuantity { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }

    //EF Rel.
    public Subcategory Subcategory { get; set; }
    public Unit Unit { get; set; }
    public IEnumerable<ProductPhoto> ProductPhotos { get; private set; }
}
