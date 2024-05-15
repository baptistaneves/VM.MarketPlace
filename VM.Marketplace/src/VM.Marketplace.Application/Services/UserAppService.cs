﻿using VM.Marketplace.Domain.Dtos;
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

    public async Task<OperationResult<User>> AddAdmin(CreateAdminUserRequest userRequest)
    {
        if (!Validate(new CreateAdminUserValidation(), userRequest)) new OperationResult<User>(); 

        var newUser = User.CreateAdminUser(userRequest.FullName, userRequest.Email, 
            userRequest.PhoneNumber, userRequest.Password, userRequest.Role);

        var result = await _userRepository.InsertAdminUserOnceAsync(newUser);

        if(result.HasError)
            result.Errors.ForEach(error => { Notify(error.Message); });

        return result;
    }

    public async Task<OperationResult<User>> AddCustomer(CreateCustomerUserRequest userRequest)
    {
        if (!Validate(new CreateCustomerUserValidation(), userRequest)) new OperationResult<User>();

        var newUser = User.CreateCustomerUser(userRequest.FullName, userRequest.Email, userRequest.PhoneNumber, userRequest.Password);

        var result = await _userRepository.InsertAdminUserOnceAsync(newUser);

        if (result.HasError)
            result.Errors.ForEach(error => { Notify(error.Message); });

        return result;
    }

    public async Task<OperationResult<User>> AddSeller(CreateSellerUserRequest userRequest)
    {
        if (!Validate(new CreateSellerUserValidation(), userRequest)) new OperationResult<User>();

        var newUser = User.CreateSellerUser(userRequest.FullName, userRequest.Email, userRequest.PhoneNumber, userRequest.VatNumber, userRequest.Password);

        var result = await _userRepository.InsertAdminUserOnceAsync(newUser);

        if (result.HasError)
            result.Errors.ForEach(error => { Notify(error.Message); });

        return result;
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

    public async Task<User> GetUserByIdAsync(Guid id)
    {
        return await _userRepository.GetByIdAsync(id);
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

    public async Task Remove(Guid id)
    {
        await _userRepository.DeleteOnceAsync(id);
    }
}