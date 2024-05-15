
using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class SubcategoryRepository : GenericRepository<Subcategory>, ISubcategoryRepository
{
    private const string collectionName = "Subcategories";
    public SubcategoryRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }

    public async Task<IEnumerable<SubcategoryDto>> GetSubcategoriesByCategoryId(Guid categoryId)
    {
        var result = (from subcategory in _collection.AsQueryable()
                      join category in _collection.Database.GetCollection<Category>("categories").AsQueryable() on subcategory.CategoryId equals category.Id into subcategoryCategoryJoin
                      from category in subcategoryCategoryJoin.DefaultIfEmpty()
                      where subcategory.CategoryId == categoryId
                      select new SubcategoryDto
                      {
                          Id = subcategory.Id,
                          Description = subcategory.Description,
                          CategoryId = category.Id,
                          CategoryDescription = category.Description
                      }).ToList();

        return result;
    }
}
