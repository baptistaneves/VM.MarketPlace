namespace VM.Marketplace.Application.Validations;

internal class CreateProductValidation : AbstractValidator<CreateProductRequest>
{
    public CreateProductValidation()
    {
        RuleFor(x => x.Name).NotEmpty().WithMessage(ProductErrorMessage.NameIsRequired);

        RuleFor(x => x.Description).NotEmpty().WithMessage(ProductErrorMessage.DescriptionIsRequired);

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage(ProductErrorMessage.PriceIsRequired)
            .GreaterThan(0).WithMessage(ProductErrorMessage.PriceMustBeGreaterThan);

        RuleFor(x => x.MainPhoto).NotEmpty().WithMessage(ProductErrorMessage.PhotoIsRequired);

        RuleFor(x => x.CategoryId).NotEqual(Guid.Empty).WithMessage(ProductErrorMessage.CategoryIsRequired);

        When(x => x.IsMedicine == true, () =>
        {
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage(ProductErrorMessage.ExpiryDateRequired);
        });
    }
}

internal class UpdateProductValidation : AbstractValidator<CreateProductRequest>
{
    public UpdateProductValidation()
    {
        RuleFor(x => x.Id).NotEqual(Guid.Empty).WithMessage(ProductErrorMessage.IdNotValid);

        RuleFor(x => x.Name).NotEmpty().WithMessage(ProductErrorMessage.NameIsRequired);

        RuleFor(x => x.Description).NotEmpty().WithMessage(ProductErrorMessage.DescriptionIsRequired);

        RuleFor(x => x.Price)
            .NotEmpty().WithMessage(ProductErrorMessage.PriceIsRequired)
            .GreaterThan(0).WithMessage(ProductErrorMessage.PriceMustBeGreaterThan);

        RuleFor(x => x.CategoryId).NotEqual(Guid.Empty).WithMessage(ProductErrorMessage.CategoryIsRequired);

        When(x => x.IsMedicine == true, () =>
        {
            RuleFor(x => x.ExpiryDate).NotEmpty().WithMessage(ProductErrorMessage.ExpiryDateRequired);
        });
    }
}
