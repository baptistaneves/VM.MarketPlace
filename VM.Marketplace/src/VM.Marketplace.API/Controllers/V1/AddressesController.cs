namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class AddressesController : BaseController
{
    private readonly IAddressAppService _addressAppService;
    public AddressesController(INotifier notifier, 
                               IAddressAppService addressAppService) : base(notifier)
    {
        _addressAppService = addressAppService;
    }

    [HttpGet(ApiRoutes.Address.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _addressAppService.GetAllAddrresesAsync());
    }

    [HttpGet(ApiRoutes.Address.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var address = await _addressAppService.GetAddressByIdAsync(id);

        if (address == null) return NotFound();

        return Response();
    }

    [HttpPost(ApiRoutes.Address.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateAddressRequest addressRequest)
    {
        await _addressAppService.AddAdressAsync(addressRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Address.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateAddressRequest addressRequest)
    {
        await _addressAppService.UpdateAddressAsync(addressRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.Address.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _addressAppService.RemoveAddressAsync(id);

        return Response();
    }
}
