namespace VM.Marketplace.Application.Validations;

internal class CreateStateValidation : AbstractValidator<CreateStateRequest>
{
    public CreateStateValidation()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(StateErrorMessage.NameIsRequired)
            .MinimumLength(3).WithMessage(StateErrorMessage.NameMinLength);
    }
}

internal class UpdateStateValidation : AbstractValidator<UpdateStateRequest>
{
    public UpdateStateValidation()
    {
        RuleFor(x => x.Id)
            .NotEqual(Guid.Empty).WithMessage(StateErrorMessage.IdNotValid);

        RuleFor(x => x.Name)
            .NotEmpty().WithMessage(StateErrorMessage.NameIsRequired)
            .MinimumLength(3).WithMessage(StateErrorMessage.NameMinLength);
    }
}
