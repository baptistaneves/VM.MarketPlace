namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class AddressRepository : GenericRepository<Address>, IAddressRepository
{
    private const string collectionName = "addresses";
    public AddressRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}
