using Microsoft.AspNetCore.Authorization;

namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class SubcategoriesController : BaseController
{
    private readonly ISubcategoryAppService _subcategoryAppService;
    public SubcategoriesController(INotifier notifier, 
                                   ISubcategoryAppService subcategoryAppService) : base(notifier)
    {
        _subcategoryAppService = subcategoryAppService;
    }

    [HttpGet(ApiRoutes.Subcategory.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _subcategoryAppService.GetAllSubcategoriesAsync());
    }

    [HttpGet(ApiRoutes.Subcategory.GetSubcategoriesByCategoryId)]
    public async Task<ActionResult> GetSubcategoriesByCategoryId(Guid categoryId)
    {
        return Response(await _subcategoryAppService.GetSubcategoriesByCategoryId(categoryId));
    }

    [HttpGet(ApiRoutes.Subcategory.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        return Response(await _subcategoryAppService.GetSubcategoryByIdAsync(id));
    }

    [HttpPost(ApiRoutes.Subcategory.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateSubcategoryRequest subcategoryRequest)
    {
        await _subcategoryAppService.AddSubcategoryAsync(subcategoryRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Subcategory.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateSubcategoryRequest subcategoryRequest)
    {
        await _subcategoryAppService.UpdateSubcategoryAsync(subcategoryRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.Subcategory.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _subcategoryAppService.RemoveSubcategoryAsync(id);

        return Response();
    }
}
