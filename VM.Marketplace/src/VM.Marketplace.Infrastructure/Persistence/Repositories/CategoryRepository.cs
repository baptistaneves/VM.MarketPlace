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
        var aggregate = _collection.Aggregate()
         .Lookup<Category, Group, CategoryDto>(
             foreignCollectionName: "groups",
             localField: c => c.GrupoId,
             foreignField: g => g.Id,
             @as: c => c.Grupo)
         .Unwind(c => c.Group)
         .Project(c => new CategoryDto
         {
             Id = c.Id,
             Description = c.Description,
             GroupId = c.Grupo.Id,
             GroupDescription = c.Grupo.Description
         });

        return await aggregate.ToListAsync();
    }
}
