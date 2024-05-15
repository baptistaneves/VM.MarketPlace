using VM.Marketplace.Domain.Dtos;

namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private const string collectionName = "users";
    private OperationResult<User> _result;
    private OperationResult<UserDto> _loginResult;

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(IMongoDatabase database,
                          UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager) : base(database, collectionName)
    {
        _userManager = userManager;
        _result = new OperationResult<User>();
        _loginResult = new OperationResult<UserDto>();
        _signInManager = signInManager;
    }

    public async Task<OperationResult<User>> InsertAdminUserOnceAsync(User user)
    {
        var newUser = new ApplicationUser
        {
            FullName = user.FullName,
            Role = user.Role,
            UserName = user.Email,
            Email = user.Email,
            PhoneNumber = user.PhoneNumber,
            Type = user.Type,
            Address = user.Address,
            DeliveryAddress = user.DeliveryAddress,
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

        return _result;
    }

    public async Task<OperationResult<UserDto>> Login(string username, string password)
    {
        var user = await _userManager.FindByEmailAsync(username);

        if(user is null)
        {
            AddLoginError(UserErrorMessage.IncorretEmailOrPassword);
            return _loginResult;
        }

        var identityResult = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        if(identityResult.IsLockedOut)
        {
            AddLoginError(UserErrorMessage.LockoutFailure);
            return _loginResult;
        }

        if (!identityResult.Succeeded) 
        {
            AddLoginError(UserErrorMessage.IncorretEmailOrPassword);
            return _loginResult;
        }

        _loginResult.Payload = await GetAdminUserByEmailAsync(user.Email);

        return _loginResult;
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
                          DeliveryAddress = user.DeliveryAddress,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber
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
                          DeliveryAddress = user.DeliveryAddress,
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
                          DeliveryAddress = user.DeliveryAddress,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber
                      }).Where(x => x.Type == TypeUser.Seller).ToList();

        return result;
    }

    public async Task<UserDto> GetAdminUserByEmailAsync(string email)
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
                          DeliveryAddress = user.DeliveryAddress,
                          Bank = user.Bank,
                          Role = user.Role,
                          IsDeleted = user.IsDeleted,
                          CreatedAt = user.CreatedAt,
                          VatNumber = user.VatNumber
                      }).FirstOrDefault(x => x.Type == TypeUser.Administrator && x.Email == email);

        return result;
    }

    private void AddErrors(IdentityResult identityResult)
    {
        foreach (var error in identityResult.Errors)
        {
            _result.AddError(error.Description);
        }
    }
    private void AddLoginErrors(IdentityResult identityResult)
    {
        foreach (var error in identityResult.Errors)
        {
            _loginResult.AddError(error.Description);
        }
    }

    private void AddLoginError(string error)
    {
        _loginResult.AddError(error);
    }
}
