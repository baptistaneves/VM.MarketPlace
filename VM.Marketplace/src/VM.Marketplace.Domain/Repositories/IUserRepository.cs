using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<OperationResult<UserDto>> Login(string username, string password);
    Task<OperationResult<UserDto>> CustomerOrSellerLogin(string username, string password);

    Task<OperationResult<UserDto>> InsertUserOnceAsync(User user);
    Task<OperationResult<UserDto>> ReplaceAdminUserOnceAsync(User updatedUser);

    Task<OperationResult<UserDto>> ReplaceSellerUserOnceAsync(User updatedUser);

    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllAdminUsersAsync();
    Task<UserDto> GetUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync();
    Task<IEnumerable<UserDto>> GetAllSellerUsersAsync();

    Task UpdateFieldAsync(Guid id, string fieldName, object newValue);
}