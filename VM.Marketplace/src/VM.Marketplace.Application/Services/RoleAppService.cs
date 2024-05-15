using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Application.Services;

public class RoleAppService : BaseAppService, IRoleAppService
{
    private readonly IRoleRepository _roleRepository;
    public RoleAppService(INotifier notifier, IRoleRepository roleRepository) : base(notifier)
    {
        _roleRepository = roleRepository;
    }

    public async Task AddRoleAsync(RoleRequest roleRequest)
    {
        if (!Validate(new CreateRoleValidation(), roleRequest)) return;

        if (_roleRepository.FilterAsync(x => x.Name == roleRequest.Name).Result.Any())
        {
            Notify(RoleErrorMessage.RoleAlreadyExists);
            return;
        }

        var newRole = new Role(roleRequest.Name);

        if(roleRequest.Claims.Any() )
        {
            roleRequest.Claims.ForEach(claim =>
            {
                newRole.AddClaim(new RoleClaim(claim.ClaimType, claim.ClaimValue));
            });
        }

        var result = await _roleRepository.InsertRoleOnceAsync(newRole);

        if (result.HasError)
            result.Errors.ForEach(error => { Notify(error.Message); });
    }

    public async Task<IEnumerable<RoleDto>> GetAllRolesAsync()
    {
        return await _roleRepository.GetAllRoles();
    }

    public async Task<RoleDto> GetRoleByIdAsync(Guid id)
    {
        return await _roleRepository.GetRoleById(id);
    }

    public async Task<Dictionary<string, List<string>>> GetRoleClaims()
    {
        return await _roleRepository.GetRoleClaims();
    }

    public async Task RemoveRoleAsync(Guid id)
    {
        await _roleRepository.DeleteOnceAsync(id);
    }

    public async Task UpdateRoleAsync(RoleRequest roleRequest)
    {
        if (!Validate(new UpdateRoleValidation(), roleRequest)) return;

        if (_roleRepository.FilterAsync(x => x.Name == roleRequest.Name && x.Id != roleRequest.Id).Result.Any())
        {
            Notify(RoleErrorMessage.RoleAlreadyExists);
            return;
        }

        var updatedRole = Role.UpdateRole(roleRequest.Id, roleRequest.Name);

        if (roleRequest.Claims.Any())
        {
            roleRequest.Claims.ForEach(claim =>
            {
                updatedRole.AddClaim(new RoleClaim(claim.ClaimType, claim.ClaimValue));
            });
        }

        var result = await _roleRepository.ReplaceRoleOnceAsync(updatedRole);

        if (result.HasError)
            result.Errors.ForEach(error => { Notify(error.Message); });
    }
}