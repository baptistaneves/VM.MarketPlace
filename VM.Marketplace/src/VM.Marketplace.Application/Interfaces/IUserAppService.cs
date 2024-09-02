using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Application.Interfaces;

public interface IUserAppService
{
    Task<bool> AddAdmin(CreateAdminUserRequest userRequest);
    Task<bool> UpdateAdmin(UpdateAdminUserRequest updateUserRequest);
    
    Task<AuthenticationResultDto> AddCustomer(CreateCustomerUserRequest userRequest);
    Task<AuthenticationResultDto> AddSeller(CreateSellerUserRequest userRequest);
    Task<bool> UpdateSeller(UpdateSellerUserRequest userRequest);

    Task<UserDto> GetUserByIdAsync(Guid id);
    Task<IEnumerable<UserDto>> GetAllAdminUsersAsync();
    Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync();
    Task<IEnumerable<UserDto>> GetAllSellerUsersAsync();
    Task Remove(Guid id);
    Task<AuthenticationResultDto> Login(LoginRequest loginRequest);
    Task<AuthenticationResultDto> CustomerOrSellerLogin(LoginRequest loginRequest);

    Task AddBusinessLicense(Guid userId, string  businessLicense);
}