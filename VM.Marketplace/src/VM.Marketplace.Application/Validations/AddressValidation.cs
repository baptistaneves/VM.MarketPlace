namespace VM.Marketplace.Application.Validations;

internal class CreateAddressValidation : AbstractValidator<CreateAddressRequest>
{
    public CreateAddressValidation()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(AddressErrorMessage.DescriptionIsRequired)
            .MinimumLength(10).WithMessage(AddressErrorMessage.DescriptionMinLength);

        RuleFor(x => x.CityId)
            .NotEqual(Guid.Empty).WithMessage(AddressErrorMessage.CityIsRequired);
    }
}

internal class UpdateAddressValidation : AbstractValidator<UpdateAddressRequest>
{
    public UpdateAddressValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(AddressErrorMessage.IdNotValid);

        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(AddressErrorMessage.DescriptionIsRequired)
            .MinimumLength(10).WithMessage(AddressErrorMessage.DescriptionMinLength);

        RuleFor(x => x.CityId)
            .NotEqual(Guid.Empty).WithMessage(AddressErrorMessage.CityIsRequired);
    }
}
