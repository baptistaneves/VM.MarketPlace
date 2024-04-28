namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class StatesController : BaseController
{
    private readonly IStateAppService _stateAppService;
    public StatesController(INotifier notifier, 
                            IStateAppService stateAppService) : base(notifier)
    {
        _stateAppService = stateAppService;
    }

    [HttpGet(ApiRoutes.State.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _stateAppService.GetAllStatesAsync());
    }

    [HttpGet(ApiRoutes.State.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var state = await _stateAppService.GetStateByIdAsync(id);

        if(state == null) return NotFound();

        return Response();
    }

    [HttpPost(ApiRoutes.State.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateStateRequest stateRequest)
    {
        await _stateAppService.AddStateAsync(stateRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.State.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateStateRequest stateRequest)
    {
        await _stateAppService.UpdateStateAsync(stateRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.State.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _stateAppService.RemoveStateAsync(id);

        return Response();
    }
}
