using Microsoft.AspNetCore.Authorization;

namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
[Authorize]
public class UsersController : BaseController
{
    private readonly IUserAppService _userAppService;
    public UsersController(INotifier notifier, 
                           IUserAppService userAppService) : base(notifier)
    {
        _userAppService = userAppService;
    }

    [HttpGet(ApiRoutes.User.GetAllAdminUsers)]
    public async Task<ActionResult> GetAllAdminUsers()
    {
        return Response(await _userAppService.GetAllAdminUsersAsync());
    }

    [HttpPost(ApiRoutes.User.AddAdminUser)]
    [ValidateModel]
    public async Task<ActionResult> AddAdminUser([FromBody] CreateAdminUserRequest userRequest)
    {
        await _userAppService.AddAdmin(userRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.User.UpdateUserAdmin)]
    [ValidateModel]
    public async Task<ActionResult> UpdateUserAdmin([FromBody] UpdateAdminUserRequest userRequest)
    {
        await _userAppService.UpdateAdmin(userRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.User.RemoveUserAdmin)]
    [ValidateGuid("id")]
    public async Task<ActionResult> RemoveUserAdmin(Guid id)
    {
        await _userAppService.Remove(id);

        return Response();
    }
}
