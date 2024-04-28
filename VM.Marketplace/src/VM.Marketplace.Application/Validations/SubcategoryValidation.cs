namespace VM.Marketplace.Application.Validations;

internal class CreateSubcategoryValidation : AbstractValidator<CreateSubcategoryRequest>
{
    public CreateSubcategoryValidation()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(SubcategoryErrorMessage.DescriptionIsRequired)
            .MinimumLength(3).WithMessage(SubcategoryErrorMessage.DescriptionMinLength);

        RuleFor(x => x.CategoryId)
            .NotEqual(Guid.Empty).WithMessage(SubcategoryErrorMessage.CategoryIsRequired);
    }
}

internal class UpdateSubcategoryValidation : AbstractValidator<UpdateSubcategoryRequest>
{
    public UpdateSubcategoryValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(SubcategoryErrorMessage.IdNotValid);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(SubcategoryErrorMessage.DescriptionIsRequired)
            .MinimumLength(3).WithMessage(SubcategoryErrorMessage.DescriptionMinLength);

        RuleFor(x => x.CategoryId)
            .NotEqual(Guid.Empty).WithMessage(SubcategoryErrorMessage.CategoryIsRequired);
    }
}
