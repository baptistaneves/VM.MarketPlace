using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Application.Interfaces;

public interface IUserAppService
{
    Task<OperationResult<User>> AddAdmin(CreateAdminUserRequest userRequest);
    Task<OperationResult<User>> UpdateAdmin(UpdateAdminUserRequest updateUserRequest);
    
    Task<OperationResult<User>> AddCustomer(CreateCustomerUserRequest userRequest);
    Task<OperationResult<User>> AddSeller(CreateSellerUserRequest userRequest);

    Task<OperationResult<User>> InsertSellerUserOnceFromDashboardAsync(CreateSellerUserFromDashboardRequest userRequest);
    Task<OperationResult<User>> UpdateSellerUserOnceFromDashboardAsync(CreateSellerUserFromDashboardRequest updatedUser);

    Task<User> GetUserByIdAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllAdminUsersAsync();
    Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync();
    Task<IEnumerable<UserDto>> GetAllSellerUsersAsync();
    Task Remove(Guid id);
    Task<AuthenticationResultDto> Login(LoginRequest loginRequest);
}