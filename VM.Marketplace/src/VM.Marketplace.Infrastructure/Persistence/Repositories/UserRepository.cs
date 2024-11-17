using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private const string collectionName = "users";
    private OperationResult<UserDto> _result;

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(IMongoDatabase database,
                          UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager) : base(database, collectionName)
    {
        _userManager = userManager;
        _result = new OperationResult<UserDto>();
        _signInManager = signInManager;
    }

    public async Task<OperationResult<UserDto>> InsertUserOnceAsync(User user)
    {
        var newUser = new ApplicationUser
        {
            Id = user.Id,
            FullName = user.FullName,
            Role = user.Role,
            UserName = user.Email,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Type = user.Type,
            Address = user.Address,
            PhotoUrl = user.PhotoUrl,
            VatNumber = user.VatNumber,
            Bank = user.Bank,
            AccountNumber = user.AccountNumber,
            Iban = user.Iban,
            CreatedAt = user.CreatedAt,
            IsBlocked = user.IsBlocked,
            IsDeleted = user.IsDeleted,
        };

        var identityResult = await _userManager.CreateAsync(newUser, user.Password);

        if (!identityResult.Succeeded)
        {
            AddErrors(identityResult);
            return _result;
        }

        _result.Payload = new UserDto { FullName = user.FullName, Id = user.Id, Email = user.Email, PhoneNumber = user.PhoneNumber};

        return _result;
    }

    public async Task<OperationResult<UserDto>> ReplaceAdminUserOnceAsync(User updatedUser)
    {
        var currentUserState = await _userManager.FindByIdAsync(updatedUser.Id.ToString());

        currentUserState.FullName = updatedUser.FullName;
        currentUserState.PhoneNumber = updatedUser.PhoneNumber;
        currentUserState.Email = updatedUser.Email;
        currentUserState.Role = updatedUser.Role;


        var identityResult = await _userManager.UpdateAsync(currentUserState);

        if (!identityResult.Succeeded)
        {
            AddErrors(identityResult);
            return _result;
        }

        return _result;
    }

    public async Task<OperationResult<UserDto>> ReplaceSellerUserOnceAsync(User updatedUser)
    {
        var currentUserState = await _userManager.FindByIdAsync(updatedUser.Id.ToString());

        currentUserState.FullName = updatedUser.FullName;
        currentUserState.PhoneNumber = updatedUser.PhoneNumber;
        currentUserState.Email = updatedUser.Email;
        currentUserState.City = updatedUser.City;
        currentUserState.State = updatedUser.State;
        currentUserState.Address = updatedUser.Address;
        currentUserState.TaxIdentificationNumber = updatedUser.TaxIdentificationNumber;
        currentUserState.TypeSeller = updatedUser.TypeSeller;
        currentUserState.Address = updatedUser.Address;


        var identityResult = await _userManager.UpdateAsync(currentUserState);

        if (!identityResult.Succeeded)
        {
            AddErrors(identityResult);
            return _result;
        }

        return _result;
    }

    public async Task<OperationResult<UserDto>> Login(string username, string password)
    {
        var user = await _userManager.FindByEmailAsync(username);

        if(user is null)
        {
            AddErrors(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        var identityResult = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        if(identityResult.IsLockedOut)
        {
            AddErrors(UserErrorMessage.LockoutFailure);
            return _result;
        }

        if (!identityResult.Succeeded) 
        {
            AddErrors(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        _result.Payload = await GetUserByEmailAsync(user.Email);

        return _result;
    }

    public async Task<OperationResult<UserDto>> CustomerOrSellerLogin(string username, string password)
    {
        var user = await _userManager.FindByEmailAsync(username);

        if (user is null)
        {
            AddErrors(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        if (user.Type != TypeUser.Seller)
        {
            AddErrors(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        var identityResult = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        if (identityResult.IsLockedOut)
        {
            AddErrors(UserErrorMessage.LockoutFailure);
            return _result;
        }

        if (!identityResult.Succeeded)
        {
            AddErrors(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        _result.Payload = await GetUserByEmailAsync(user.Email);

        return _result;
    }

    public async Task<IEnumerable<UserDto>> GetAllAdminUsersAsync()
    {
        var result = (from user in _collection.AsQueryable()
                      select new UserDto
                      {
                          Id = user.Id,
                          FullName = user.FullName,
                          PhoneNumber = user.PhoneNumber,
                          Email = user.Email,
                          Type = user.Type,
                          PhotoUrl = user.PhotoUrl,
                          AccountNumber = user.PhoneNumber,
                          AccountHolder = user.AccountHolder,
                          Iban = user.Iban,
                          IsBlocked = user.IsBlocked,
                          Address = user.Address,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber,
                          BusinessLicenseUrl = user.BusinessLicenseUrl
                      }).Where(x => x.Type == TypeUser.Administrator).ToList();

        return result;
    }

    public async Task<IEnumerable<UserDto>> GetAllCustomerUsersAsync()
    {
        var result = (from user in _collection.AsQueryable()
                      select new UserDto
                      {
                          Id = user.Id,
                          FullName = user.FullName,
                          PhoneNumber = user.PhoneNumber,
                          Email = user.Email,
                          Type = user.Type,
                          PhotoUrl = user.PhotoUrl,
                          AccountNumber = user.PhoneNumber,
                          AccountHolder = user.AccountHolder,
                          Iban = user.Iban,
                          IsBlocked = user.IsBlocked,
                          Address = user.Address,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber
                      }).Where(x => x.Type == TypeUser.Customer).ToList();

        return result;
    }

    public async Task<IEnumerable<UserDto>> GetAllSellerUsersAsync()
    {
        var result = (from user in _collection.AsQueryable()
                      select new UserDto
                      {
                          Id = user.Id,
                          FullName = user.FullName,
                          Email = user.Email,
                          Type = user.Type,
                          PhoneNumber = user.PhoneNumber,
                          PhotoUrl = user.PhotoUrl,
                          AccountNumber = user.PhoneNumber,
                          AccountHolder = user.AccountHolder,
                          Iban = user.Iban,
                          IsBlocked = user.IsBlocked,
                          Address = user.Address,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber,
                          IsVerified = user.IsVerified,
                          BusinessLicenseUrl = user.BusinessLicenseUrl
                      }).Where(x => x.Type == TypeUser.Seller).ToList();

        return result;
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        var result = (from user in _collection.AsQueryable()
                      select new UserDto
                      {
                          Id = user.Id,
                          FullName = user.FullName,
                          PhoneNumber = user.PhoneNumber,
                          Email = user.Email,
                          Type = user.Type,
                          PhotoUrl = user.PhotoUrl,
                          AccountNumber = user.PhoneNumber,
                          AccountHolder = user.AccountHolder,
                          Iban = user.Iban,
                          IsBlocked = user.IsBlocked,
                          Address = user.Address,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber
                      }).FirstOrDefault(x => x.Email == email);

        return result;
    }

    public async Task<UserDto> GetUserByIdAsync(Guid id)
    {
        var result = (from user in _collection.AsQueryable()
                      select new UserDto
                      {
                          Id = user.Id,
                          FullName = user.FullName,
                          PhoneNumber = user.PhoneNumber,
                          Email = user.Email,
                          Type = user.Type,
                          PhotoUrl = user.PhotoUrl,
                          AccountNumber = user.PhoneNumber,
                          AccountHolder = user.AccountHolder,
                          Iban = user.Iban,
                          IsBlocked = user.IsBlocked,
                          IsVerified = user.IsVerified,
                          Address = user.Address,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber,
                          City = user.City,
                          State = user.State,
                          BusinessLicense = user.BusinessLicenseUrl
                      }).FirstOrDefault(x => x.Id == id);

        return result;
    }

    private void AddErrors(IdentityResult identityResult)
    {
        foreach (var error in identityResult.Errors)
        {
            _result.AddError(error.Description);
        }
    }
    private void AddErrors(string error)
    {
        _result.AddError(error);
    }

 

}
