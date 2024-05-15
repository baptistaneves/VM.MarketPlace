using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Domain.Repositories;

public interface IRoleRepository : IGenericRepository<Role>
{
    Task<IEnumerable<RoleDto>> GetAllRoles();
    Task<RoleDto> GetRoleById(Guid id);
    Task<RoleDto> GetRoleByName(string name);
    Task<OperationResult<Role>> InsertRoleOnceAsync(Role role);
    Task<OperationResult<Role>> ReplaceRoleOnceAsync(Role role);
    Task<Dictionary<string, List<string>>> GetRoleClaims();
}