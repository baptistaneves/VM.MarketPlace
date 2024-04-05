namespace VM.Marketplace.Application.Services;

public class GroupAppService : BaseAppService, IGroupAppService
{
    private readonly IGroupRepository _groupRepository;
    public GroupAppService(INotifier notifier, IGroupRepository groupRepository) : base(notifier)
    {
        _groupRepository = groupRepository;
    }

    public async Task AddGroupAsync(CreateGroupRequest groupRequest)
    {
        if(!Validate(new CreateGroupRequestValidation(), groupRequest)) return;

        if(_groupRepository.FilterAsync(x => x.Description ==  groupRequest.Description).Result.Any()) 
        {
            Notify(GroupErrorMessage.GroupAlreadyExists);
            return;
        }

        await _groupRepository.InsertOnceAsync(new Group(groupRequest.Description, groupRequest.IsActive));
    }

    public async Task UpdateGroupAsync(UpdateGroupRequest groupRequest)
    {
        if(!_groupRepository.FilterAsync(x => x.Id == groupRequest.Id).Result.Any())
        {
            Notify(GroupErrorMessage.GroupNotFound);
            return;
        }

        if (!Validate(new UpdateGroupRequestValidation(), groupRequest)) return;

        if (_groupRepository
            .FilterAsync(x => x.Description == groupRequest.Description && x.Id != groupRequest.Id).Result.Any())
        {
            Notify(GroupErrorMessage.GroupAlreadyExists);
            return;
        }

        await _groupRepository.ReplaceOnceAsync(new Group(groupRequest.Description, groupRequest.IsActive));
    }

    public async Task RemoveGroupAsync(Guid id)
    {
        if (!_groupRepository.FilterAsync(x => x.Id == id).Result.Any())
        {
            Notify(GroupErrorMessage.GroupNotFound);
            return;
        }

        await _groupRepository.DeleteOnceAsync(id);
    }

    public async Task<IEnumerable<Group>> GetAllGroupsAsync()
    {
        return await _groupRepository.GetAllAsync();
    }

    public async Task<Group> GetGroupByIdAsync(Guid id)
    {
        return await _groupRepository.GetByIdAsync(id);
    }
}