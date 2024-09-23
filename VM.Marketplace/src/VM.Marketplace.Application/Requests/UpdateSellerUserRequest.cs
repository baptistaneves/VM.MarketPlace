using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class UpdateSellerUserRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = UserErrorMessage.FullNameIsRequired)]
    [MinLength(3, ErrorMessage = UserErrorMessage.FullNameMinLength)]
    public string FullName { get; set; }

    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    [EmailAddress(ErrorMessage = UserErrorMessage.EmailNotValid)]
    public string Email { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PhoneNumberIsRequired)]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = UserErrorMessage.CityIsRequired)]
    public string City { get; set; }

    [Required(ErrorMessage = UserErrorMessage.StateIsRequired)]
    public string State { get; set; }

    [Required(ErrorMessage = UserErrorMessage.AddressIsRequired)]
    public string Address { get; set; }

    public string? TaxIdentificationNumber { get; set; }
    public string? BusinessLicense { get; set; }
    public TypeSeller TypeSeller { get; set; }
    public IFormFile? File { get; set; }
}