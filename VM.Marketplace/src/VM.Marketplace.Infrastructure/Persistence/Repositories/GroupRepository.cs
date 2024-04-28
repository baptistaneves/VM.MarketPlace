namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    private const string collectionName = "groups";
    public GroupRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}