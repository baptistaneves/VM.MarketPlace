namespace VM.Marketplace.Application.Services;

public class UnitAppService : BaseAppService, IUnitAppService
{
    private readonly IUnitRepository _unitRepository;
    public UnitAppService(INotifier notifier, 
                          IUnitRepository unitRepository) : base(notifier)
    {
        _unitRepository = unitRepository;
    }

    public async Task AddUnitAsync(CreateUnitRequest unitRequest)
    {
        if (!Validate(new CreateUnitValidation(), unitRequest)) return;

        if (_unitRepository.FilterAsync(x => x.Description == unitRequest.Description).Result.Any())
        {
            Notify(UnitErrorMessage.UnitAlreadyExists);
            return;
        }

        await _unitRepository.InsertOnceAsync(new Unit(unitRequest.Description));
    }

    public async Task<IEnumerable<Unit>> GetAllUnitsAsync()
    {
        return await _unitRepository.GetAllAsync();
    }

    public async Task<Unit> GetUnitByIdAsync(Guid id)
    {
        return await _unitRepository.GetByIdAsync(id);
    }

    public async Task RemoveUnitAsync(Guid id)
    {
        if (!_unitRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(UnitErrorMessage.UnitNotFound);
            return;
        }

        await _unitRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateUnitAsync(UpdateUnitRequest unitRequest)
    {
        var unit = await _unitRepository.GetByIdAsync(unitRequest.Id);

        if (unit is null)
        {
            Notify(UnitErrorMessage.UnitNotFound);
            return;
        }

        if (!Validate(new UpdateUnitValidation(), unitRequest)) return;

        if (_unitRepository
            .FilterAsync(x => x.Description == unitRequest.Description && x.Id != unitRequest.Id).Result.Any())
        {
            Notify(UnitErrorMessage.UnitNotFound);
            return;
        }

        unit.Update(unitRequest.Description);

        await _unitRepository.ReplaceOnceAsync(unit);
    }
}