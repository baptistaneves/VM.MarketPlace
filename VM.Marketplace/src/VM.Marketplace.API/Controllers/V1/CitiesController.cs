namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class CitiesController : BaseController
{
    private readonly ICityAppService _cityAppService;
    public CitiesController(INotifier notifier, 
                            ICityAppService cityAppService) : base(notifier)
    {
        _cityAppService = cityAppService;
    }

    [HttpGet(ApiRoutes.City.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _cityAppService.GetAllCitiesAsync());
    }

    [HttpGet(ApiRoutes.City.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var city = await _cityAppService.GetCityByIdAsync(id);

        if (city == null) return NotFound();

        return Response();
    }

    [HttpPost(ApiRoutes.City.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateCityRequest cityRequest)
    {
        await _cityAppService.AddCityAsync(cityRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.City.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateCityRequest cityRequest)
    {
        await _cityAppService.UpdateCityAsync(cityRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.City.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _cityAppService.RemoveCityAsync(id);

        return Response();
    }
}
