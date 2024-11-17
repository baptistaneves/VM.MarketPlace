using VM.Marketplace.Domain.Filters;

namespace VM.Marketplace.Application.Services;

public class ProductAppService : BaseAppService, IProductAppService
{
    private readonly IProductRepository _productRepository;
    public ProductAppService(INotifier notifier, IProductRepository productRepository) : base(notifier)
    {
        _productRepository = productRepository;
    }

    public async Task AddProductAsync(CreateProductRequest productRequest)
    {
        if (!Validate(new CreateProductValidation(), productRequest)) return;

        var product = new Product(productRequest.CategoryId, productRequest.UserId, productRequest.Name,
            productRequest.Description, productRequest.MainPhoto, productRequest.Price, productRequest.PromotionalPrice,
            productRequest.IsMedicine, productRequest.ExpiryDate, productRequest.TechnicalSpecifications);

        await _productRepository.InsertOnceAsync(product);
    }

    public async Task<string> UpdateProductAsync(CreateProductRequest productRequest)
    {
        if (!Validate(new UpdateProductValidation(), productRequest)) return null;

        var product = await _productRepository.GetByIdAsync(productRequest.Id);

        var mainPhotoUrl = product.MainPhoto;

        if(product is null)
        {
            Notify(ProductErrorMessage.ProductNotFound);
            return null;
        }

        product.UpdateProduct(productRequest.CategoryId, productRequest.Name,
            productRequest.Description, productRequest.MainPhoto, productRequest.Price, productRequest.PromotionalPrice,
            productRequest.IsMedicine, productRequest.ExpiryDate, productRequest.TechnicalSpecifications);

        await _productRepository.ReplaceOnceAsync(product);

        return mainPhotoUrl;
    }

    public async Task RemoveProductAsync(Guid id)
    {
        await _productRepository.DeleteOnceAsync(id);
    }

    public async Task<PagedResult<ProductDto>> GetAllProductsAsync(ProductFilter filter)
    {
        return await _productRepository.GetAllProducts(filter);
    }

    public async Task<ProductDto> GetProductByIdAsync(Guid id)
    {
        return await _productRepository.GetProductById(id);
    }

    public async Task<PagedResult<ProductDto>> GetProductsByUserAsync(ProductFilter filter)
    {
        return await _productRepository.GetProductsByUser(filter);
    }
}