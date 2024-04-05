using MongoDB.Driver;
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Repositories;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class GroupRepository : GenericRepository<Group>, IGroupRepository
{
    private const string collectionName = "group";
    public GroupRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}
