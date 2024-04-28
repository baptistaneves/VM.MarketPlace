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
}
