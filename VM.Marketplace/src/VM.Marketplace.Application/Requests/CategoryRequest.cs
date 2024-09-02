using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateCategoryRequest
{
    [Required(ErrorMessage = CategoryErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = CategoryErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    public IFormFile? ImageFile { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}

public class UpdateCategoryRequest
{
    [Required(ErrorMessage = CategoryErrorMessage.IdNotValid)]
    public Guid Id { get; set; }

    [Required(ErrorMessage = CategoryErrorMessage.DescriptionIsRequired)]
    [MinLength(3, ErrorMessage = CategoryErrorMessage.DescriptionMinLength)]
    public string Description { get; set; }

    public IFormFile? ImageFile { get; set; }

    public string ImageUrl { get; set; } = string.Empty;
}