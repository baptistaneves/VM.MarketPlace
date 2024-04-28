namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class DeliveryAddressRepository : GenericRepository<DeliveryAddress>, IDeliveryAddressRepository
{
    private const string collectionName = "deliveryAddresses";
    public DeliveryAddressRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }
}
