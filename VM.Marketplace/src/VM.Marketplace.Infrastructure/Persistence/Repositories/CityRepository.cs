
using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class CityRepository : GenericRepository<City>, ICityRepository
{
    private const string collectionName = "cities";
    public CityRepository(IMongoDatabase database) : base(database, collectionName)
    {
    }

    public async Task<IEnumerable<CityDto>> GetCitiesByStateId(Guid id)
    {
        var result = (from city in _collection.AsQueryable()
                      join state in _collection.Database.GetCollection<State>("states").AsQueryable() on city.StateId equals state.Id into cityStateJoin
                      from state in cityStateJoin.DefaultIfEmpty()
                      where city.StateId == id  // Filtrando por StateId
                      select new CityDto
                      {
                          Id = city.Id,
                          Name = city.Name,
                          StateId = state.Id,
                          StateName = state.Name
                      }).ToList();

        return result;
    }
}
