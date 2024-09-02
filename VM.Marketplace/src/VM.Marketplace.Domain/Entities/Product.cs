namespace VM.Marketplace.Domain.Entities;

public class Product : Entity
{
    public Guid CategoryId { get; private set; }
    public Guid UserId { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public string TechnicalSpecifications { get; private set; }
    public string MainPhoto { get; private set; }
    public decimal Price { get; private set; }
    public decimal PromotionalPrice { get; private set; }
    public decimal StockQuantity { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsActive { get; private set; }
    public bool IsMedicine { get; set; }
    public string BatchNumber { get; set; }
    public DateTime? ExpiryDate { get; set; }

    public Product(Guid categoryId, Guid userId, string name, string description,
        string mainPhoto, decimal price, decimal promotionalPrice, bool isMedicine,DateTime? expiryDate,
        string technicalSpecifications = null)
    {
        CategoryId = categoryId;
        UserId = userId;
        Name = name;
        Description = description;
        MainPhoto = mainPhoto;
        Price = price;
        TechnicalSpecifications = technicalSpecifications;
        PromotionalPrice = promotionalPrice;
        IsMedicine = isMedicine;
        ExpiryDate = expiryDate;
    }

    public void UpdateProduct(Guid categoryId, string name, string description,
        string mainPhoto, decimal price, decimal promotionalPrice, bool isMedicine, DateTime? expiryDate,
        string technicalSpecifications = null)
    {
        CategoryId = categoryId;
        Name = name;
        Description = description;
        MainPhoto = mainPhoto;
        Price = price;
        TechnicalSpecifications = technicalSpecifications;
        PromotionalPrice = promotionalPrice;
        IsMedicine = isMedicine;
        ExpiryDate = expiryDate;
    }

    public Product() { }
}
