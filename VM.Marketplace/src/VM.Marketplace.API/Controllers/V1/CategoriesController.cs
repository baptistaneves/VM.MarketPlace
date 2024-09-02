namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class CategoriesController : BaseController
{
    private readonly ICategoryAppService _categoryAppService;
    public CategoriesController(INotifier notifier, 
                                ICategoryAppService categoryAppService) : base(notifier)
    {
        _categoryAppService = categoryAppService;
    }

    [AllowAnonymous]
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
    public async Task<ActionResult> Add([ModelBinder(BinderType = typeof(CreateCategoryModelBinder))] CreateCategoryRequest categoryRequest)
    {
        var imagePrefix = Guid.NewGuid() + "_";

        if (!await UploadFile(categoryRequest.ImageFile, imagePrefix))
        {
            return Response();
        }

        categoryRequest.ImageUrl = imagePrefix + categoryRequest.ImageFile.FileName;

        await _categoryAppService.AddCategoryAsync(categoryRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Category.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([ModelBinder(BinderType = typeof(UpdateCategoryModelBinder))] UpdateCategoryRequest categoryRequest)
    {
        if (categoryRequest.ImageFile != null)
        {
            var imagePrefix = Guid.NewGuid() + "_";

            if (!await UploadFile(categoryRequest.ImageFile, imagePrefix))
            {
                return Response();
            }

            categoryRequest.ImageUrl = imagePrefix + categoryRequest.ImageFile.FileName;
        }

        var oldImageUrl = await _categoryAppService.UpdateCategoryAsync(categoryRequest);

        if (OperationIsValid() && categoryRequest.ImageFile != null)
            DeleteFile(oldImageUrl);

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

    private async Task<bool> UploadFile(IFormFile file, string imgPrefix)
    {
        if (file == null || file.Length == 0)
        {
            Notify("Forneça a imagem desta categoria!");
            return false;
        }

        const long maxFileSize = 600 * 1024;
        if (file.Length > maxFileSize)
        {
            Notify("O tamanho da imagem não pode exceder 600 KB!");
            return false;
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Categories", imgPrefix + file.FileName);

        if (System.IO.File.Exists(path))
        {
            Notify("Já existe uma imagem com este nome!");
            return false;
        }

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return true;
    }

    private bool DeleteFile(string fileName)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Categories", fileName);

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);

            return true;
        }

        return false;
    }
}