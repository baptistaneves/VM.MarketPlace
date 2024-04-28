using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateStateRequest
{ 
    [Required(ErrorMessage = StateErrorMessage.NameIsRequired)]
    [MinLength(3, ErrorMessage = StateErrorMessage.NameMinLength)]
    public string Name { get; set; }
}

public class UpdateStateRequest
{
    [Required(ErrorMessage = StateErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = StateErrorMessage.NameIsRequired)]
    [MinLength(3, ErrorMessage = StateErrorMessage.NameMinLength)]
    public string Name { get; set; }
}
