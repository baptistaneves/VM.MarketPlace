using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

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