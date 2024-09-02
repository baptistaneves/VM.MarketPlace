namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class LoginController : BaseController
{
    private readonly IUserAppService _userAppService;
    public LoginController(INotifier notifier, 
                           IUserAppService userAppService) : base(notifier)
    {
        _userAppService = userAppService;
    }

    [HttpPost]
    [ValidateModel]
    public async Task<ActionResult> Login([FromBody] LoginRequest login)
    {
        var response = await _userAppService.Login(login);

        return Response(response);

    }

    [HttpPost(ApiRoutes.User.CustomerOrSellerLogin)]
    [ValidateModel]
    public async Task<ActionResult> CustomerOrSellerLogin([FromBody] LoginRequest login)
    {
        var response = await _userAppService.CustomerOrSellerLogin(login);

        return Response(response);

    }
}