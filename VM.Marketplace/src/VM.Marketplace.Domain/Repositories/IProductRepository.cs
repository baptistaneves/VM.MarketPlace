using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Filters;

namespace VM.Marketplace.Domain.Repositories;

public interface IProductRepository : IGenericRepository<Product>
{
    Task<PagedResult<ProductDto>> GetProductsByUser(ProductFilter filter);
    Task<ProductDto> GetProductById(Guid id);
    Task<PagedResult<ProductDto>> GetAllProducts(ProductFilter filter);
}