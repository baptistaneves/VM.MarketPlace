namespace VM.Marketplace.Domain.Entities;

public class User : Entity
{
    public string FullName { get; private set; }
    public string Role { get; private set; }
    public string Password { get; private set; }
    public string Email { get; private set; }
    public string PhoneNumber { get; private set; }
    public TypeUser Type { get; private set; }
    public string PhotoUrl { get; private set; }
    public string Address { get; private set; }
    public string DeliveryAddress { get; private set; }
    public string VatNumber { get; private set; }
    public string Bank { get; private set; }
    public string AccountNumber { get; private set; }
    public string AccountHolder { get; private set; }
    public string Iban { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public bool IsBlocked { get; private set; }

    public static User CreateSellerUser(string fullName, string email, string phoneNumber,
        string vatNumber, string password)
    {
        return new User
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            VatNumber = vatNumber,
            Password = password,
            Type = TypeUser.Seller,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static User CreateSellerUserFromDashboard(string fullName, string email, string phoneNumber,
        string vatNumber, string iban, string address, string deliverAddress, string accountHolder,
        string accountNumber, string bank, string password)
    {
        return new User
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            VatNumber = vatNumber,
            Iban = iban,
            AccountHolder = accountHolder,
            Address = address,
            DeliveryAddress = deliverAddress,
            AccountNumber = accountNumber,
            Bank = bank,
            Password = password,
            Type = TypeUser.Seller,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static User UpdateSellerUserFromDashboard(Guid id, string fullName, string email, string phoneNumber,
       string vatNumber, string iban, string address, string deliverAddress, string accountHolder,
       string accountNumber, string bank, string password)
    {
        return new User
        {
            Id = id,
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            VatNumber = vatNumber,
            Iban = iban,
            AccountHolder = accountHolder,
            Address = address,
            DeliveryAddress = deliverAddress,
            AccountNumber = accountNumber,
            Bank = bank,
            Password = password,
            Type = TypeUser.Seller,
            CreatedAt = DateTime.UtcNow
        };
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