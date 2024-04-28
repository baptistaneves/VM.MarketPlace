using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Application.Interfaces;

public interface IUserAppService
{
    Task<OperationResult<User>> AddAdmin(CreateAdminUserRequest userRequest);
    Task<OperationResult<User>> AddCustomer(CreateCustomerUserRequest userRequest);
    Task<OperationResult<User>> AddSeller(CreateSellerUserRequest userRequest);
    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<User>> GetAllAdminUsersAsync();
    Task<IEnumerable<User>> GetAllCustomerUsersAsync();
    Task<IEnumerable<User>> GetAllSellerUsersAsync();
    Task Remove(Guid id);
    Task<OperationResult<User>> Login(LoginRequest loginRequest);
}