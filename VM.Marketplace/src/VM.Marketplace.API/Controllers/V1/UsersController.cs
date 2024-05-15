namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
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
}
