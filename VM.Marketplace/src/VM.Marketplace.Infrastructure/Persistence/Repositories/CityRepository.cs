namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    private const string collectionName = "cities";
    public CityRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}
