namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class ProductsController : BaseController
{
    private readonly IProductAppService _productAppService;
    public ProductsController(INotifier notifier, IProductAppService productAppService) : base(notifier)
    {
        _productAppService = productAppService;
    }

    [AllowAnonymous]
    [HttpGet(ApiRoutes.Product.GetAll)]
    public async Task<ActionResult> GetAll([FromQuery] ProductFilter filter)
    {
        return Response(await _productAppService.GetAllProductsAsync(filter));
    }

    [HttpGet(ApiRoutes.Product.GetProdutsByUserId)]
    public async Task<ActionResult> GetProdutsByUser([FromQuery] ProductFilter filter)
    {
        filter.UserId = HttpContext.GetIdentityUserId();

        return Response(await _productAppService.GetProductsByUserAsync(filter));
    }

    [AllowAnonymous]
    [HttpGet(ApiRoutes.Product.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var product = await _productAppService.GetProductByIdAsync(id);

        if (product == null) return NotFound();

        return Response(product);
    }

    [HttpPost(ApiRoutes.Product.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([ModelBinder(BinderType = typeof(DocumentModelBinder))] CreateProductRequest product)
    {
        product.UserId = HttpContext.GetIdentityUserId();

        var imagePrefix = Guid.NewGuid() + "_";

        if (!await UploadFile(product.ImageFile, imagePrefix))
        {
            return Response();
        }

        product.MainPhoto = imagePrefix + product.ImageFile.FileName;

        await _productAppService.AddProductAsync(product);

        return Response();
    }

    [HttpPut(ApiRoutes.Product.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([ModelBinder(BinderType = typeof(DocumentModelBinder))] CreateProductRequest productRequest)
    {
        if(productRequest.ImageFile != null)
        {
            var imagePrefix = Guid.NewGuid() + "_";

            if (!await UploadFile(productRequest.ImageFile, imagePrefix))
            {
                return Response();
            }

            productRequest.MainPhoto = imagePrefix + productRequest.ImageFile.FileName;
        }

        var mainPhotoUrl = await _productAppService.UpdateProductAsync(productRequest);

        if(OperationIsValid() && productRequest.ImageFile != null) 
            DeleteFile(mainPhotoUrl);

        return Response();
    }

    [HttpDelete(ApiRoutes.Product.Remove)]
    [ValidateGuid("id")]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _productAppService.RemoveProductAsync(id);

        return Response();
    }

    private async Task<bool> UploadFile(IFormFile file, string imgPrefix)
    {
        if (file == null || file.Length == 0)
        {
            Notify("Forneça a imagem deste produto!");
            return false;
        }

        const long maxFileSize = 600 * 1024;
        if (file.Length > maxFileSize)
        {
            Notify("O tamanho da imagem não pode exceder 600 KB!");
            return false;
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Products", imgPrefix + file.FileName);

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
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Products", fileName);

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);

            return true;
        }

        return false;
    }
}
