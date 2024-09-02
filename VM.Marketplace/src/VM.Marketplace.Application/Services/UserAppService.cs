using VM.Marketplace.Domain.Dtos;
using VM.Marketplace.Domain.Notifications.Results;

namespace VM.Marketplace.Application.Services;

public class UserAppService : BaseAppService, IUserAppService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtService _jwtService;
    public UserAppService(INotifier notifier,
                          IUserRepository userRepository,
                          IJwtService jwtService) : base(notifier)
    {
        _userRepository = userRepository;
        _jwtService = jwtService;
    }

    public async Task<bool> AddAdmin(CreateAdminUserRequest userRequest)
    {
        if (!Validate(new CreateAdminUserValidation(), userRequest)) new OperationResult<User>(); 

        var newUser = User.CreateAdminUser(userRequest.FullName, userRequest.Email, 
            userRequest.PhoneNumber, userRequest.Password, userRequest.Role);

        var result = await _userRepository.InsertUserOnceAsync(newUser);

        if (result.HasError)
        {
            result.Errors.ForEach(error => { Notify(error.Message); });
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateAdmin(UpdateAdminUserRequest updateAdmin)
    {
        if (!Validate(new UpdateAdminUserValidation(), updateAdmin)) new OperationResult<User>();

        var updatedUser = User.UpdateAdminUser(updateAdmin.Id, updateAdmin.FullName, updateAdmin.Email, updateAdmin.PhoneNumber, updateAdmin.Role);

        var result = await _userRepository.ReplaceAdminUserOnceAsync(updatedUser);

        if (result.HasError)
        {
            result.Errors.ForEach(error => { Notify(error.Message); });
            return false;
        }

        return true;
    }

    public async Task<bool> UpdateSeller(UpdateSellerUserRequest userRequest)
    {

        if (!Validate(new UpdateSellerUserValidation(), userRequest)) new OperationResult<User>();

        var user = User.UpdateSellerUser(userRequest.Id, userRequest.FullName, userRequest.Email, userRequest.PhoneNumber,
            userRequest.City, userRequest.State, userRequest.Address, 
            userRequest.TaxIdentificationNumber, userRequest.TypeSeller, userRequest.BusinessLicense);

        var result = await _userRepository.ReplaceSellerUserOnceAsync(user);

        if (result.HasError)
        {
            result.Errors.ForEach(error => { Notify(error.Message); });
            return false;
        }

        return true;
    }

    public async Task<AuthenticationResultDto> AddCustomer(CreateCustomerUserRequest userRequest)
    {
        if (!Validate(new CreateCustomerUserValidation(), userRequest)) new OperationResult<User>();

        var newUser = User.CreateCustomerUser(userRequest.FullName, userRequest.Email, userRequest.PhoneNumber, userRequest.Password);

        var result = await _userRepository.InsertUserOnceAsync(newUser);

        if (result.HasError)
            result.Errors.ForEach(error => { Notify(error.Message); });

        return await _jwtService.GenerateToken(result.Payload);
    }

    public async Task<AuthenticationResultDto> AddSeller(CreateSellerUserRequest userRequest)
    {
        if (!Validate(new CreateSellerUserValidation(), userRequest)) new OperationResult<User>();

        var newUser = User.CreateSellerUser(userRequest.FullName, userRequest.Email, userRequest.PhoneNumber, userRequest.Password);

        var result = await _userRepository.InsertUserOnceAsync(newUser);

        if (result.HasError)
        {
            result.Errors.ForEach(error => { Notify(error.Message); });
            return null;
        }

        return await _jwtService.GenerateToken(result.Payload);
    }

    public async Task<IEnumerable<UserDto>> GetAllAdminUsersAsync()
    {
        return await _userRepository.GetAllAdminUsersAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync()
    {
        return await _userRepository.GetAllCustomerUsersAsync();
    }

    public async Task<IEnumerable<UserDto>> GetAllSellerUsersAsync()
    {
        return await _userRepository.GetAllSellerUsersAsync();
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetUserByIdAsync(id);
    }

    public async Task<AuthenticationResultDto> Login(LoginRequest loginRequest)
    {
        if (!Validate(new LoginValidation(), loginRequest)) new OperationResult<User>();

        var result = await _userRepository.Login(loginRequest.Email, loginRequest.Password);

        if (result.HasError)
        {
            result.Errors.ForEach(error => { Notify(error.Message); });
            return null;
        }

        return await _jwtService.GenerateToken(result.Payload);
    }

    public async Task<AuthenticationResultDto> CustomerOrSellerLogin(LoginRequest loginRequest)
    {
        if (!Validate(new LoginValidation(), loginRequest)) new OperationResult<User>();

        var result = await _userRepository.CustomerOrSellerLogin(loginRequest.Email, loginRequest.Password);

        if (result.HasError)
        {
            result.Errors.ForEach(error => { Notify(error.Message); });
            return null;
        }

        return await _jwtService.GenerateToken(result.Payload);
    }

    public async Task Remove(Guid id)
    {
        await _userRepository.DeleteOnceAsync(id);
    }

    public async Task AddBusinessLicense(Guid userId, string businessLicenseUrl)
    {

        await _userRepository.UpdateFieldAsync(userId, "BusinessLicenseUrl", businessLicenseUrl);
    }
}