using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateCategoryRequest
{
    [Required(ErrorMessage = CategoryErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = CategoryErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    [Required(ErrorMessage = CategoryErrorMessage.GroupIsRequired)]
    public Guid GroupId { get; set; }
}

public class UpdateCategoryRequest
{
    [Required(ErrorMessage = CategoryErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = CategoryErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = CategoryErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    [Required(ErrorMessage = CategoryErrorMessage.GroupIsRequired)]
    public Guid GroupId { get; set; }
}
