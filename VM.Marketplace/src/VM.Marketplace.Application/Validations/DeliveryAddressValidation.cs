namespace VM.Marketplace.Application.Validations;

internal class CreateDeliveryAddressValidation : AbstractValidator<CreateDeliveryAddressRequest>
{
    public CreateDeliveryAddressValidation()
    {
        RuleFor(x => x.Description)
            .NotEmpty().WithMessage(AddressErrorMessage.DescriptionIsRequired)
            .MinimumLength(10).WithMessage(AddressErrorMessage.DescriptionMinLength);

        RuleFor(x => x.CityId)
            .NotEqual(Guid.Empty).WithMessage(AddressErrorMessage.CityIsRequired);
    }
}

internal class UpdateDeliveryAddressValidation : AbstractValidator<UpdateDeliveryAddressRequest>
{
    public UpdateDeliveryAddressValidation()
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
