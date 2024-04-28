namespace VM.Marketplace.Application.Interfaces;

public interface IStateAppService
{
    Task AddStateAsync(CreateStateRequest stateRequest);
    Task UpdateStateAsync(UpdateStateRequest stateRequest);
    Task RemoveStateAsync(Guid id);
    Task<State> GetStateByIdAsync(Guid id);
    Task<IEnumerable<State>> GetAllStatesAsync();
}