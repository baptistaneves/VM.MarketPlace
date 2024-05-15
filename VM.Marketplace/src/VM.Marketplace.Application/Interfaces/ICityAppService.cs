using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Application.Interfaces;

public interface ICityAppService
{
    Task AddCityAsync(CreateCityRequest cityRequest);
    Task UpdateCityAsync(UpdateCityRequest cityRequest);
    Task RemoveCityAsync(Guid id);
    Task<City> GetCityByIdAsync(Guid id);
    Task<IEnumerable<City>> GetAllCitiesAsync();
    Task<IEnumerable<CityDto>> GetCitiesByStateId(Guid id);

}