namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class SubcategoryRepository : GenericRepository<Subcategory>, ISubcategoryRepository
{
    private const string collectionName = "Subcategories";
    public SubcategoryRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}
