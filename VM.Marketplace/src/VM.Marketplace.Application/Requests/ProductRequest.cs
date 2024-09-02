using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VM.Marketplace.Application.Requests;

public class CreateProductRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }

    [Required(ErrorMessage = ProductErrorMessage.NameIsRequired)]
    public string Name { get; set; }

    [Required(ErrorMessage = ProductErrorMessage.DescriptionIsRequired)]
    public string Description { get; set; }

    public string TechnicalSpecifications { get; set; } = string.Empty;

    public string MainPhoto { get; set; } = string.Empty;

    public IFormFile? ImageFile { get; set; }

    [Required(ErrorMessage = ProductErrorMessage.PriceIsRequired)]
    public decimal Price { get; set; }

    public decimal PromotionalPrice { get; set; }

    public bool IsMedicine { get; set; }
    public DateTime? ExpiryDate { get; set; }
}

public class UpdateProductRequest
{
    public Guid Id { get; set; }
    public Guid CategoryId { get; set; }
    public Guid UserId { get; set; }

    [Required(ErrorMessage = ProductErrorMessage.NameIsRequired)]
    public string Name { get; set; }

    [Required(ErrorMessage = ProductErrorMessage.DescriptionIsRequired)]
    public string Description { get; set; }

    public string TechnicalSpecifications { get; set; }

    public string MainPhoto { get; set; } = string.Empty;

    public IFormFile? ImageFile { get; set; }

    [Required(ErrorMessage = ProductErrorMessage.PriceIsRequired)]
    public decimal Price { get; set; }

    public decimal PromotionalPrice { get; set; }

    public bool IsMedicine { get; set; }
    public DateTime? ExpiryDate { get; set; }
}
