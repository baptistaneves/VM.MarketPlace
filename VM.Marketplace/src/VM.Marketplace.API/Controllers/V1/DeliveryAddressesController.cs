namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class DeliveryAddressesController : BaseController
{
    private readonly IDeliveryAddressAppService _deliveryAddressAppService;
    public DeliveryAddressesController(INotifier notifier, 
                                       IDeliveryAddressAppService deliveryAddressAppService) : base(notifier)
    {
        _deliveryAddressAppService = deliveryAddressAppService;
    }


    [HttpGet(ApiRoutes.DeliveryAddress.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _deliveryAddressAppService.GetAllDeliveryAddrresesAsync());
    }

    [HttpGet(ApiRoutes.DeliveryAddress.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var address = await _deliveryAddressAppService.GetDeliveryAddressByIdAsync(id);

        if (address == null) return NotFound();

        return Response();
    }

    [HttpPost(ApiRoutes.DeliveryAddress.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateDeliveryAddressRequest addressRequest)
    {
        await _deliveryAddressAppService.AddDeliveryAdressAsync(addressRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.DeliveryAddress.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateDeliveryAddressRequest addressRequest)
    {
        await _deliveryAddressAppService.UpdateDeliveryAddressAsync(addressRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.DeliveryAddress.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _deliveryAddressAppService.RemoveDeliveryAddressAsync(id);

        return Response();
    }
}