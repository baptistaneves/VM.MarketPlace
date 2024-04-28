namespace VM.Marketplace.Application.Validations;

internal class CreateUnitValidation : AbstractValidator<CreateUnitRequest>
{
    public CreateUnitValidation()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(UnitErrorMessage.DescriptionIsRequired)
            .MinimumLength(3).WithMessage(UnitErrorMessage.DescriptionMinLength);
    }
}

internal class UpdateUnitValidation : AbstractValidator<UpdateUnitRequest>
{
    public UpdateUnitValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(UnitErrorMessage.IdNotValid);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(UnitErrorMessage.DescriptionIsRequired)
            .MinimumLength(3).WithMessage(UnitErrorMessage.DescriptionMinLength);
    }
}
