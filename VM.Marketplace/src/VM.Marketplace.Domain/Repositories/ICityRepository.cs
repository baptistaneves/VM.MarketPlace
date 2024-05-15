using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;

namespace VM.Marketplace.Domain.Repositories;

public interface ICityRepository : IGenericRepository<City>
{
    Task<IEnumerable<CityDto>> GetCitiesByStateId(Guid id);
}
