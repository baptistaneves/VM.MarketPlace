using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Application.Interfaces;

public interface IRoleAppService
{
    Task AddRoleAsync(RoleRequest roleRequest);
    Task UpdateRoleAsync(RoleRequest roleRequest);
    Task RemoveRoleAsync(Guid id);
    Task<RoleDto> GetRoleByIdAsync(Guid id);
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<Dictionary<string, List<string>>> GetRoleClaims();
}
