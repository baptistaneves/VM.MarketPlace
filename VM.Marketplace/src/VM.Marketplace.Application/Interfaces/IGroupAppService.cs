namespace VM.Marketplace.Application.Interfaces;

public interface IGroupAppService
{
    Task AddGroupAsync(CreateGroupRequest groupRequest);
    Task UpdateGroupAsync(UpdateGroupRequest groupRequest);
    Task RemoveGroupAsync(Guid id);
    Task<Group> GetGroupByIdAsync(Guid id);
    Task<IEnumerable<Group>> GetAllGroupsAsync();
}
