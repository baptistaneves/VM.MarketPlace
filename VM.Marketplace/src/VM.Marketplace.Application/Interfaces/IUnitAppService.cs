namespace VM.Marketplace.Application.Interfaces;

public interface IUnitAppService
{
    Task AddUnitAsync(CreateUnitRequest unitRequest);
    Task UpdateUnitAsync(UpdateUnitRequest unitRequest);
    Task RemoveUnitAsync(Guid id);
    Task<Unit> GetUnitByIdAsync(Guid id);
    Task<IEnumerable<Unit>> GetAllUnitsAsync();
}
