
using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<OperationResult<UserDto>> Login(string username, string password);

    Task<OperationResult<User>> InsertAdminUserOnceAsync(User user);
    Task<OperationResult<User>> ReplaceAdminUserOnceAsync(User updatedUser);

    Task<OperationResult<User>> InsertSellerUserOnceFromDashboardAsync(User user);
    Task<OperationResult<User>> ReplaceSellerUserOnceFromDashboardAsync(User updatedUser);

    Task<IEnumerable<UserDto>> GetAllAdminUsersAsync();
    Task<UserDto> GetAdminUserByEmailAsync(string email);
    Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync();
    Task<IEnumerable<UserDto>> GetAllSellerUsersAsync();
}