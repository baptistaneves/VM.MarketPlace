using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateSubcategoryRequest
{
    [Required(ErrorMessage = SubcategoryErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = SubcategoryErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    [Required(ErrorMessage = SubcategoryErrorMessage.CategoryIsRequired)]
    public Guid CategoryId { get; set; }
}

public class UpdateSubcategoryRequest
{
    [Required(ErrorMessage = SubcategoryErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = SubcategoryErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = SubcategoryErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    [Required(ErrorMessage = SubcategoryErrorMessage.CategoryIsRequired)]
    public Guid CategoryId { get; set; }
}