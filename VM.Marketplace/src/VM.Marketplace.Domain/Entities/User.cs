namespace VM.Marketplace.Domain.Entities;

public class User : Entity
{
    public string FullName { get; private set; }
    public string Role { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public TypeUser Type { get; private set; }
    public TypeSeller TypeSeller { get; private set; }
    public string PhotoUrl { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public string State { get; private set; }
    public string VatNumber { get; private set; }
    public string Bank { get; private set; }
    public string AccountNumber { get; private set; }
    public string AccountHolder { get; private set; }
    public string Iban { get; private set; }
    public string TaxIdentificationNumber { get; private set; }
    public string BusinessLicenseUrl { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsBlocked { get; private set; }
    public bool IsVerified { get; private set; }

    public static User CreateSellerUser(string fullName, string email,
        string phoneNumber, string password)
    {
        return new User
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            Password = password,
            Type = TypeUser.Seller,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static User UpdateSellerUser(Guid id, string fullName, string email,
       string phoneNumber, string city, string state, string address,
       string taxIdentificationNumber, TypeSeller typeSeller, string businessLicense)
    {
        return new User
        {
            Id =  id,
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            City = city,
            State = state,
            Address = address,
            TaxIdentificationNumber = taxIdentificationNumber,
            TypeSeller = typeSeller
        };
    }

    public static User AddBusinessLicense(Guid id, string businessLicenseUrl)
    {
        return new User
        {
            Id = id,
            BusinessLicenseUrl = businessLicenseUrl
        };
    }

    public void SetUserAsVerified()
    {
        IsVerified = true;
    }

    public static User CreateCustomerUser(string fullName, string email, string phoneNumber, string password)
    {
        return new User
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            Password = password,
            Type = TypeUser.Customer,
            CreatedAt = DateTime.UtcNow
        };
    }


    public static User CreateAdminUser(string fullName, string email, string phoneNumber, string password,
        string role)
    {
        return new User
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            Password = password,
            Role = role,
            Type = TypeUser.Administrator,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static User UpdateAdminUser(Guid id, string fullName, string email, string phoneNumber, string role)
    {
        return new User
        {
            Id = id,
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            Role = role
        };
    }
}