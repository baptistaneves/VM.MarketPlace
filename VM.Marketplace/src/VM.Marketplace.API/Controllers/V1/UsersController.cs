namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
//[Authorize]
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

    [HttpGet(ApiRoutes.User.GetAllSellerUsers)]
    public async Task<ActionResult> GetAllSellerUsers()
    {
        return Response(await _userAppService.GetAllSellerUsersAsync());
    }

    [Authorize]
    [HttpGet(ApiRoutes.User.GetCurrentUserData)]
    public async Task<ActionResult> GetCurrentUserData()
    {
        return Response(await _userAppService.GetUserByIdAsync(HttpContext.GetIdentityUserId()));
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

    [AllowAnonymous]
    [HttpPost(ApiRoutes.User.AddSellerUser)]
    [ValidateModel]
    public async Task<ActionResult> AddSellerUser([FromBody] CreateSellerUserRequest userRequest)
    {
        var response = await _userAppService.AddSeller(userRequest);

        return Response(response);
    }

    [HttpPut(ApiRoutes.User.Update)]
    [ValidateModel]
    public async Task<ActionResult> UpdateSellerUser([FromBody] UpdateSellerUserRequest userRequest)
    {
        if (userRequest.File != null)
        {
            var filePrefix = Guid.NewGuid() + "_";

            if (!await UploadFile(userRequest.File, filePrefix))
            {
                return Response();
            }

            userRequest.BusinessLicense = filePrefix + userRequest.File.FileName;
        }

        await _userAppService.UpdateSeller(userRequest);

        return Response();
    }

    [Authorize]
    [HttpPut(ApiRoutes.User.VerifyUser)]
    public async Task<ActionResult> VerifyUser(Guid userId)
    {
        await _userAppService.VerifyUser(userId);

        return Response();
    }

    [Authorize]
    [HttpPut(ApiRoutes.User.UnverifyUser)]
    public async Task<ActionResult> UnverifyUser(Guid userId)
    {
        await _userAppService.UnverifyUser(userId);

        return Response();
    }

    [Authorize]
    [HttpPut(ApiRoutes.User.AddBusinessLicense)]
    public async Task<ActionResult> AddBusinessLicense()
    {
        var businessLicenseFile = HttpContext.Request.Form.Files.FirstOrDefault();
        
        var userId = HttpContext.GetIdentityUserId();

        var imagePrefix = Guid.NewGuid() + "_";

        if (!await UploadFile(businessLicenseFile, imagePrefix))
        {
            return Response();
        }

        var licenseUrl = imagePrefix + businessLicenseFile.FileName;

        await _userAppService.AddBusinessLicense(userId, licenseUrl);

        return Response();
    }



    [Authorize]
    [HttpDelete(ApiRoutes.User.RemoveBusinessLicense)]
    public async Task<ActionResult> RemoveBusinessLicense()
    {
        var userId = HttpContext.GetIdentityUserId();

        var user = await _userAppService.RemoveBusinessLicense(userId);

        DeleteFile(user.BusinessLicense);

        return Response();
    }

    private async Task<bool> UploadFile(IFormFile file, string imgPrefix)
    {
        if (file == null || file.Length == 0)
        {
            Notify("Forneça um documento válido!");
            return false;
        }

        const long maxFileSize = 600 * 1024;
        if (file.Length > maxFileSize)
        {
            Notify("O tamanho do documento não pode exceder 600 KB!");
            return false;
        }

        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Licenses", imgPrefix + file.FileName);

        if (System.IO.File.Exists(path))
        {
            Notify("Já existe um documento com este nome!");
            return false;
        }

        using (var stream = new FileStream(path, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }

        return true;
    }

    private bool DeleteFile(string fileName)
    {
        var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Licenses", fileName);

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);

            return true;
        }

        return false;
    }
}
