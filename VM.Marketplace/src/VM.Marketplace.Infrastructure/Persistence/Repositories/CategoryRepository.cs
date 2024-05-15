using MongoDB.Driver;
using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
{
    private const string collectionName = "categories";
    public CategoryRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }

    public async Task<IEnumerable<CategoryDto>> GetAllCategories()
    {
        var result = (from category in _collection.AsQueryable()
                      join grupo in _collection.Database.GetCollection<Group>("groups").AsQueryable() on category.GroupId equals grupo.Id into categoryGroupJoin
                      from grupo in categoryGroupJoin.DefaultIfEmpty()
                      select new CategoryDto
                      {
                          Id = category.Id,
                          Description = category.Description,
                          GroupDescription = grupo.Description,
                          GroupId = grupo.Id
              }).ToList();

        return result;
    }


}
