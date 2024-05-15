using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Domain.Repositories;

public interface ISubcategoryRepository : IGenericRepository<Subcategory>
{
    Task<IEnumerable<SubcategoryDto>> GetSubcategoriesByCategoryId(Guid categoryId);
}
