namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class StateRepository : GenericRepository<State>, IStateRepository
{
    private const string collectionName = "states";
    public StateRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}