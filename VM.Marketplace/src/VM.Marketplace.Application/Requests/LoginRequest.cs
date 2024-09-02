using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class LoginRequest
{
    [Required(ErrorMessage = UserErrorMessage.EmailIsRequired)]
    public string Email { get; set; }

    [Required(ErrorMessage = UserErrorMessage.PasswordIsRequired)]
    public string Password { get; set; }
}