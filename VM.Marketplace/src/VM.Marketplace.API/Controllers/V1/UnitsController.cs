using Microsoft.AspNetCore.Authorization;

namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class UnitsController : BaseController
{
    private readonly IUnitAppService _unitAppService;
    public UnitsController(INotifier notifier, 
                           IUnitAppService unitAppService) : base(notifier)
    {
        _unitAppService = unitAppService;
    }

    [HttpGet(ApiRoutes.Unit.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _unitAppService.GetAllUnitsAsync());
    }

    [HttpGet(ApiRoutes.Unit.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var unit = await _unitAppService.GetUnitByIdAsync(id);

        if (unit == null) return NotFound();

        return Response(unit);
    }

    [HttpPost(ApiRoutes.Unit.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateUnitRequest unitRequest)
    {
        await _unitAppService.AddUnitAsync(unitRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Unit.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateUnitRequest unitRequest)
    {
        await _unitAppService.UpdateUnitAsync(unitRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.Unit.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _unitAppService.RemoveUnitAsync(id);

        return Response();
    }
}