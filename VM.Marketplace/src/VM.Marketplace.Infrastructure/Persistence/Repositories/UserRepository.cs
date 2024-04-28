namespace VM.Marketplace.Infrastructure.Persistence.Repositories;

public class UserRepository : GenericRepository<User>, IUserRepository
{
    private const string collectionName = "users";
    private OperationResult<User> _result;

    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;

    public UserRepository(IMongoDatabase database,
                          UserManager<ApplicationUser> userManager,
                          SignInManager<ApplicationUser> signInManager) : base(database, collectionName)
    {
        _userManager = userManager;
        _result = new OperationResult<User>();
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
            IsDeleted = user.IsDeleted
        };

        var identityResult = await _userManager.CreateAsync(newUser, user.Password);

        if (!identityResult.Succeeded)
        {
            AddErrors(identityResult);
            return _result;
        }

        return _result;
    }

    public async Task<OperationResult<User>> Login(string username, string password)
    {
        var user = await _userManager.FindByEmailAsync(username);

        if(user is null)
        {
            AddError(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        var identityResult = await _signInManager.CheckPasswordSignInAsync(user, password, true);

        if(identityResult.IsLockedOut)
        {
            AddError(UserErrorMessage.LockoutFailure);
            return _result;
        }

        if (!identityResult.Succeeded) 
        {
            AddError(UserErrorMessage.IncorretEmailOrPassword);
            return _result;
        }

        return _result;
    }

    public async Task<IEnumerable<User>> GetAllAdminUsersAsync()
    {
        return await _collection.Find(x => x.Type == TypeUser.Administrator).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllCustomerUsersAsync()
    {
        return await _collection.Find(x => x.Type == TypeUser.Customer).ToListAsync();
    }

    public async Task<IEnumerable<User>> GetAllSellerUsersAsync()
    {
        return await _collection.Find(x => x.Type == TypeUser.Seller).ToListAsync();
    }

    private void AddErrors(IdentityResult identityResult)
    {
        foreach (var error in identityResult.Errors)
        {
            _result.AddError(error.Description);
        }
    }

    private void AddError(string error)
    {
       _result.AddError(error);
    }
}
