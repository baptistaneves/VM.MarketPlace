namespace VM.Marketplace.Application.Services;

public class AddressAppService : BaseAppService, IAddressAppService
{
    private readonly IAddressRepository _addressRepository;
    public AddressAppService(INotifier notifier, 
                             IAddressRepository addressRepository) : base(notifier)
    {
        _addressRepository = addressRepository;
    }

    public async Task AddAdressAsync(CreateAddressRequest addressRequest)
    {
        if (!Validate(new CreateAddressValidation(), addressRequest)) return;

        await _addressRepository.InsertOnceAsync(new Address(addressRequest.CityId, addressRequest.Description, addressRequest.Street));
    }

    public async Task<Address> GetAddressByIdAsync(Guid id)
    {
        return await _addressRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Address>> GetAllAddrresesAsync()
    {
        return await _addressRepository.GetAllAsync();
    }

    public async Task RemoveAddressAsync(Guid id)
    {
        if (!_addressRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(AddressErrorMessage.AddressNotFound);
            return;
        }

        await _addressRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateAddressAsync(UpdateAddressRequest addressRequest)
    {
        var address = await _addressRepository.GetByIdAsync(addressRequest.Id);

        if (address is null)
        {
            Notify(AddressErrorMessage.AddressNotFound);
            return;
        }

        if (!Validate(new UpdateAddressValidation(), addressRequest)) return;

        address.Update(addressRequest.CityId, addressRequest.Description, addressRequest.Street);

        await _addressRepository.ReplaceOnceAsync(address);
    }
}