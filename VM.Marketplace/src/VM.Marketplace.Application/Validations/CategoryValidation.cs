namespace VM.Marketplace.Application.Validations;

public class CreateCategoryValidation : AbstractValidator<CreateCategoryRequest>
{
    public CreateCategoryValidation()
    {
        RuleFor(x => x.Description)
           .NotEmpty().WithMessage(CategoryErrorMessage.DescriptionIsRequired)
           .MinimumLength(3).WithMessage(CategoryErrorMessage.DescriptionMinLength);

        RuleFor(x => x.ImageUrl)
           .NotEmpty().WithMessage(CategoryErrorMessage.ImageUrlIsRequired);
    }
}

public class UpdateCategoryValidation : AbstractValidator<UpdateCategoryRequest>
{
    public UpdateCategoryValidation()
    {
        RuleFor(x => x.Id)
          .NotEqual(Guid.Empty).WithMessage(CategoryErrorMessage.IdNotValid);

        RuleFor(x => x.Description)
           .NotEmpty().WithMessage(CategoryErrorMessage.DescriptionIsRequired)
           .MinimumLength(3).WithMessage(CategoryErrorMessage.DescriptionMinLength);
    }
}