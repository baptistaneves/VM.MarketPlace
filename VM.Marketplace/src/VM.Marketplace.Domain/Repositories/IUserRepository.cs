
using VM.Marketplace.Domain.Entities;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Domain.Repositories;

public interface IUserRepository : IGenericRepository<User>
{
    Task<OperationResult<User>> Login(string username, string password);
    Task<OperationResult<User>> InsertAdminUserOnceAsync(User user);

    Task<IEnumerable<User>> GetAllAdminUsersAsync();
    Task<IEnumerable<User>> GetAllCustomerUsersAsync();
    Task<IEnumerable<User>> GetAllSellerUsersAsync();
}