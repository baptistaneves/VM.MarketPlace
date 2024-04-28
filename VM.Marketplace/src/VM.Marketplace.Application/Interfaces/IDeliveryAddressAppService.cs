namespace VM.Marketplace.Application.Interfaces;

public interface IDeliveryAddressAppService
{
    Task AddDeliveryAdressAsync(CreateDeliveryAddressRequest addressRequest);
    Task UpdateDeliveryAddressAsync(UpdateDeliveryAddressRequest addressRequest);
    Task RemoveDeliveryAddressAsync(Guid id);
    Task<DeliveryAddress> GetDeliveryAddressByIdAsync(Guid id);
    Task<IEnumerable<DeliveryAddress>> GetAllDeliveryAddrresesAsync();
}
