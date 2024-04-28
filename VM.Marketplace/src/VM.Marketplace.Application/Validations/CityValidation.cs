namespace VM.Marketplace.Application.Validations;

internal class CreateCityValidation : AbstractValidator<CreateCityRequest>
{
    public CreateCityValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(CityErrorMessage.NameIsRequired)
            .MinimumLength(3).WithMessage(CityErrorMessage.NameMinLength);

        RuleFor(x => x.StateId)
            .NotEqual(Guid.Empty).WithMessage(CityErrorMessage.StateIsRequired);
    }
}

internal class UpdateCityValidation : AbstractValidator<UpdateCityRequest>
{
    public UpdateCityValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(CityErrorMessage.IdNotValid);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(CityErrorMessage.NameIsRequired)
            .MinimumLength(3).WithMessage(CityErrorMessage.NameMinLength);

        RuleFor(x => x.StateId)
            .NotEqual(Guid.Empty).WithMessage(CityErrorMessage.StateIsRequired);
    }
}