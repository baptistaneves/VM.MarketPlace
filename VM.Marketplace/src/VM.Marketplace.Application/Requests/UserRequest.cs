using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateAdminUserRequest
{
    [Required(ErrorMessage = UserErrorMessage.FullNameIsRequired)]
    [MinLength(3, ErrorMessage = UserErrorMessage.FullNameMinLength)]
    public string FullName { get; set; }

    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    [EmailAddress(ErrorMessage = UserErrorMessage.EmailNotValid)]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }

    [Required(ErrorMessage = UserErrorMessage.RoleIsRequired)]
    public string Role { get; set; }

}

public class UpdateAdminUserRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = UserErrorMessage.FullNameIsRequired)]
    [MinLength(3, ErrorMessage = UserErrorMessage.FullNameMinLength)]
    public string FullName { get; set; }

    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    [EmailAddress(ErrorMessage = UserErrorMessage.EmailNotValid)]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = UserErrorMessage.RoleIsRequired)]
    public string Role { get; set; }

}

public class LoginRequest
{
    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    public string Email { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }
}

public class CreateCustomerUserRequest
{

    [Required(ErrorMessage = UserErrorMessage.FullNameIsRequired)]
    [MinLength(3, ErrorMessage = UserErrorMessage.FullNameMinLength)]
    public string FullName { get; set; }

    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    [EmailAddress(ErrorMessage = UserErrorMessage.EmailNotValid)]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }
}

public class CreateSellerUserRequest
{

    [Required(ErrorMessage = UserErrorMessage.FullNameIsRequired)]
    [MinLength(3, ErrorMessage = UserErrorMessage.FullNameMinLength)]
    public string FullName { get; set; }

    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    [EmailAddress(ErrorMessage = UserErrorMessage.EmailNotValid)]
    public string Email { get; set; }

    [Required(ErrorMessage = UserErrorMessage.VatNumberIsRequired)]
    public string VatNumber { get; set; }

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }

}

public class CreateSellerUserFromDashboardRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = UserErrorMessage.FullNameIsRequired)]
    [MinLength(3, ErrorMessage = UserErrorMessage.FullNameMinLength)]
    public string FullName { get; set; }

    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    [EmailAddress(ErrorMessage = UserErrorMessage.EmailNotValid)]
    public string Email { get; set; }

    [Required(ErrorMessage = UserErrorMessage.VatNumberIsRequired)]
    public string VatNumber { get; set; }

    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }

    [Required(ErrorMessage = UserErrorMessage.AddressIsRequired)]
    public string Address { get; private set; }

    [Required(ErrorMessage = UserErrorMessage.DeliveryAddressIsRequired)]
    public string DeliveryAddress { get; private set; }

    [Required(ErrorMessage = UserErrorMessage.BankIsRequired)]
    public string Bank { get; private set; }

    [Required(ErrorMessage = UserErrorMessage.AccountNumberIsRequired)]
    public string AccountNumber { get; private set; }

    [Required(ErrorMessage = UserErrorMessage.AccountHolderIsRequired)]
    public string AccountHolder { get; private set; }

    [Required(ErrorMessage = UserErrorMessage.IbanIsRequired)]
    public string Iban { get; private set; }

}