using VM.Marketplace.Domain.Filters;

namespace VM.Marketplace.Application.Interfaces;

public interface IProductAppService
{
    Task AddProductAsync(CreateProductRequest productRequest);
    Task<string> UpdateProductAsync(CreateProductRequest productRequest);
    Task RemoveProductAsync(Guid id);
    Task<ProductDto> GetProductByIdAsync(Guid id);
    Task<IEnumerable<ProductDto>> GetProductsByUserIdAsync(Guid userId);
    Task<PagedResult<ProductDto>> GetAllProductsAsync(ProductFilter filter);
}