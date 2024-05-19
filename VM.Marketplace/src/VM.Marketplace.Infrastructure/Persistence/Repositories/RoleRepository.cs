using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class RoleRepository : GenericRepository<Role>, IRoleRepository
{
    private const string collectionName = "roles";

    private OperationResult<Role> _result;

    private readonly RoleManager<ApplicationRole> _roleManager;
    public RoleRepository(IMongoDatabase database, 
                          RoleManager<ApplicationRole> roleManager) : base(database, collectionName)
    {
        _roleManager = roleManager;
        _result = new OperationResult<Role>();
    }

    public async Task<IEnumerable<RoleDto>> GetAllRoles()
    {
        var result = (from role in _collection.AsQueryable()
                             select new RoleDto
                             {
                                 Id = role.Id,
                                 Name = role.Name,
                                 Claims = role.Claims.Select(x => new ClaimDto { Type = x.Type, Value = x.Value}),
                             }).ToList();

        return result;
    }

    public async Task<RoleDto> GetRoleById(Guid id)
    {
        var result = (from role in _collection.AsQueryable()
                      select new RoleDto
                      {
                          Id = role.Id,
                          Name = role.Name,
                          Claims = role.Claims.Select(x => new ClaimDto { Type = x.Type, Value = x.Value }),
                      }).FirstOrDefault(x => x.Id == id);

        return result;
    }

    public async Task<RoleDto> GetRoleByName(string name)
    {
        var result = (from role in _collection.AsQueryable()
                      select new RoleDto
                      {
                          Id = role.Id,
                          Name = role.Name,
                          Claims = role.Claims.Select(x => new ClaimDto { Type = x.Type, Value = x.Value }),
                      }).FirstOrDefault(x => x.Name == name);

        return result;
    }

    public async Task<OperationResult<Role>> InsertRoleOnceAsync(Role role)
    {
        var newRole = new ApplicationRole
        {
            Name = role.Name,
        };

        if(role.Claims.Any())
        {
            foreach (var roleClaim in role.Claims)
            {
                newRole.Claims.Add(new ApplicationClaim { Type = roleClaim.Type, Value = roleClaim.Value });
            }
        }

        var roleResult = await _roleManager.CreateAsync(newRole);

        if (!roleResult.Succeeded) AddErrors(roleResult);

        return _result;
    }

    public async Task<OperationResult<Role>> ReplaceRoleOnceAsync(Role newUpdateRole)
    {
        var currentRole = await _roleManager.FindByIdAsync(newUpdateRole.Id.ToString());

        if (newUpdateRole.Claims.Any())
        {
            var claimsToAdd = new List<MongoClaim>();
            var claimsToRemove = new List<MongoClaim>();

            foreach (var claim in newUpdateRole.Claims)
            {
                var existingClaim = currentRole.Claims.FirstOrDefault(x => x.Type == claim.Type && x.Value == claim.Value);

                if (existingClaim != null)
                {
                    claimsToRemove.Add(existingClaim);
                }
                else
                {
                    claimsToAdd.Add(new ApplicationClaim { Type = claim.Type, Value = claim.Value });
                }
            }

            foreach (var claimToRemove in claimsToRemove)
            {
                currentRole.Claims.Remove(claimToRemove);
            }

            currentRole.Claims.AddRange(claimsToAdd);
        }

        currentRole.Name = newUpdateRole.Name;

        var roleResult = await _roleManager.UpdateAsync(currentRole);

        if (!roleResult.Succeeded) AddErrors(roleResult);

        return _result;
    }

    public async Task<Dictionary<string, List<string>>> GetRoleClaims()
    {
        await Task.CompletedTask;

        Dictionary<string, List<string>> claims = new()
        {
                { ClaimType.User, new List<string> { ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Reset, ClaimValue.Block, ClaimValue.Unblock, ClaimValue.Remove} },
                { ClaimType.Dashboard, new List<string> { ClaimValue.View } },
                { ClaimType.Role, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.Group, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.State, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.Category, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.City, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.Unit, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.Address, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } },
                { ClaimType.DeliveryAddress, new List<string> {  ClaimValue.View, ClaimValue.Add, ClaimValue.Update, ClaimValue.Remove } }
            };

        return claims;
    }

    private void AddErrors(IdentityResult identityResult)
    {
        foreach (var error in identityResult.Errors)
        {
            _result.AddError(error.Description);
        }
    }

    private void AddError(string error)
    {
        _result.AddError(error);
    }
}