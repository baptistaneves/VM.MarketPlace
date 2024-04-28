namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class GroupsController : BaseController
{
    private readonly IGroupAppService _groupService;
    public GroupsController(INotifier notifier, 
                           IGroupAppService groupService) : base(notifier)
    {
        _groupService = groupService;
    }

    [HttpGet(ApiRoutes.Group.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _groupService.GetAllGroupsAsync());
    }

    [HttpGet(ApiRoutes.Group.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var address = await _groupService.GetGroupByIdAsync(id);

        if(address == null) return NotFound();

       return Response();
    }

    [HttpPost(ApiRoutes.Group.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] CreateGroupRequest groupRequest)
    {
        await _groupService.AddGroupAsync(groupRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Group.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] UpdateGroupRequest groupRequest)
    {
        await _groupService.UpdateGroupAsync(groupRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.Group.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _groupService.RemoveGroupAsync(id);

        return Response();
    }
}
