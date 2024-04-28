﻿using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Domain.Results;

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