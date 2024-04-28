namespace VM.Marketplace.Application.Services;

public class CityAppService : BaseAppService, ICityAppService
{
    private readonly ICityRepository _cityRepository;
    public CityAppService(INotifier notifier, 
                          ICityRepository cityRepository) : base(notifier)
    {
        _cityRepository = cityRepository;
    }

    public async Task AddCityAsync(CreateCityRequest cityRequest)
    {
        if (!Validate(new CreateCityValidation(), cityRequest)) return;

        if (_cityRepository.FilterAsync(x => x.Name == cityRequest.Name).Result.Any())
        {
            Notify(CityErrorMessage.CityAlreadyExists);
            return;
        }

        await _cityRepository.InsertOnceAsync(new City(cityRequest.Name, cityRequest.StateId));
    }

    public async Task<IEnumerable<City>> GetAllCitiesAsync()
    {
        return await _cityRepository.GetAllAsync();
    }

    public async Task<City> GetCityByIdAsync(Guid id)
    {
        return await _cityRepository.GetByIdAsync(id);
    }

    public async Task RemoveCityAsync(Guid id)
    {
        if (!_cityRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(CityErrorMessage.CityNotFound);
            return;
        }

        await _cityRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateCityAsync(UpdateCityRequest cityRequest)
    {
        var city = await _cityRepository.GetByIdAsync(cityRequest.Id);

        if (city is null)
        {
            Notify(CityErrorMessage.CityNotFound);
            return;
        }

        if (!Validate(new UpdateCityValidation(), cityRequest)) return;

        if (_cityRepository
            .FilterAsync(x => x.Name == cityRequest.Name && x.Id != cityRequest.Id).Result.Any())
        {
            Notify(CityErrorMessage.CityAlreadyExists);
            return;
        }
        city.Update(cityRequest.Name, cityRequest.StateId);

        await _cityRepository.ReplaceOnceAsync(city);
    }
}
