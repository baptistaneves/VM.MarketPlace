using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Domain.Repositories;

public interface ICategoryRepository : IGenericRepository<Category>
{
    Task<IEnumerable<CategoryDto>> GetAllCategories();
}
