namespace VM.Marketplace.Application.Interfaces;

public interface IAddressAppService
{
    Task AddAdressAsync(CreateAddressRequest addressRequest);
    Task UpdateAddressAsync(UpdateAddressRequest addressRequest);
    Task RemoveAddressAsync(Guid id);
    Task<Address> GetAddressByIdAsync(Guid id);
    Task<IEnumerable<Address>> GetAllAddrresesAsync();
}