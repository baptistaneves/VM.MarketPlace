using VM.Marketplace.Domain.Repositories;

namespace VM.Marketplace.Application.Services;

public class DeliveryAddressAppService : BaseAppService, IDeliveryAddressAppService
{
    private readonly IDeliveryAddressRepository _deliveryAddressRepository;
    public DeliveryAddressAppService(INotifier notifier, 
                                     IDeliveryAddressRepository deliveryAddressRepository) : base(notifier)
    {
        _deliveryAddressRepository = deliveryAddressRepository;
    }

    public async Task AddDeliveryAdressAsync(CreateDeliveryAddressRequest addressRequest)
    {
        if (!Validate(new CreateDeliveryAddressValidation(), addressRequest)) return;

        await _deliveryAddressRepository
            .InsertOnceAsync(new DeliveryAddress(addressRequest.CityId, addressRequest.Description, addressRequest.Street));
    }

    public async Task<IEnumerable<DeliveryAddress>> GetAllDeliveryAddrresesAsync()
    {
        return await _deliveryAddressRepository.GetAllAsync();
    }

    public async Task<DeliveryAddress> GetDeliveryAddressByIdAsync(Guid id)
    {
        return await _deliveryAddressRepository.GetByIdAsync(id);
    }

    public async Task RemoveDeliveryAddressAsync(Guid id)
    {
        if (!_deliveryAddressRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(DeliveryAddressErrorMessage.DeliveryAddressNotFound);
            return;
        }

        await _deliveryAddressRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateDeliveryAddressAsync(UpdateDeliveryAddressRequest addressRequest)
    {
        var deliveryAddress = await _deliveryAddressRepository.GetByIdAsync(addressRequest.Id);

        if (deliveryAddress is null)
        {
            Notify(DeliveryAddressErrorMessage.DeliveryAddressNotFound);
            return;
        }

        if (!Validate(new UpdateDeliveryAddressValidation(), addressRequest)) return;

        deliveryAddress.Update(addressRequest.CityId, addressRequest.Description, addressRequest.Street);

        await _deliveryAddressRepository.ReplaceOnceAsync(deliveryAddress);
    }
}