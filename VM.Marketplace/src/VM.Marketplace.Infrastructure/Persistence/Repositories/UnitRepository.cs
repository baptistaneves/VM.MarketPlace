namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class UnitRepository : GenericRepository<Unit>, IUnitRepository
{
    private const string collectionName = "units";
    public UnitRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}