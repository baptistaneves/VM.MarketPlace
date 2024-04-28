namespace VM.Marketplace.Application.Services;

public class StateAppService : BaseAppService, IStateAppService
{
    private readonly IStateRepository _stateRepository;
    public StateAppService(INotifier notifier, 
                           IStateRepository stateRepository) : base(notifier)
    {
        _stateRepository = stateRepository;
    }

    public async Task AddStateAsync(CreateStateRequest stateRequest)
    {
        if (!Validate(new CreateStateValidation(), stateRequest)) return;

        if (_stateRepository.FilterAsync(x => x.Name == stateRequest.Name).Result.Any())
        {
            Notify(StateErrorMessage.StateNotFound);
            return;
        }

        await _stateRepository.InsertOnceAsync(new State(stateRequest.Name));
    }

    public async Task<IEnumerable<State>> GetAllStatesAsync()
    {
        return await _stateRepository.GetAllAsync();
    }

    public async Task<State> GetStateByIdAsync(Guid id)
    {
        return await _stateRepository.GetByIdAsync(id);
    }

    public async Task RemoveStateAsync(Guid id)
    {
        if (!_stateRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(StateErrorMessage.StateNotFound);
            return;
        }

        await _stateRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateStateAsync(UpdateStateRequest stateRequest)
    {
        var state = await _stateRepository.GetByIdAsync(stateRequest.Id);

        if (state is null)
        {
            Notify(StateErrorMessage.StateNotFound);
            return;
        }

        if (!Validate(new UpdateStateValidation(), stateRequest)) return;

        if (_stateRepository
            .FilterAsync(x => x.Name == stateRequest.Name && x.Id != stateRequest.Id).Result.Any())
        {
            Notify(StateErrorMessage.StateAlreadyExists);
            return;
        }

        state.Update(stateRequest.Name);

        await _stateRepository.ReplaceOnceAsync(state);
    }
}