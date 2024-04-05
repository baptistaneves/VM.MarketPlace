using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateGroupRequest
{
    [Required(ErrorMessage = GroupErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = GroupErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    public bool IsActive { get; set; }
}

public class UpdateGroupRequest
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = GroupErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = GroupErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    public bool IsActive { get; set; }
}