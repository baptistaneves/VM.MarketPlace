namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private const string collectionName = "categories";
    public CategoryRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }

}
