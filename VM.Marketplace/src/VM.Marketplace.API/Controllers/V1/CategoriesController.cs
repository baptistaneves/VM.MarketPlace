namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class CategoriesController : BaseController
{
    private readonly ICategoryAppService _categoryAppService;
    public CategoriesController(INotifier notifier, 
                                ICategoryAppService categoryAppService) : base(notifier)
    {
        _categoryAppService = categoryAppService;
    }

    [HttpGet(ApiRoutes.Category.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _categoryAppService.GetAllCategoriesAsync());
    }

    [HttpGet(ApiRoutes.Category.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var category = await _categoryAppService.GetCategoryByIdAsync(id);

        if (category is null) return NotFound();

        return Response(category);
    }

    [HttpPost(ApiRoutes.Category.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateCategoryRequest categoryRequest)
    {
        await _categoryAppService.AddCategoryAsync(categoryRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Category.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateCategoryRequest categoryRequest)
    {
        await _categoryAppService.UpdateCategoryAsync(categoryRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.Category.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _categoryAppService.RemoveCategoryAsync(id);

        return Response();
    }
}
