namespace VM.Marketplace.API.Controllers.V1;

[ApiVersion("1.0")]
[Route(ApiRoutes.BaseRoute)]
public class RolesController : BaseController
{
    private readonly IRoleAppService _roleAppService;
    public RolesController(INotifier notifier, IRoleAppService roleAppService) : base(notifier)
    {
        _roleAppService = roleAppService;
    }

    [HttpGet(ApiRoutes.Role.GetAll)]
    public async Task<ActionResult> GetAll()
    {
        return Response(await _roleAppService.GetAllRolesAsync());
    }

    [HttpGet(ApiRoutes.Role.GetRoleClaims)]
    public async Task<ActionResult> GetRoleClaims()
    {
        return Response(await _roleAppService.GetRoleClaims());
    }

    [HttpGet(ApiRoutes.Role.GetById)]
    [ValidateGuid("id")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var role = await _roleAppService.GetRoleByIdAsync(id);

        if (role == null) return NotFound();

        return Response(role);
    }

    [HttpPost(ApiRoutes.Role.Add)]
    [ValidateModel]
    public async Task<ActionResult> Add([FromBody] RoleRequest roleRequest)
    {
        await _roleAppService.AddRoleAsync(roleRequest);

        return Response();
    }

    [HttpPut(ApiRoutes.Role.Update)]
    [ValidateModel]
    public async Task<ActionResult> Update([FromBody] RoleRequest roleRequest)
    {
        await _roleAppService.UpdateRoleAsync(roleRequest);

        return Response();
    }

    [HttpDelete(ApiRoutes.Role.Remove)]
    [ValidateGuid("id")]
    [ValidateModel]
    public async Task<ActionResult> Remove(Guid id)
    {
        await _roleAppService.RemoveRoleAsync(id);

        return Response();
    }
}